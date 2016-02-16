using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;

namespace VKCore.API.VKModels.Messages
{
    public class MessageRoot
    {
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
            set { _unread = value;  }
        }

        [JsonProperty("message")]
        public MessageClass message
        {
            get { return _message; }
            set { _message = value; }
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
        private MessageFrom _msgFrom;

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("date")]
        public int date { get; set; }
        [JsonProperty("out ")]
        public int _out { get; set; }
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [JsonProperty("read_state")]
        public int read_state { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("body")]
        public string body { get; set; }
        [JsonProperty("random_id")]
        public int random_id { get; set; }
        [JsonProperty("emoji")]
        public int emoji { get; set; }
        public MessageFrom MsgFrom
        {
            get { return _msgFrom; }
            set { _msgFrom = value; RaisePropertyChanged("MsgFrom"); }
        }
        public string DateNewDialogs { get { return DateTimeHelper.GetTimeAgoForDialogs(date); } }

    }
    public class MessageFrom
    {
        private UserClass _fromUser;
        private GroupsClass _fromGroup;

        public MessageFrom(UserClass user = null, GroupsClass group = null)
        {
            if (user != null) FromUser = user;
            if (group != null) FromGroup = group;
        }
       
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
