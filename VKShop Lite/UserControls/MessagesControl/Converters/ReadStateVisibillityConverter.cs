using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKShop_Lite.Helpers;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class ReadStateVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {

                int message = (int)value;
                //не прочитанно
                if (message == 0)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;


            }
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var message = EnumParser.ParseEnum<Visibility>(value.ToString());
                if (message ==  Visibility.Visible)
                {
                    return 0;
                }
                return 1;


            }
            return 0;
        }
    }
}
