using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Main
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {

            if (value != null)
            {
                int a = (int)value;
                if (a > 0) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                int a = (int)value;
                if (a > 0) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}
