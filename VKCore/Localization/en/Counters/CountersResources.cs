using Windows.ApplicationModel.Resources;

namespace VKCore.Localization.en.Counters
{
    public class CountersResources
    {
        public static string audio_null
        {
            get
            {
                return GetLocalizedString("audio_null");
            }
        }
        public static string GetLocalizedString(string key)
        {
            var rl = ResourceLoader.GetForCurrentView("VKCore/CountersResources");
            return rl.GetString(key);
        }
    }
}
