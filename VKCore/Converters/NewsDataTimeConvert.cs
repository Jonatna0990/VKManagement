using System;
using System.Globalization;

namespace VKCore.Converters.DateTimeConverter
{
    public static class NewsDataTimeConvert
    {
        public static string getTimeAgo(long unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            TimeSpan timeSince = DateTime.Now.Subtract(dtDateTime);
            if (timeSince.TotalSeconds < 1)
                return "только что";
            else if ((Math.Round(timeSince.TotalSeconds) == 1) || (Math.Round(timeSince.TotalSeconds) == 21) || (Math.Round(timeSince.TotalSeconds) == 31) || (Math.Round(timeSince.TotalSeconds) == 41) || (Math.Round(timeSince.TotalSeconds) == 51))
                return string.Format("{0} секунду назад", Math.Round(timeSince.TotalSeconds));
            else if ((Math.Round(timeSince.TotalSeconds) >= 2 && Math.Round(timeSince.TotalSeconds) <= 4) || (Math.Round(timeSince.TotalSeconds) >= 22 && Math.Round(timeSince.TotalSeconds) <= 24) || (Math.Round(timeSince.TotalSeconds) >= 32 && Math.Round(timeSince.TotalSeconds) <= 34) || (Math.Round(timeSince.TotalSeconds) >= 42 && timeSince.TotalSeconds <= 44) || (Math.Round(timeSince.TotalSeconds) >= 52 && Math.Round(timeSince.TotalSeconds) <= 54))
                return string.Format("{0} секунды назад", Math.Round(timeSince.TotalSeconds));
            else if ((Math.Round(timeSince.TotalSeconds) >= 5 && Math.Round(timeSince.TotalSeconds) <= 20) || (Math.Round(timeSince.TotalSeconds) >= 25 && Math.Round(timeSince.TotalSeconds) <= 30) || (Math.Round(timeSince.TotalSeconds) >= 35 && Math.Round(timeSince.TotalSeconds) <= 40) || (timeSince.TotalSeconds >= 45 && timeSince.TotalSeconds <= 50) || (Math.Round(timeSince.TotalSeconds) >= 55 && Math.Round(timeSince.TotalSeconds) <= 59))
                return string.Format("{0} секунд назад", Math.Round(timeSince.TotalSeconds));
            else if (Math.Round(timeSince.TotalMinutes) < 2)
                return string.Format("{0} минуту назад", timeSince.Minutes);
            else if (Math.Round(timeSince.TotalMinutes) < 5 && (Math.Round(timeSince.TotalMinutes) > 2))
                return string.Format("{0} минуты назад", timeSince.Minutes);
            else if (Math.Round(timeSince.TotalMinutes) < 60)
                return string.Format("{0} минут назад", timeSince.Minutes);
            else if (Math.Round(timeSince.TotalMinutes) < 120)
                return "час назад";
            else if (Math.Round(timeSince.TotalHours) < 24 && Math.Round(timeSince.TotalHours) >= 5)
                 return dtDateTime.ToString("сегодня в H:mm", CultureInfo.CurrentCulture);
            else if (Math.Round(timeSince.TotalDays) == 1)
                 return dtDateTime.ToString("вчера в H:mm", CultureInfo.CurrentCulture);
            else return dtDateTime.ToString("d MMM yyyy в H:mm", CultureInfo.CurrentCulture);
           
        }
       
       
    }
}
