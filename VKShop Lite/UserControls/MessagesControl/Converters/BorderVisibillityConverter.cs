using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class BorderVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value > 0)
            {
                return Visibility.Visible;

            }
            return Visibility.Collapsed; ;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((int)value > 0)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed; ;
        }
    }

}
