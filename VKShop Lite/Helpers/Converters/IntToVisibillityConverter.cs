using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Helpers.Converters
{
    public class IntToVisibillityConverter : IValueConverter
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
