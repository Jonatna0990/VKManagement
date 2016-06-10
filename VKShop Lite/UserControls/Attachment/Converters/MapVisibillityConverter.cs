using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Geo;

namespace VKShop_Lite.UserControls.Attachment.Converters
{
    public class MapVisibillityConverter : IValueConverter
    {
        
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var a = value as GeoClass;
                if(a !=null)
                    return Visibility.Visible;


                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var a = value as GeoClass;
                if (a != null)
                    return Visibility.Visible;


                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}
