using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Groups.Market.Converters
{
    public class AdminEditVisibillityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                long a = System.Convert.ToInt64(value);
                if (a > 1) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                long a = System.Convert.ToInt64(value);
                if (a > 1) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}
