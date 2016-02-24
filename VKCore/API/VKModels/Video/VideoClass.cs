using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKCore.Converters.DurationConverter;

namespace VKCore.API.VKModels.Video
{
    public class VideoParamClass
    {
        public long owner_id { get; set; }
        public long video_id { get; set; }
        public string access_key { get; set; }
    
    }
    public class VideoClass
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("owner_id")]
        public int owner_id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("duration")]
        public int duration { get; set; }
        [JsonProperty("link")]
        public string link { get; set; }
        [JsonProperty("photo_130")]
        public string photo_130 { get; set; }
        [JsonProperty("photo_320")]
        public string photo_320 { get; set; }
        [JsonProperty("photo_640")]
        public string photo_640 { get; set; }
        [JsonProperty("files")]
        public Files files { get; set; }
        [JsonProperty("date")]
        public int date { get; set; }
        [JsonProperty("views")]
        public int views { get; set; }
        [JsonProperty("comments")]
        public int comments { get; set; }
        [JsonProperty("player")]
        public string player { get; set; }
        [JsonProperty("can_add")]
        public int can_add { get; set; }
        [JsonProperty("album_id")]
        public int album_id { get; set; }
        [JsonProperty("access_key")]
        public string access_key { get; set; }
        public string photoMax
        {
            get
            {

                if (!string.IsNullOrEmpty(photo_640)) return photo_640;
                else if (!string.IsNullOrEmpty(photo_320)) return photo_320;
                else return photo_130;

            }
        }
        public string _duration
        {

            get
            {
                return DurationConvert.GetDuration(duration);

            }
        }

    }
    public class Files
    {
        public string mp4_240 { get; set; }
        public string mp4_360 { get; set; }
        public string mp4_480 { get; set; }
        public string mp4_720 { get; set; }
    }


}
