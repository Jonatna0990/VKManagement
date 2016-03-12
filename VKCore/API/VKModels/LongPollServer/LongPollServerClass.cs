using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VKCore.API.VKModels.LongPollServer
{
    /// <summary>
    /// Класс для работы с LongPoll сервером ВК
    /// </summary>
    public class LongPollServerClass
    {
        [JsonProperty("key")]
        public string key { get; set; }
        [JsonProperty("server")]
        public string server { get; set; }
        [JsonProperty("ts")]
        public int ts { get; set; }

        [JsonProperty("failed")]
        public int failed { get; set; }
        [JsonProperty("updates")]
        public JArray updates { get; set; }

    }
    public class LongPollDeleteMessageEventArgs : EventArgs
    {
        public LongPollDeleteMessageEventArgs(int _mid = 0, long _uid = 0)
        {
            if (uid != 0) uid = _uid;
            if (_mid != 0) mid = _mid;

        }
        public long mid { get; set; }
        public long uid { get; set; }
    }
    public class LongPollMessageFlagsEventArgs : EventArgs
    {
        public LongPollMessageFlagsEventArgs(int _mid = 0, int _flags = 0, long _uid = 0)
        {
            if (uid != 0) uid = _uid;
            if (_mid != 0) mid = _mid;
            if (_flags != 0) flags = _flags;
        }
        public long mid { get; set; }
        public long uid { get; set; }
        public long flags { get; set; }
    }
    public class LongPollMessageEventArgs : EventArgs
    {
        public LongPollMessageEventArgs(int _mid = 0, int _flags = 0, long _from_id = 0, long _date = 0, string _title = "", string _body = "")
        {

            if (_mid != 0) mid = _mid;
            if (_flags != 0) flags = _flags;
            if (_from_id != 0) from_id = _from_id;
            if (_date != 0) date = _date;
            if (!string.IsNullOrEmpty(_title)) title = _title;
            if (!string.IsNullOrEmpty(_body)) body = _body;
        }
        public long mid { get; set; }

        public int flags { get; set; }
        public long from_id { get; set; }
        public long date { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
    public class LongPollMessageChatEventArgs : EventArgs
    {
        private const int ChatIdMask = 2000000000;
        public LongPollMessageChatEventArgs(int _mid = 0, int _flags = 0, long _chat_id = 0, long _date = 0, string _title = "", string _body = "", long _from_id = 0)
        {

            if (_mid != 0) mid = _mid;
            if (_flags != 0) flags = _flags;
            if (_from_id != 0) from_id = _from_id;
            if (_date != 0) date = _date;
            if (!string.IsNullOrEmpty(_title)) title = _title;
            if (!string.IsNullOrEmpty(_body)) body = _body;
            chat_id = _chat_id - ChatIdMask;
        }
        public long mid { get; set; }
        public int flags { get; set; }
        public long from_id { get; set; }
        public long date { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public long chat_id { get; set; }
    }
    public class LongPollUserStatusEventArgs : EventArgs
    {
        public LongPollUserStatusEventArgs(long _id = 0, int _extra = 0, int _flags = 0)
        {
            if (_id != 0) uid = _id;
            if (_extra != 0) extra = _extra;
            if (_flags != 0) flags = _flags;
            else return;

        }
        public long uid { get; set; }
        public int extra { get; set; }
        public int flags { get; set; }

    }
    public class LongPollChatChangeEventArgs : EventArgs
    {
        public LongPollChatChangeEventArgs(int chat_id = 0, int _self = 0)
        {
            if (chat_id != 0) this.chat_id = chat_id;
            if (self != 0) self = _self;

        }
        public int chat_id { get; set; }
        public int self { get; set; }

    }
    public class LongPollUserEventArgs : EventArgs
    {
        public LongPollUserEventArgs(long id = 0, int chat_id = 0, int _flags = 0)
        {
            if (id != 0) uid = id;
            if (chat_id != 0) this.chat_id = chat_id;
            if (_flags != 0) flags = _flags;

        }
        public long uid { get; set; }
        public int chat_id { get; set; }
        public int flags { get; set; }

    }
    public enum LongPollActionType
    {
        ReadMessage,
        WriteMessage,
        MakeOffline,
        MakeOnline,
        AddNewMessage,
        DeleteMessage,
        StopWriteMessage
    }
    public enum LongPollUpdateType
    {
        MessageRemoved = 0,
        MessageFlagsUpdated = 1,
        MessageFlagsSet = 2,
        MessageFlagsReset = 3,
        MessageAdded = 4,
        FriendStatusOnline = 8,
        FriendStatusOffline = 9,
        ChatSettingsChanged = 51,
        UserTypingInConversation = 61,
        UserTypingInChat = 62,
        UserPerformedCall = 70,

        UndocumentedUpdateType1 = 101
    }
    public enum LongPollMessageFlags
    {
        //+1	UNREAD	сообщение не прочитано
        Unread = 1,
        //+2	OUTBOX	исходящее сообщение
        Outbox = 2,
        //+4	REPLIED	на сообщение был создан ответ
        Replied = 4,
        //+8	IMPORTANT	помеченное сообщение
        Important = 8,
        //+16	CHAT	сообщение отправлено через чат
        Chat = 16,
        //+32	FRIENDS	сообщение отправлено другом
        Friends = 32,
        //+64	SPAM	сообщение помечено как "Спам"
        Spam = 64,
        //+128	DELЕTЕD	сообщение удалено (в корзине)
        Deleted = 128,
        //+256	FIXED	сообщение проверено пользователем на спам
        Fixed = 256,
        //+512	MEDIA	сообщение содержит медиаконтент
        Media = 512
    }
}
