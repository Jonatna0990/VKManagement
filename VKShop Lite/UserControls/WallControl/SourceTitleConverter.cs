using System;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Wall;

namespace VKShop_Lite.UserControls.WallControl
{
    public class SourceTitleConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {

            PostedBy wall = value as PostedBy;
            if (wall != null)
            {
                if (wall.PostedByGroup != null)
                {
                    return wall.PostedByGroup.name;
                }
                else
                {
                    return wall.PostedByUser.full_name;
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
                    return wall.PostedByGroup.name;
                }
                else
                {
                    return wall.PostedByUser.full_name;
                }


            }
            return "";
        }
    }
}

