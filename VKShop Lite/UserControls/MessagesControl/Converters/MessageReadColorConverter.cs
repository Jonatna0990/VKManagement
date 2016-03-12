using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class MessageReadColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int t = System.Convert.ToInt16(value);

            if (value != null)
            {
                if (t == 1) return new SolidColorBrush(new Color() { A = 255, B = 114, G = 114, R = 114 });
                return new SolidColorBrush(new Color() { A = 255, B = 210, G = 157, R = 67 });
            }
            return new SolidColorBrush(new Color() { A = 255, B = 114, G = 114, R = 114 });

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int t = System.Convert.ToInt16(value);

            if (value != null)
            {
                if (t == 1) return new SolidColorBrush(new Color() { A = 255, B = 114, G = 114, R = 114 });
                return new SolidColorBrush(new Color() { A = 255, B = 210, G = 157, R = 67 });
            }
            return new SolidColorBrush(new Color() { A = 255, B = 114, G = 114, R = 114 });
        }
    }
}