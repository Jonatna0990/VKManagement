﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Groups.Admin.Converters
{
    public class AdminRoleConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {

            if (value != null)
            {
                switch (value.ToString())
                {
                    case "creator":
                        return "Создатель";
                    case "moderator":
                        return "Модератор";
                    case "editor":
                        return "Редактор";
                    case "administrator":
                        return "Администратор";
                }
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
