using LastFmLib.Core;

namespace LastFmLib
{
    public class LastFm
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        private LastFmArtistRequest _artist;
        private LastFmTrackRequest _track;
        public LastFmArtistRequest Artist
        {
            get
            {
                if (_artist == null)
                    _artist = new LastFmArtistRequest(this);

                return _artist;
            }
        }

        internal string ApiKey
        {
            get { return _apiKey; }
        }

        internal string ApiSecret
        {
            get { return _apiSecret; }
        }



        public LastFmTrackRequest Track
        {
            get
            {
                if (_track == null)
                    _track = new LastFmTrackRequest(this);

                return _track;
            }
        }




        public string Lang { get; set; }

        public string SessionKey { get; set; }

        public LastFm(string apiKey, string apiSecret, string lang = null)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            Lang = lang;
        }
    }
}
