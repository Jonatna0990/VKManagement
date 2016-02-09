using System;
using System.Globalization;

namespace VKCore.Converters.DateTimeConverter
{
    public static class GroupStartDateConvert
    {
        public static string getTimeAgo(long str)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(str).ToLocalTime();
            DateTime he = dtDateTime;
            string g;
            TimeSpan timeSince = DateTime.Now.Subtract(dtDateTime);
            DateTime today = DateTime.Today;
            g = he.ToString("d MMM yyyy в hh:mm", CultureInfo.CurrentCulture);
            return g;
        }
        public static int GetNowDateTime()
        {
            int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTime;
        }
    }
}
