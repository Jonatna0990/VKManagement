using System;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Helpers.Converters
{
    public class ZeroToEmptyStringConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (Convert.ToInt16(value)==0)
            {
                return "";
            }
            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            return value;
        }
    }
}
