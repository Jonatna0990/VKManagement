using System;

namespace VKCore.Converters.DurationConverter
{
    public static class DurationConvert
    {
        public static string GetDuration(double duration)
        {
            try
            {
                TimeSpan g = TimeSpan.FromSeconds(duration);
                if (g.Hours < 1)
                    return string.Format("{0:00}:{1:00}", g.Minutes, g.Seconds);
                else return string.Format("{0:00}:{1:00}:{2:00}", g.Hours, g.Minutes, g.Seconds);
            }
            catch (Exception)
            {

                return "";
            }

        }
        public static string Convert(TimeSpan args)
        {
            var timeSpan = args;
            if (timeSpan.Hours > 0)
                return timeSpan.ToString("h\\:mm\\:ss");
            return timeSpan.ToString("m\\:ss");
        }
    }
}
