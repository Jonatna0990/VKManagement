﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Helpers.Converters
{
    public class IntToCheckedConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (Convert.ToInt16(value)>0)
            {
                return true;

            }
            return false;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (Convert.ToBoolean(value))
            {
                return 1;
            }
            return 0;
        }
    }
}

