using Newtonsoft.Json;

namespace VKCore.API.VKModels.Geo
{
    public class GeoClass
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("coordinates")]
        public string coordinates { get; set; }
        [JsonProperty("place")]
        public PlaceClass place { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }

    }
}
