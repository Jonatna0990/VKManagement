using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Group;

namespace VKShop_Lite.Views.Groups.Main
{
    public class PageTypeConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var a = value as GroupsClass;
                string privacy = "";
                string type = "";
                if (a.is_closed == 1) privacy = "Закрытая";
                else privacy = "Открытая";

                if (a.group_type == GroupType.page) type = "страница";
                else if (a.group_type == GroupType._event) return "Мероприятие";
                else if (a.group_type == GroupType.@group) type = "группа";


                return string.Format("{0} {1}",privacy,type);

            }
            return "Публичаня страница";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if ((Visibility)value == Visibility.Visible)
            {
                return true;
            }
            return false;
        }
    }
}

