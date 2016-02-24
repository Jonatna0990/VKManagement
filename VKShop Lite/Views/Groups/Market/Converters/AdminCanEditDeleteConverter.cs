using System;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Groups.Market.Converters
{
    public class AdminCanEditDeleteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                int a = (int)value;
                if (a > 1) return true;
                return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                int a = (int)value;
                if (a > 2) return true;
                return false;
            }
            return false;
        }
    }
}