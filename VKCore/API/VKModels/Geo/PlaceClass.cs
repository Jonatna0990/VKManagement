using Newtonsoft.Json;

namespace VKCore.API.VKModels.Geo
{
    public class PlaceClass
    {
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("address")]
        public string address { get; set; }

        [JsonProperty("latitude")]
        public double latitude { get; set; }

        [JsonProperty("longitude")]
        public double longitude { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("group_id")]
        public long group_id { get; set; }

        [JsonProperty("group_photo")]
        public string group_photo { get; set; }

        [JsonProperty("checkins")]
        public int checkins { get; set; }

        [JsonProperty("updated")]
        public long updated { get; set; }

    }
}
