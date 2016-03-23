using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Helpers.Converters
{
    public class IntToVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            var a = Convert.ToInt32(value);
            if (a > 0)
            {
                return Visibility.Visible;

            }
            return Visibility.Collapsed; 
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var a = (Visibility)value;
            if (a == Visibility.Visible)
            {
                return 1;

            }
            return 0;
        }
    }
}
