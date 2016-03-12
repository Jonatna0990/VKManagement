﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKCore.Helpers
{
    public static class DateTimeHelper
    {

        public static string GetTimeAgoForDialogs(long str)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(str).ToLocalTime();
            DateTime he = dtDateTime;
            string g;
            DateTime today = DateTime.Today;
            int year_dif = today.Year - he.Date.Year;
            var t = year_dif;
            int dif = today.Date.Day - he.Date.Day;
            if (year_dif >= 1)
            {
                g = he.ToString("d MMM yyyy", CultureInfo.CurrentCulture);
                return g;
            }
            else
            {
                if (dif == 0)
                {
                    g = he.ToString("H:mm", CultureInfo.CurrentCulture);
                    return g;

                }
                if (dif == 1)
                {
                    g = "вчера";
                    return g;
                }
                g = he.ToString("d MMM", CultureInfo.CurrentCulture);
                return g;
            }
          
         
        }
        public static string GetTimeAgoForMessages(long str)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(str).ToLocalTime();
            DateTime he = dtDateTime;
            if (he.Date == DateTime.Now.Date.AddDays(-1)) return he.ToString("вчера в H:mm", CultureInfo.CurrentCulture);
            if (he.Date == DateTime.Today.Date) return he.ToString("H:mm", CultureInfo.CurrentCulture);
            if (he.Year - DateTime.Now.Year < 0) return he.ToString("d MMM yyyy в H:mm", CultureInfo.CurrentCulture);
            else return he.ToString("d MMM в H:mm", CultureInfo.CurrentCulture);

        }
        public static string GetTimeAgoForFwdMessages(long str)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(str).ToLocalTime();
            DateTime he = dtDateTime;
            if (he.Date == DateTime.Now.Date.AddDays(-1)) return he.ToString("вчера в H:mm", CultureInfo.CurrentCulture);
            if (he.Date == DateTime.Today.Date) return he.ToString("сегодня в H:mm", CultureInfo.CurrentCulture);
            if (he.Year - DateTime.Now.Year < 0) return he.ToString("d MMM yyyy в H:mm", CultureInfo.CurrentCulture);
            else return he.ToString("d MMM в H:mm", CultureInfo.CurrentCulture);

        }
        public static string LastSeen(int sex, long date)
        {

            string user_sex = "";
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(date).ToLocalTime();
            TimeSpan timeSince = DateTime.Now.Subtract(dtDateTime);
            switch (sex)
            {
                case 0: user_sex = ""; break;
                case 1: user_sex = "была в сети "; break;
                case 2: user_sex = "был в сети "; break;

            }
            if ((Math.Round(timeSince.TotalMinutes) == 1) || (Math.Round(timeSince.TotalMinutes) == 21) || (Math.Round(timeSince.TotalMinutes) == 31) || (Math.Round(timeSince.TotalMinutes) == 41) || (Math.Round(timeSince.TotalMinutes) == 51))
                return string.Format("{0} {1} минуту назад", user_sex, Math.Round(timeSince.TotalMinutes));
            if ((Math.Round(timeSince.TotalMinutes) >= 2 && Math.Round(timeSince.TotalMinutes) <= 4) || (Math.Round(timeSince.TotalMinutes) >= 22 && Math.Round(timeSince.TotalMinutes) <= 24) || (Math.Round(timeSince.TotalMinutes) >= 32 && Math.Round(timeSince.TotalMinutes) <= 34) || (Math.Round(timeSince.TotalMinutes) >= 42 && timeSince.TotalMinutes <= 44) || (Math.Round(timeSince.TotalMinutes) >= 52 && Math.Round(timeSince.TotalSeconds) <= 54))
                return string.Format("{0} {1} минуты назад", user_sex, Math.Round(timeSince.TotalMinutes));
            if ((Math.Round(timeSince.TotalMinutes) >= 5 && Math.Round(timeSince.TotalMinutes) <= 20) || (Math.Round(timeSince.TotalMinutes) >= 25 && Math.Round(timeSince.TotalMinutes) <= 30) || (Math.Round(timeSince.TotalMinutes) >= 35 && Math.Round(timeSince.TotalMinutes) <= 40) || (timeSince.TotalMinutes >= 45 && timeSince.TotalMinutes <= 50) || (Math.Round(timeSince.TotalMinutes) >= 55 && Math.Round(timeSince.TotalMinutes) <= 59))
                return string.Format("{0} {1} минут назад", user_sex, Math.Round(timeSince.TotalMinutes));
            if (timeSince.TotalDays < 1)
                return string.Format("{0} сегодня в {1}", user_sex, dtDateTime.ToString());
            if (timeSince.TotalDays == 1)
                return string.Format("{0} вчера в {1}", user_sex, dtDateTime.ToString());
            else return string.Format(user_sex + " " + dtDateTime.ToString("m") + " в " + dtDateTime.ToString());



        }

    }
}
