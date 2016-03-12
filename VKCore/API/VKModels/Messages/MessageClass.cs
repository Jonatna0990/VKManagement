using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;

namespace VKCore.API.VKModels.Messages
{
    public class MainMessageClass
    {
        [JsonProperty("dialogs")]
        public VKCollection<MessageRoot> dialogs { get; set; }
        [JsonProperty("users")]
        public ObservableCollection<UserClass> users { get; set; }
        [JsonProperty("groups")]
        public ObservableCollection<GroupsClass> groups { get; set; }
    }
    public class MessageRoot : ViewModelBase
    {
        public LockerClass locker { get; set; }
        public string temp_msg { get; set; }
        private int _unread = 0;
        private MessageClass _message;
        [JsonProperty("in_read")]
        public int in_read { get; set; }
        [JsonProperty("out_read")]
        public int out_read { get; set; }
        [JsonProperty("unread")]
        public int unread
        {
            get { return _unread; }
            set { _unread = value; RaisePropertyChanged("unread"); }
        }

        [JsonProperty("message")]
        public MessageClass message
        {
            get { return _message; }
            set
            {
                _message = value;
                locker = new LockerClass(2, this.message.user_id);
                temp_msg = this.message.body;
                locker.Locked += Locker_Locked; RaisePropertyChanged("message");
            }
        }
        private void Locker_Locked(object sender, EventArgs e)
        {
            LockerClass t = sender as LockerClass;
            if (t != null)
            {
                if (this.message.user_id == t.LockerId)
                    message.body = temp_msg;
            }
        }


    }

    public class DialogsClass
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("unread_dialogs")]
        public int unread_dialogs { get; set; }
        [JsonProperty("items")]
        public ObservableCollection<MessageRoot> messages { get; set; }
    }
    public class MessageClass : ViewModelBase
    {
        private string _photo100;
        private string _body;
        private int _readState;
        private int _id;
        private MessageFrom _msgFrom;
        private string _action;
        private ObservableCollection<MessageClass> _fwdMessages;


        [JsonProperty("id")]
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        [JsonProperty("date")]
        public long date { get; set; }
        [JsonProperty("out")]
        public int _out { get; set; }
        [JsonProperty("user_id")]
        public long user_id { get; set; }
        [JsonProperty("from_id")]
        public long from_id { get; set; }
        [JsonProperty("read_state")]
        public int read_state
        {
            get { return _readState; }
            set { _readState = value; RaisePropertyChanged("read_state"); }
        }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("body")]
        public string body
        {
            get { return _body; }
            set
            {
                if (_body == value) return;
                _body = value; RaisePropertyChanged("body");
            }
        }

        [JsonProperty("geo")]
        public GeoClass geo { get; set; }

        [JsonProperty("action")]
        public string action
        {
            get { return _action; }
            set
            {
                if (string.IsNullOrEmpty(body)) body = value;
                _action = value; RaisePropertyChanged("action");
            }
        }

        [JsonProperty("action_mid")]
        public int? action_mid { get; set; }
        [JsonProperty("chat_id")]
        public int? chat_id { get; set; }
        [JsonProperty("action_text")]
        public string action_text { get; set; }
        [JsonProperty("chat_active")]
        public List<int> chat_active { get; set; }
        [JsonProperty("push_settings")]
        public PushSettings push_settings { get; set; }
        [JsonProperty("admin_id")]
        public int? admin_id { get; set; }

        [JsonProperty("fwd_messages")]
        public ObservableCollection<MessageClass> fwd_messages
        {
            get { return _fwdMessages; }
            set { _fwdMessages = value; }
        }

        [JsonProperty("emoji")]
        public int? emoji { get; set; }

        [JsonProperty("users_count")]
        public int? users_count { get; set; }
        [JsonProperty("photo_50")]
        public string photo_50 { get; set; }

        [JsonProperty("photo_100")]
        public string photo_100
        {
            get { return _photo100; }
            set { _photo100 = value; RaisePropertyChanged("photo_100"); }
        }

        [JsonProperty("photo_200")]
        public string photo_200 { get; set; }
        [JsonProperty("attachments")]
        public ObservableCollection<AttachmentsClass> attachments { get; set; }

        public MessageFrom MsgFrom
        {
            get { return _msgFrom; }
            set { _msgFrom = value; RaisePropertyChanged("MsgFrom"); }
        }

        public string DateNewMessages { get { return DateTimeHelper.GetTimeAgoForMessages(date); } }
        public string DateNewDialogs { get { return DateTimeHelper.GetTimeAgoForDialogs(date); } }
        public string DateNewFwdMessages { get { return DateTimeHelper.GetTimeAgoForFwdMessages(date); } }
        public Visibility OutVisibility { get { return (_out == 1) ? Visibility.Visible : Visibility.Collapsed; } }
        public ChatAction chat_action
        {
            get
            {
                switch (action)
                {
                    case "chat_create": return ChatAction.Create;
                    case "chat_invite_user": return ChatAction.InviteUser;
                    case "chat_kick_user": return ChatAction.KickUser;
                    case "chat_photo_remove": return ChatAction.PhotoRemove;
                    case "chat_photo_update": return ChatAction.PhotoUpdate;
                    case "chat_title_update": return ChatAction.TitleUpdate;
                    default: return ChatAction.None;

                }
            }
        }

    }
    public enum ChatAction
    {
        PhotoUpdate,
        PhotoRemove,
        Create,
        TitleUpdate,
        InviteUser,
        KickUser,
        None
    }
    public class PushSettings
    {
        [JsonProperty("sound")]
        public int sound { get; set; }
        [JsonProperty("disabled_until")]
        public int disabled_until { get; set; }
    }

   
    public class MessageFrom
    {
        private UserClass _fromUser;
        private GroupsClass _fromGroup;

        public MessageFrom(UserClass user = null, GroupsClass group = null, List<UserClass> chatList = null)
        {
            if (user != null) FromUser = user;
            if (group != null) FromGroup = group;
            if (chatList != null) ChatUsersList = chatList;
        }
        public List<UserClass> ChatUsersList { get; set; }

        public UserClass FromUser
        {
            get { return _fromUser; }
            set { _fromUser = value; }
        }

        public GroupsClass FromGroup
        {
            get { return _fromGroup; }
            set { _fromGroup = value; }
        }
    }
}
