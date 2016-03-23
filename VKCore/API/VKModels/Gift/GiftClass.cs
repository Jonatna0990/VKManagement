using Newtonsoft.Json;

namespace VKCore.API.VKModels.Gift
{
    public class GiftClass
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("thumb_256")]
        public string thumb_256 { get; set; }

        [JsonProperty("thumb_48")]
        public string thumb_48 { get; set; }

        [JsonProperty("thumb_96")]
        public string thumb_96 { get; set; }


    }
}
