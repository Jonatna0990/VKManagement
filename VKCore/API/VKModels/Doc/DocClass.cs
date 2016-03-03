using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VKCore.Helpers.Files;

namespace VKCore.API.VKModels.Doc
{
    public class DocClass : ViewModelBase
    {
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