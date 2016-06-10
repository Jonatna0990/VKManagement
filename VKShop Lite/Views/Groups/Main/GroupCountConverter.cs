using System;
using Windows.UI.Xaml.Data;
using VKShop_Lite.Helpers;

namespace VKShop_Lite.Views.Groups.Main
{
    public class GroupCountConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                long a = Convert.ToInt64(value);
                if (a > 0)
                {
                    return CountNum.GetDeclension(a, "группа", "группы", "групп");

                }
            }

            return "";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                long a = Convert.ToInt64(value);
                if (a > 0)
                {
                    return CountNum.GetDeclension(a, "группа", "группы", "групп");

                }
            }

            return "";
        }
    }
}