using Newtonsoft.Json;

namespace VKCore.API.VKModels.Wall
{
    public class WallClass : WallMainClass
    {

        [JsonProperty("to_id")]
        public int to_id { get; set; }
        [JsonProperty("copy_owner_id")]
        public int copy_owner_id { get; set; }
        [JsonProperty("copy_post_id")]
        public int copy_post_id { get; set; }
        [JsonProperty("copy_text")]
        public int copy_text { get; set; }


    }

    public class WallReplyClass
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("from_id")]
        public int from_id { get; set; }
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [JsonProperty("date")]
        public int date { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("reply_to_uid")]
        public int reply_to_uid { get; set; }
        [JsonProperty("reply_to_cid")]
        public int reply_to_cid { get; set; }
        [JsonProperty("likes")]
        public Likes likes { get; set; }
    }
}

