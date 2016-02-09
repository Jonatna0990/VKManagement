using System;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using VKCore.Converters.DurationConverter;

namespace VKCore.API.VKModels.Audio
{
  
    public class AudioClass : ViewModelBase
    {
        public AudioClass()
        {
            
        }
        public bool TextEnabled { get {
            if (_lyricsId != null)
            {
                if (lyrics_id > 0) return true;
            }
            return false;
        } }
    

        private bool _isPlaying;
        private int? _noSearch;
        private int _albumId;
        private int _lyricsId;
        private string _url;
        private int _duration;
        private string _title;
        private string _artist;
        private int _ownerId;
        private long _id;
        private  Visibility _playVisibility;

        [JsonProperty("id")]
        public long id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        [JsonProperty("owner_id")]
        public int owner_id
        {
            get { return _ownerId; }
            set { Set(ref _ownerId, value); }
        }

        [JsonProperty("artist")]
        public string artist
        {
            get { return _artist; }
            set { Set(ref _artist, value);  }
        }

        [JsonProperty("title")]
        public string title
        {
            get { return _title; }
            set { Set(ref _title, value);}
        }

        [JsonProperty("duration")]
        public int duration
        {
            get { return _duration; }
            set { Set(ref _duration, value); }
        }

        [JsonProperty("url")]
        public string url
        {
            get { return _url; }
            set { Set(ref _url, value); }
        }

        [JsonProperty("lyrics_id")]
        public int lyrics_id
        {
            get { return _lyricsId; }
            set { Set(ref _lyricsId, value); }
        }

        [JsonProperty("album_id")]
        public int album_id
        {
            get { return _albumId; }
            set { Set(ref _albumId, value); }
        }

        [JsonProperty("no_search")]
        public int? no_search
        {
            get { return _noSearch; }
            set { Set(ref _noSearch, value); }
        }
        
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            set
            {
                _isPlaying = value;
                RaisePropertyChanged("IsPlaying");
               
            }
        }
        public string string_duration { get { return DurationConvert.GetDuration(duration); } }

        

    }
  
}
