using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LastFmLib.Error;

namespace LastFmLib.Core
{
    public class LastFmTrackRequest
    {
        private readonly LastFm _lastFm;

        public LastFmTrackRequest(LastFm lastFm)
        {
            _lastFm = lastFm;
        }

        public async Task<LastFmTrack> GetInfo(string title, string artist, bool autoCorrect = true, string mbid = null)
        {
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(mbid))
                parameters.Add("mbid", mbid);
            else
            {
                parameters.Add("artist", artist);
                parameters.Add("track", title);
            }

            if (autoCorrect)
                parameters.Add("autocorrect", "1");

            parameters.Add("api_key", _lastFm.ApiKey);

            var response = await new CoreRequest(new Uri(LastFmConst.MethodBase + "track.getInfo"), parameters).Execute();

            bool result = LastFmErrorProcessor.ProcessError(response);
            if (!result) return null;

            if (response["track"] != null)
            {
                return LastFmTrack.FromJson(response["track"]);
            }

            return null;
        }


    }
}
