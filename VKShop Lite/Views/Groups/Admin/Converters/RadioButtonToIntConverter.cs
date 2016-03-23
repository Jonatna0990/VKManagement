using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Views.Groups.Admin.Converters
{
    public class RadioButtonToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {

            var para = System.Convert.ToInt32(parameter);
            var myChoice = System.Convert.ToInt32(value);
            return para == myChoice;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            var para = System.Convert.ToInt32(parameter);
            var myChoice = System.Convert.ToBoolean(value);
            return para ;
        }
    }
}
