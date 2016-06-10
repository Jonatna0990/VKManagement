using System;

namespace VKShop_Lite.Helpers
{
    public class EnumParser
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
