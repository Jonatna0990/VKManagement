using Newtonsoft.Json;

namespace VKCore.API.VKModels.Link
{
    public class LinkClass
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("image_src")]
        public string image_src { get; set; }

     }
}

