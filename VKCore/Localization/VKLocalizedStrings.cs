using VKCore.Localization.en.Counters;

namespace VKCore.Localization
{


    public class VKLocalizedStrings
    {
        private static Resources _localizedResources = new Resources();

        private static CountersResources counters = new CountersResources();


        public CountersResources CountersResources
        {
            get { return counters; }
        }
        public Resources LocalizedResources
        {
            get { return _localizedResources; }
        }
    }
}
