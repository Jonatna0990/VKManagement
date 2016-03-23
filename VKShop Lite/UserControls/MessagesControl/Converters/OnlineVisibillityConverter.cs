using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class OnlineVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (parameter != null)
                {
                    if ((string)parameter == "invert")
                    {
                        if (value.ToString() == "0") return Visibility.Visible;
                        else return Visibility.Collapsed;
                    }
                }
                if (value.ToString() == "1") return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            return Visibility.Collapsed; ;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                if (parameter != null)
                {
                    if ((string)parameter == "invert")
                    {
                        if (value.ToString() == "0") return Visibility.Visible;
                        else return Visibility.Collapsed;
                    }

                }
                if (value.ToString() == "1") return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            return Visibility.Collapsed; ;
        }
    }
}
