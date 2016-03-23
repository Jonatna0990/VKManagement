using Newtonsoft.Json;
using VKCore.API.VKModels.VKList;

namespace VKCore.API.VKModels.Photo
{
    public class CountersAlbumClass
    {
        [JsonProperty("all_photos")]
        public VKCollection<PhotoClass> all_photos { get; set; }
        [JsonProperty("albums")]
        public VKCollection<PhotoAlbumsClass> albums { get; set; }
    }
    public class PhotoAlbumsClass
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("thumb_id")]
        public int thumb_id { get; set; }
        [JsonProperty("owner_id")]
        public int owner_id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("size")]
        public int size { get; set; }
        [JsonProperty("thumb_src")]
        public string thumb_src { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("created")]
        public int? created { get; set; }
        [JsonProperty("updated")]
        public int? updated { get; set; }
        [JsonProperty("can_upload")]
        public int? can_upload { get; set; }
        [JsonProperty("thumb_is_last")]
        public int? thumb_is_last { get; set; }
    }
}
