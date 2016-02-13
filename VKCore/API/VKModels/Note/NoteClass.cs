using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKCore.API.VKModels.Note
{
    public class NoteClass
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("user_id")]
        public long user_id { get; set; }
        [JsonProperty("owner_id")]
        public long owner_id { get { return user_id; } set { user_id = value; } }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("text")]
        private string text { get; set; }
        [JsonProperty("comments")]
        public int comments { get; set; }
        [JsonProperty("read_comments")]
        public int read_comments { get; set; }
        [JsonProperty("view_url")]
        public string view_url { get; set; }
    }
}
