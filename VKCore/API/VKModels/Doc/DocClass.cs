using Newtonsoft.Json;
using GalaSoft.MvvmLight;
using VKCore.Helpers.Files;

namespace VKCore.API.VKModels.Doc
{
    public class DocClass : ViewModelBase
    {
        private bool _isLoaded = true;
        private long _size;
        private string _title;

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("owner_id")]
        public int owner_id { get; set; }

        [JsonProperty("title")]
        public string title
        {
            get { return _title; }
            set { _title = value;  RaisePropertyChanged("title");}
        }

        [JsonProperty("size")]
        public long size
        {
            get { return _size; }
            set { _size = value; StringSize = FilesHelper.SizeSuffix(value); }
        }
        public bool is_loaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("is_loaded"); }
        }

        [JsonProperty("ext")]
        public string ext { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("photo_100")]
        public string photo_100 { get; set; }

        [JsonProperty("photo_130")]
        public string photo_130 { get; set; }

        [JsonProperty("access_key")]
        public string access_key { get; set; }
        public string StringSize { get; set; }


    }
}