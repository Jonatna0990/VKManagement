using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Wall;
using VKCore.Converters.DateTimeConverter;

namespace VKCore.API.VKModels.Topics
{
    public class TopicsClass
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("items")]
        public ObservableCollection<TopicComment> items { get; set; }
        [JsonProperty("default_order")]
        public double default_order { get; set; }
        [JsonProperty("can_add_topics")]
        public int can_add_topics { get; set; }
        [JsonProperty("profiles")]
        public ObservableCollection<TopicsProfile> profiles { get; set; }
        [JsonProperty("groups")]
        public ObservableCollection<GroupsClass> groups { get; set; }
    }

    public class TopicsProfile : UserClass
    {
        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class TopicComment
    {
        private long _created;
        private long _updated;
        private PostedBy _updatedby;

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("created")]
        public long created
        {
            get { return _created; }
            set { _created = value;
                CreatedDate = MessagesDataTimeConvert.MessageDate(value);
            }
        }

        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        [JsonProperty("created_by")]
        public int created_by { get; set; }

        [JsonProperty("updated")]
        public long updated
        {
            get { return _updated; }
            set { _updated = value; UpdatedDate = MessagesDataTimeConvert.MessageDate(value); }
        }

        [JsonProperty("updated_by")]
        public int updated_by { get; set; }
        [JsonProperty("is_closed")]
        public int is_closed { get; set; }
        [JsonProperty("is_fixed")]
        public int is_fixed { get; set; }
        [JsonProperty("comments")]
        public int comments { get; set; }
        public PostedBy UpadtedBy
        {
            get { return _updatedby; }
            set { _updatedby = value;  }
        }
        [JsonProperty("last_comment")]
        public string last_comment { get; set; }
    }
}
