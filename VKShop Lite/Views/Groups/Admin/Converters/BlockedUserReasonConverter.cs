using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Groups.Admin.Converters
{
    public class BlockedUserReasonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {

            if (value != null)
            {
                int a = System.Convert.ToInt16(value);
                switch (a)
                {
                    case 0:
                        return "Другое";
                    case 1:
                        return "Спам";
                    case 2:
                        return "Оскорбление участников";
                    case 3:
                        return "Нецензурные выражения";
                    case 4:
                        return "Сообщения не по теме";
                    default:
                        break;
                }
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
