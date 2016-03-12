using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class ReadStateVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                int message = (int)value;
                //не прочитанно
                if (message == 0)
                {
                    return "M0,6 6,12 16,0";
                }
                else
                {
                    return "M0,6 6,12 16,0 M5,6 11,12 21,0 ";

                }


            }
            return "";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                int message = (int)value;
                //не прочитанно
                if (message == 0)
                {
                    return "M0,6 6,12 16,0";
                }
                else
                {
                    return "M0,6 6,12 16,0 M5,6 11,12 21,0 ";

                }


            }
            return "";
        }
    }
}
