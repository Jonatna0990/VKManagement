using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKCore.API.VKModels.User
{
    /// <summary>
    /// Получает путь картинки для отображения устройства, с помощью которого пользователь в сети
    /// </summary>
    public static class SetOnlineApp
    {
        public static ObservableCollection<UserClass> SetOnlineApplication(ObservableCollection<UserClass> users)
        {
            if (users == null) return null;

            foreach (var t in users)
            {
                SetApplication(t);
            }
            return users;


        }
        public static void SetApplication(UserClass user)
        {
            if (user.Online != 0)
            {
                switch (user.online_app)
                {
                    case 3502561: user.OnlineApp = VKAppOnline.WP; break;
                    case 3140623: user.OnlineApp = VKAppOnline.IPhone; break;
                    case 3682744: user.OnlineApp = VKAppOnline.IPad; break;
                    case 2274003: user.OnlineApp = VKAppOnline.Android; break;
                    default:
                        {
                            user.OnlineApp = user.online_mobile != null ? VKAppOnline.Mobile : VKAppOnline.Desktop;
                        }
                        break;

                }
            }
            else user.OnlineApp = VKAppOnline.Offline;
            user.AppPhotoLight = GetApp(user.OnlineApp, true);
            user.AppPhotoDark = GetApp(user.OnlineApp, false);
        }
        public static string GetApp(VKAppOnline onlineapp, bool Light)
        {
            string app_photo = "";
            switch (onlineapp)
            {

                case VKAppOnline.Android:
                    {

                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.os.android.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.os.android.png";
                        return app_photo;
                    }
                    break;
                case VKAppOnline.Desktop:
                    {
                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.moon.full.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.moon.full.png";
                        return app_photo;
                    }
                    break;
                case VKAppOnline.IPhone:
                    {
                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.social.apple.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.social.apple.png";
                        return app_photo;
                    }
                    break;
                case VKAppOnline.IPad:
                    {
                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.tablet.windows.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.tablet.windows.png";
                        return app_photo;

                    }
                    break;
                case VKAppOnline.Mobile:
                    {
                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.iphone.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.iphone.png";
                        return app_photo;
                    }
                    break;
                case VKAppOnline.Offline:
                    {
                        return "null";
                    }
                    break;
                case VKAppOnline.WP:
                    {
                        app_photo = (Light)
                            ? @"ms-appx:///Icons/Light/OnlineApp/appbar.os.windows.8.png"
                            : @"ms-appx:///Icons/Dark/OnlineApp/appbar.os.windows.8.png";
                        return app_photo;
                    }
                    break;
                default:
                    break;


            }
            return "null";
        }
    }
}