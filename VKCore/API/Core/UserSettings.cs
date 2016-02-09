using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace VKCore.AppSettings
{
    public static class UserSettings
    {
        #region Получение данных
        public static string GetAccessToken()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey("access_token"))
            {
                return localSettings.Values["access_token"].ToString();
            }
            return null;
            
        }

        public static string GetSetting(string name)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey(name))
            {
                return localSettings.Values[name].ToString();
            }
            return "";

        }

        public static string CheckLongPollConnect()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey("long_poll_connect"))
            {
                return localSettings.Values["long_poll_connect"].ToString();
            }
            return "";


        }
        public static string GetUserId()
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey("user_id"))
            {
                return localSettings.Values["user_id"].ToString();

            }
            else
            {

                return null;
            }

        }
        public static string GetUserName()
        {
            return null;

        }
        public static BitmapImage GetUserPhoto()
        {
            return null;

        }
        public static bool UserIsDeactivated()
        {

            return false;
        }
        #endregion
        #region Изменение данных

        public static void SetSetting(string key, string value)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            if (localSettings.Values.ContainsKey(key))
            {
                 localSettings.Values[key] = value;
            }
            else
            {
                localSettings.Values.Add(key,value);
            }

        }

        public static Image SetUserPhoto(string photo_url)
        {

            return null;
        }
        #endregion
    }
}
