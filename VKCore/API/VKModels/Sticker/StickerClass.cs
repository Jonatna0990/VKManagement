using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VKCore.API.VKModels.Sticker
{
    public class StickerClass
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("product_id")]
        public int product_id { get; set; }
        [JsonProperty("photo_64")]
        public string photo_64 { get; set; }
        [JsonProperty("photo_128")]
        public string photo_128 { get; set; }
        [JsonProperty("photo_256")]
        public string photo_256 { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
    }
}
