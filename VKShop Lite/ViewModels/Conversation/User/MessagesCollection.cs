using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.LongPollServer;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKCore.UserControls.CaptchaControl;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class MessagesCollection : BaseViewModel
    {

        private ObservableCollection<MessageClass> messages;
        public ICommand SendMessageCommand { get; set; }
        public ICommand SelectedStickerCommand { get; set; }
        public ICommand TypingCommand { get; set; }
        private string _userWriteText;
        private LockerClass locker;
        private CoreDispatcher currentDispatcher;
      //  private ObservableCollection<MessageAttachment> _sendPhotos;
        private static LockerClass Locker { get; set; }
        private string _sendingMessage;
        private MessageClass SendParam = null;
        private MessageFrom _messageFrom;

        public MessageFrom messageFrom
        {
            get { return _messageFrom; }
            set { _messageFrom = value; RaisePropertyChanged("messageFrom"); }
        }

        public string SendingMessageText
        {
            get { return _sendingMessage; }
            set { _sendingMessage = value; RaisePropertyChanged("SendingMessageText"); }
        }
        public ObservableCollection<MessageClass> Messages
        {
            get { return messages; }
            set { messages = value; RaisePropertyChanged("Messages"); }
        }
      /*  public ObservableCollection<MessageAttachment> SendPhotos
        {
            get { return _sendPhotos; }
            set { _sendPhotos = value; RaisePropertyChanged("SendPhotos"); }
        }*/
        public string UserWriteText
        {
            get { return _userWriteText; }
            set { _userWriteText = value; RaisePropertyChanged("UserWriteText"); }
        }

        private MarketItem product = null;
        public MessagesCollection(MessageClass param, MarketItem item =null)
        {
            SelectedStickerCommand = new DelegateCommand(t =>
            {
                var stickerClass = t as StickerClass;
                if (stickerClass != null) PrepareSendMessage(stickerClass.id);
               
            });
            SendMessageCommand = new DelegateCommand(t =>
            {
                PrepareSendMessage();
            });
            TypingCommand = new DelegateCommand(t =>
            {
                Typing();
            });
            currentDispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;

       //     SendPhotos = new ObservableCollection<MessageAttachment>();
            SendParam = param;
            if (SendParam != null)
            {
                Messages = new ObservableCollection<MessageClass>();
               
                locker = new LockerClass(2, SendParam.user_id);
                Locker = new LockerClass(5, 0);

                Locker.Locked += Locker_Locked1;
                locker.Locked += Locker_Locked;
                LoadMessages();
                ReadMessages();
                GetSourceInfo();
            }
            if (item != null)
            {
                SendingMessageText = "Здравствуйте! Меня заинтересовал данный товар "+ ProductLinkCreator(item);
                product = item;
            }


        }

       
        public static string ProductLinkCreator(MarketItem item)
        {
            string link = "";

            link = @"http://vk.com/club" + Math.Abs(item.owner_id)+ "?w=product" + item.owner_id+ "_"+item.id;
            return link;
        }

        private void GetSourceInfo()
        {
            if (SendParam.user_id > 0)
            {
                VKRequest.Dispatch<List<UserClass>>(
                       new VKRequestParameters(
                           SUsers.user_get, "user_ids", SendParam.user_id.ToString(), "fields", "photo_100"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               messageFrom = new MessageFrom(res.Data.FirstOrDefault());
                           }
                       });
            }
            else
            {

                VKRequest.Dispatch<List<GroupsClass>>(
                   new VKRequestParameters(
                     SGroups.groups_getById, "group_ids", Math.Abs(SendParam.user_id).ToString(), "fields", "photo_100"),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {
                           messageFrom = new MessageFrom(null,res.Data.FirstOrDefault());
                        

                       }
                   });
            }
            
        }

        private void GetFwdSources()
        {
            List<long> user_list = new List<long>();
            List<long> group_list = new List<long>();
            string users = "";
            string groups = "";
            GetFwdMessagesSources(Messages, group_list, user_list);
            user_list = user_list.Distinct().ToList();
            group_list = group_list.Distinct().ToList();
            users = string.Join(",", user_list.Select(n => n.ToString()).ToArray());
            groups = string.Join(",", group_list.Select(n => n.ToString()).ToArray());
            SetFwdSources(users, groups);
        }

        private void GetFwdMessagesSources(ObservableCollection<MessageClass> messages, List<long> group, List<long> users)
        {
            if (messages == null) return;
            foreach (var a in messages)
            {
                if (a.fwd_messages != null)
                    GetFwdMessageNestedLevel(a, users, group);
            }

        }
        private void GetFwdMessageNestedLevel(MessageClass fwd_message, List<long> users, List<long> groups)
        {
            if (fwd_message == null) return;

            if (fwd_message.fwd_messages != null)
            {
                foreach (var q in fwd_message.fwd_messages)
                {
                    if (q.user_id < 0) { groups.Add(Math.Abs(q.user_id)); }
                    else { users.Add(q.user_id); }
                    GetFwdMessageNestedLevel(q, users, groups);
                }

            }
        }

        private void SetFwdMessagesSources(ObservableCollection<MessageClass> messages, List<UserClass> users = null, List<GroupsClass> groups = null)
        {

            if (users != null)
                foreach (var a in messages)
                {
                    if (a.fwd_messages != null)
                        SetUsers(a, users);
                }
            if (groups != null) foreach (var a in messages)
                {
                    if (a.fwd_messages != null)
                        SetGroups(a, groups);
                }


        }


        private void SetUsers(MessageClass message, List<UserClass> users)
        {
            if (message == null) return;

            if (message.fwd_messages != null)
            {
                foreach (var q in message.fwd_messages)
                {
                    if (q.user_id > 0)
                    {
                        var a = users.FirstOrDefault(w => w.id == q.user_id);
                        if (a != null) q.MsgFrom = new MessageFrom(a);
                    }
                    SetUsers(q, users);
                }

            }

        }

        private void SetGroups(MessageClass message, List<GroupsClass> groups)
        {
            if (message == null) return;

            if (message.fwd_messages != null)
            {
                foreach (var q in message.fwd_messages)
                {
                    if (q.user_id < 0)
                    {
                        var a = groups.FirstOrDefault(w => -w.id == q.user_id);
                        if (a != null)
                            q.MsgFrom = new MessageFrom(null, a);
                    }

                    SetGroups(q, groups);
                }

            }

        }

        private void SetFwdSources(string users = "", string groups = "")
        {
            if (string.IsNullOrEmpty(users) && string.IsNullOrEmpty(groups)) return;
            else
            {

                if (!string.IsNullOrEmpty(users))
                {
                    VKRequest.Dispatch<List<UserClass>>(
                        new VKRequestParameters(
                            SUsers.user_get, "user_ids", users, "fields", "photo_100"),
                        (res) =>
                        {
                            var q = res.ResultCode;
                            if (res.ResultCode == VKResultCode.Succeeded)
                            {
                                SetFwdMessagesSources(Messages, res.Data);
                            }
                        });
                }
                if (!string.IsNullOrEmpty(groups))
                {
                    VKRequest.Dispatch<List<GroupsClass>>(
                       new VKRequestParameters(
                         SGroups.groups_getById, "group_ids", groups, "fields", "photo_100"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               SetFwdMessagesSources(Messages, null, res.Data);


                           }
                       });
                }
            }

            var aasd = Messages;
        }
        private void Locker_Locked(object sender, EventArgs e)
        {
            LockerClass t = sender as LockerClass;
            if (t != null)
            {
                if (SendParam.user_id == t.LockerId)
                    UserWriteText = "";
            }
        }

        private void Locker_Locked1(object sender, EventArgs e)
        {
           locker.Stop();
        }
        public void PrepareSendMessage(int stricker_id = 0, GeoClass geo = null)
        {
            if (SendParam == null) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            if(product == null) 
            param.Add("user_id", SendParam.user_id.ToString());
            else param.Add("peer_id", SendParam.user_id.ToString());

            param.Add("guid", Environment.TickCount.ToString());
            //есть стикер
            if (stricker_id != 0)
            {
                param.Add("sticker_id", stricker_id.ToString());
                SendMessage(param);
                return;
            }
            if (string.IsNullOrEmpty(SendingMessageText) /*&& SendPhotos.Count == 0*/) { return; }

            //есть текст
            if (!(string.IsNullOrEmpty(SendingMessageText))) param.Add("message", SendingMessageText);
          /*  if (SendPhotos.Count != 0)
            {
                string par = "";
                foreach (var t in SendPhotos.ToList())
                {
                    if (t != null)
                        par += string.Format("photo{0}_{1},", t.photo.owner_id, t.photo.id);
                }
                param.Add("attachment", par);
            }*/
            SendMessage(param);
            SendingMessageText = "";
            //SendPhotos.Clear();
        }

        private void LoadChatMessages(int chat_id, int offset = 0)
        {
            var chat = chat_id + 2000000000;
            VKRequest.Dispatch<VKList<MessageClass>>(
           new VKRequestParameters(
               SMessages.messages_getHistory, "peer_id", chat.ToString()),
           (res) =>
           {
               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                   res.Data.items.Reverse();
                   var t = res.Data.items.ToObservableCollection();
                   foreach (var VARIABLE in t)
                   {
                       Messages.Add(VARIABLE);
                   }
               }

           });
        }

        private void LoadUserOrGroupMessages(long user_id, int offset = 0)
        {
            VKRequest.Dispatch<VKList<MessageClass>>(
            new VKRequestParameters(
                SMessages.messages_getHistory, "user_id", user_id.ToString()),
            (res) =>
            {
                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {
                    res.Data.items.Reverse();
                    var t = res.Data.items.ToObservableCollection();
                    foreach (var VARIABLE in t)
                    {
                        Messages.Add(VARIABLE);
                    }
                    GetFwdSources();
                }

            });
        }
        public void LoadMessages(int offset = 0)
        {
            if (SendParam == null) return;
            if (SendParam.chat_id == null) LoadUserOrGroupMessages(SendParam.user_id, offset);
            else LoadChatMessages((int)SendParam.chat_id, offset);


        }

       
        private void CaptchaRequest(VKCaptchaUserRequest captchaUserRequest, Action<VKCaptchaUserResponse> action)
        {
            new VKCaptchaRequestUserControl().ShowCaptchaRequest(captchaUserRequest, action);
        }
        private long ConvertToTimestamp()
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (long)span.TotalSeconds;
        }
        public void SendMessage(Dictionary<string, string> param)
        {
            VKRequest.Dispatch<int>(
               new VKRequestParameters(
                   SMessages.messages_send, param),
               (res) =>
               {
                   var q = new MessageClass();
                   if (param.ContainsKey("message"))
                   {
                       string a = "";
                       param.TryGetValue("message", out a);
                       q._out = 1;
                       q.date = ConvertToTimestamp();
                       q.body = a;

                       // this.Add(q);

                   }
                   Logger(res.ResultCode);

                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       q.id = res.Data;


                   }

               });
        }
        public void ReadMessages()
        {
            VKRequest.Dispatch<int>(
           new VKRequestParameters(
               SMessages.messages_markAsRead, "peer_id", SendParam.user_id.ToString()),
           (res) =>
           {
               Logger(res.ResultCode);

               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {

               }

           });
        }
        private void GetMsgById(long id)
        {
            VKRequest.Dispatch<VKList<MessageClass>>(
                new VKRequestParameters(
                    SMessages.messages_getById, "message_ids", id.ToString()),
                (res) =>
                {
                    var q = res.ResultCode;
                    Logger(res.ResultCode);
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        if (res.Data.items.FirstOrDefault()._out == 0)
                        {
                            ReadMessages();
                        }
                        Messages.Add(res.Data.items.FirstOrDefault());
                        if (res.Data.items.FirstOrDefault().fwd_messages != null) GetFwdSources();
                    }

                });
        }
        public void Typing()
        {
            if (Locker.IsLocked && Locker.LockerId == 0) { }
            else
            {
                Locker.Start();
                VKRequest.Dispatch<int>(
                new VKRequestParameters(
                    SMessages.messages_setActivity, "user_id", SendParam.user_id.ToString(), "type", "typing"),
                (res) =>
                {
                    Logger(res.ResultCode);

                    if (res.ResultCode == VKResultCode.Succeeded)
                    {

                        var t = res;
                    }
                });

            }
        }



        protected override void AddNewMessage(object sender, LongPollMessageEventArgs e)
        {
            if (locker.LockerId == e.from_id && locker.IsLocked) { locker.Stop(); }
            if (is_enabled && e.from_id ==locker.LockerId)
                GetMsgById(e.mid);

        }
        protected override void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.id == e.mid && is_enabled)
                {

                    List<VkLongPollMessageFlags> s = MessageFlagsHelper.CheckFlags(Convert.ToInt32(e.flags));
                    if (s.Contains(VkLongPollMessageFlags.Unread))
                    {
                        VARIABLE.read_state = 1;
                    }
                }
            }

        }
        protected override void MakeOnline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.user_id == e.uid)
                {

                    VARIABLE.MsgFrom.FromUser.SetApplicationIcon(e.extra, true);
                }
            }
           
                
        }

        protected override void MakeOffline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.user_id == e.uid)
                {

                    VARIABLE.MsgFrom.FromUser.SetApplicationIcon(0);
                }
            }
        }
        protected override void WriteMessage(object sender, LongPollUserEventArgs e)
        {
            if (locker.LockerId == e.uid && locker.IsLocked && is_enabled) locker.AddSeconds(3);
            else
            {
                if (e.uid == SendParam.user_id && SendParam.chat_id == null)
                {
                    UserWriteText = "Набирает сообщение"; locker.Start();
                }

            }
        }
       void Logger(object log)
        {
            Debug.WriteLine(log);
        }
    }
}