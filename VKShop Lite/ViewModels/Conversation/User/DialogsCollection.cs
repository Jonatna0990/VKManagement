using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using GalaSoft.MvvmLight.Command;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.LongPollServer;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class DialogsCollection : BaseViewModel
    {

        private Visibility _isLoaded;

        public Visibility IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }
        private int _offset = 0;
        private MainMessageClass _messages;
       public RelayCommand<object> NavigateCommand { get; set; }

     

        public MainMessageClass Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("Messages"); }
        }
  

        public DialogsCollection()
        {
            if (this.Messages == null)
            {
                NavigateCommand = new RelayCommand<object>(t =>
                {
                  //  NavigateToPage(typeof(DialogConversationPage), t);
                });
                LoadItems();

            }

        }

        private MainMessageClass SetSources(MainMessageClass main)
        {
         
            MainMessageClass messageClass = main;
            foreach (var t in messageClass.dialogs.items)
            {
                //беседа

                if (t.message.chat_id != null)
                {
                    if (t.message.chat_active.Count > 0)
                    {
                        List<UserClass> users = new List<UserClass>();
                        if (t.message.action_mid > 0)
                        {
                            UserClass e = messageClass.users.SingleOrDefault(f => f.id == t.message.action_mid);
                            users.Add(e);
                        }

                        foreach (var tt in t.message.chat_active)
                        {
                            foreach (var q in messageClass.users)
                            {
                                if (tt == q.id)
                                {
                                    users.Add(q);
                                }
                            }


                        }
                        t.message.MsgFrom = new MessageFrom(null,null,users);
                    }
                    {
                        if (string.IsNullOrEmpty(t.message.photo_100) || string.IsNullOrEmpty(t.message.photo_50))
                        {
                            t.message.photo_100 = @"ms-appx:///Icons/Dark/Menu/appbar.group.png";
                        }
                    }
                    //нет пользователей

                }
                //диалог
                else
                {
                    SetOnlineApp.SetOnlineApplication(messageClass.users);
                    foreach (var a in messageClass.dialogs.items)
                    {

                        //диалог с группой
                        if (a.message.user_id < 0)
                        {
                            GroupsClass q = messageClass.groups.SingleOrDefault(f => f.id == Math.Abs(a.message.user_id));
                            a.message.MsgFrom = new MessageFrom(null,  q);

                        }
                        //диалог с пользователем
                        else
                        {

                            UserClass q = messageClass.users.SingleOrDefault(f => f.id == a.message.user_id);
                            a.message.MsgFrom = new MessageFrom( q, null);
                        }

                    }

                }
            }

            return messageClass;
        }
        private void LoadItems()
        {
            Popup popup = new Popup();
            VKRequest.Dispatch<MainMessageClass>(
           new VKRequestParameters(
               SExecute.get_messages),
           (res) =>
           {
               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                   popup.Child = null;
                   popup.IsOpen = false;
                   if (Messages == null)
                   {
                       Messages = SetSources(res.Data);
                       IsLoaded = Visibility.Collapsed;
                   }

                   else
                   {

                       // Messages.dialogs.items.AddRange(res.Data.dialogs.items);
                       // Messages.users.Add(res.Data.users);
                   }


                   _offset++; // = Convert.ToUInt16(res.Data.dialogs.items.Count);

               }
               else
               {

                  
               }

           });
        }
        protected override void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
        {
            foreach (var VARIABLE in Messages.dialogs.items.ToList())
            {
                if (VARIABLE.message.id == e.mid)
                {

                    List<VkLongPollMessageFlags> s = MessageFlagsHelper.CheckFlags(Convert.ToInt32(e.flags));
                    if (s.Contains(VkLongPollMessageFlags.Unread))
                    {
                        if (VARIABLE.unread > 0)
                        {
                            VARIABLE.unread = 0;
                        }
                    }
                }
            }

        }
        private void GetMsgById(long id)
        {

        }
        protected override void AddNewMessage(object sender, LongPollMessageEventArgs e)
        {
            foreach (var t in Messages.dialogs.items.ToList())
            {


                if (e.from_id == t.message.user_id && t.message.chat_id == null)
                {
                    if (t.locker.LockerId == e.from_id && t.locker.IsLocked) { t.locker.Stop(); }

                    VKRequest.Dispatch<VKList<MessageClass>>(
                new VKRequestParameters(
                    SMessages.messages_getById, "message_ids", e.mid.ToString()),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        if (res.Data.items.FirstOrDefault() != null)
                        {
                            var a = t.message.MsgFrom;
                            t.message = res.Data.items.FirstOrDefault();
                            t.message.MsgFrom = a;
                            if (t.message._out == 0) t.unread++;
                            int ta = Messages.dialogs.items.IndexOf(t);
                            if (ta != 0) Messages.dialogs.items.Move(ta, 0);
                        }

                    }

                });




                }

            }
        }
        protected override void WriteMessage(object sender, LongPollUserEventArgs e)
        {
            foreach (var t in Messages.dialogs.items.ToList())
            {
                if (t.locker.LockerId == e.uid && t.locker.IsLocked) t.locker.AddSeconds(3);
                else
                {
                    if (e.uid == t.message.user_id && t.message.chat_id == null)
                    {
                        t.message.body = "Набирает сообщение"; t.locker.Start();
                    }

                }
            }



        }
        protected override void MakeOnline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.dialogs.items)
            {
                if (VARIABLE.message.user_id == e.uid)
                {

                    VARIABLE.message.MsgFrom.FromUser.SetApplicationIcon(e.extra, true);
                }
            }


        }

        protected override void MakeOffline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.dialogs.items)
            {
                if (VARIABLE.message.user_id == e.uid)
                {

                    VARIABLE.message.MsgFrom.FromUser.SetApplicationIcon(0);
                }
            }
           
        }

    }
}

