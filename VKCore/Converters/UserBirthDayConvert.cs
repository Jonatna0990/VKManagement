using System;
using System.Globalization;

namespace VKCore.Converters.DateTimeConverter
{
    public static class UserBirthDayConvert
    {
        public static string GetDate(string date)
        {
            if ((date.Split('.').Length - 1) > 1)
            {
                DateTime dt = DateTime.ParseExact(date, "d.M.yyyy", CultureInfo.InvariantCulture);
                return dt.ToString("d MMMM yyyy", CultureInfo.CurrentCulture);
            }
            else
            {

                DateTime dt = DateTime.ParseExact(date, "d.M", CultureInfo.InvariantCulture);
                return dt.ToString("d MMMM", CultureInfo.CurrentCulture);
     
            }
         }
    }
}
