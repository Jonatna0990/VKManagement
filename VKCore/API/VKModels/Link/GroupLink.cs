using Newtonsoft.Json;

namespace VKCore.API.VKModels.Link
{
    public class GroupLink
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("photo_50")]
        public string photo_50 { get; set; }

        [JsonProperty("photo_100")]
        public string photo_100 { get; set; }

        [JsonProperty("edit_title")]
        public int? edit_title { get; set; }
        public int image_processing { get; set; }
    }
}