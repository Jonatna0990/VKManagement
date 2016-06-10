using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Command;
using VKCore.API.Core;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.LongPollServer;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class DialogsCollection : BaseViewModel
    {

       
      
        private int _offset = 0;
        private MainMessageClass _messages;
        private int total_msg_count = 0;
        private bool has_offset = true;
        private LockerClass GetMessagesLocker = null;
        private int offset = 0;

        public RelayCommand<object> NavigateCommand { get; set; }
        public ICommand LoadMoreCommand { get; set; }


        public MainMessageClass Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("Messages"); }
        }

       
        public DialogsCollection(AttachmentsClass attachment=null)
        {
            GetMessagesLocker = new LockerClass(1, -10);
            RegisterTasks("dialogs");
            this.attachment = attachment;
            if (this.Messages == null)
            {
                TaskStarted("dialogs");
                LoadItems();

            }
            LoadMoreCommand = new DelegateCommand(t =>
            {
                if (has_offset && !GetMessagesLocker.IsLocked)
                {
                    GetMessagesLocker.Start();
                    LoadItems();
                }
            
            });

        }

        private MainMessageClass SetSources(MainMessageClass main)
        {
         
            MainMessageClass messageClass = main;
            foreach (var t in messageClass.dialogs.items)
            {
                //беседа

                if (t.message.chat_id != null)
                {
                   
                        if (string.IsNullOrEmpty(t.message.photo_100) || string.IsNullOrEmpty(t.message.photo_50))
                        {
                            t.message.photo_100 = @"ms-appx:///Icons/Dark/Menu/appbar.group.png";
                        }
                    
                    //нет пользователей

                }
                //диалог
                else
                {
                    SetOnlineApp.SetOnlineApplication(messageClass.users);
                  

                        //диалог с группой
                        if (t.message.user_id < 0)
                        {
                            GroupsClass q = messageClass.groups.SingleOrDefault(f => f.id == Math.Abs(t.message.user_id));
                            t.message.MsgFrom = new MessageFrom(null,  q);

                        }
                        //диалог с пользователем
                        else
                        {

                            UserClass q = messageClass.users.SingleOrDefault(f => f.id == t.message.user_id);
                            t.message.MsgFrom = new MessageFrom( q, null);
                        }

                    

                }
            }

            return messageClass;
        }
        private void LoadItems()
        {
            VKRequest.Dispatch<MainMessageClass>(
           new VKRequestParameters(
               SExecute.get_messages, "offset",offset.ToString()),
           (res) =>
           {
               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                   if (Messages == null)
                   {
                       Messages = SetSources(res.Data);
                       TaskFinished("dialogs");
                       total_msg_count = res.Data.dialogs.count;
                   }

                   else
                   {
                       if (total_msg_count > 0 && total_msg_count == offset) has_offset = false;
                       var a = SetSources(res.Data);
                       foreach (var t in a.dialogs.items)
                       {
                           Messages.dialogs.items.Add(t);
                       }
                     
                   }


                   offset += res.Data.dialogs.items.Count; // = Convert.ToUInt16(res.Data.dialogs.items.Count);

               }
               else TaskError("dialogs", res.Error.error_msg);
                   

           });
        }
        protected override void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
        {
            if (Messages != null)
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
            if (Messages != null)
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
            if (Messages != null)
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
            if (Messages?.dialogs != null)
                foreach (var VARIABLE in Messages.dialogs.items)
                {
                    if (VARIABLE.message.user_id == e.uid)
                    {
                        if (VARIABLE.message.MsgFrom != null)
                            VARIABLE.message.MsgFrom.FromUser.SetApplicationIcon(e.extra, true);
                    }
                }
        }

        protected override void MakeOffline(object sender, LongPollUserStatusEventArgs e)
        {
            if (Messages?.dialogs != null)
                foreach (var VARIABLE in Messages.dialogs.items)
                {
                    if (VARIABLE.message.user_id == e.uid)
                    {
                        if (VARIABLE.message.MsgFrom != null) VARIABLE.message.MsgFrom.FromUser.SetApplicationIcon(0);
                    }
                }
        }
    }
}

