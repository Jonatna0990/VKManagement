using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace LastFmLib.Error
{
    public class LastFmLoginException : Exception
    {
    }
    internal static class LastFmErrorProcessor
    {
        public static bool ProcessError(JToken response)
        {
            if (response["error"] != null)
            {
                Debug.WriteLine("Last FM: " + response["message"].Value<string>());

                switch (response["error"].Value<string>())
                {
                    case "9":
                    case "4": //login error
                        throw new LastFmLoginException();
                    case "6": //artist not found
                        return false;
                }

                return false;
            }

            return true;
        }
    }
}
