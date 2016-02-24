using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Wall;
using VKCore.Converters.DateTimeConverter;

namespace VKCore.API.VKModels.Board
{
    public class BoarsClass
    {
        private int _date;

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("from_id")]
        public int from_id { get; set; }

        [JsonProperty("date")]
        public int date
        {
            get { return _date; }
            set { _date = value; str_date = MessagesDataTimeConvert.MessageDate(value); }
        }

        public string str_date { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("likes")]
        public Likes likes { get; set; }
        [JsonProperty("can_edit")]
        public int can_edit { get; set; }
        [JsonProperty("attachments")]
        public List<AttachmentsClass> attachments { get; set; }
        [JsonProperty("message_from")]
        public PostedBy posted_by { get; set; }
    }

    public class BoardRootClass
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("items")]
        public List<BoarsClass> items { get; set; }
        [JsonProperty("profiles")]
        public List<UserClass> profiles { get; set; }
        [JsonProperty("groups")]
        public List<GroupsClass> groups { get; set; }
    }

    public class BoardParamClass
    {
        public long group_id { get; set; }
        public long topic_id { get; set; }

    }
}
