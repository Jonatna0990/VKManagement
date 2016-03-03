using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Wall;

namespace VKShop_Lite.UserControls.WallControl
{
    public class SourceImageConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            PostedBy wall = value as PostedBy;
            if (wall != null)
            {
                if (wall.PostedByGroup != null)
                {
                    return wall.PostedByGroup.photo_100;
                }
                else
                {
                    return wall.PostedByUser.photo_100;
                }


            }
            return "";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            PostedBy wall = value as PostedBy;
            if (wall != null)
            {
                if (wall.PostedByGroup != null)
                {
                    return wall.PostedByGroup.photo_100;
                }
                else
                {
                    return wall.PostedByUser.photo_100;
                }


            }
            return "";
        }
    }
}