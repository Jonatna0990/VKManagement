using System;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class MessageOutTextBlock : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int t = System.Convert.ToInt16(value);

            if (value != null)
            {
                if (t == 1) return "Вы:";
                return "";
            }
            return "";

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}