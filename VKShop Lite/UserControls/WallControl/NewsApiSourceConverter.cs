using System;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Wall;

namespace VKShop_Lite.UserControls.WallControl
{
    public class NewsApiSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var can = value as PostSource;
            if (can != null)
            {
                if (can.platform != null)
                {
                    if (can.platform == "android") return @"ms-appx:///Icons/Dark/OnlineApp/appbar.os.android.png";
                    if (can.platform == "iphone") return @"ms-appx:///Icons/Dark/OnlineApp/appbar.social.apple.png";
                    if (can.platform == "iphone") return @"ms-appx:///Icons/Dark/OnlineApp/appbar.tablet.windows.png";
                }
                else
                {
                    if (can.type != null)
                    {
                        if (can.type == "api") return @"ms-appx:///Icons/Dark/Menu/appbar.settings.png";
                    }
                }
                return null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}

