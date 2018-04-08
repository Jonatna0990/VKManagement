using System.IO;
using System.Xml.Serialization;
using Windows.Storage;

namespace StorageProvider
{
    public  static class StorageSettings
    {
        public static string Serialize(object obj)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            using (var sw = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sw);
            }
        }
        public static string GetSetting(string key)
        {
            var settings = ApplicationData.Current.LocalSettings;
            return settings.Values[key].ToString();
        }

        public static T GetSetting<T>(string key) where T : class 
        {
            var settings = ApplicationData.Current.LocalSettings;
            if (IsSettingExists(key))
                 return Deserialize<T>(settings.Values[key].ToString());
             return null;

        }

        public static void SetSetting(string key, string value)
        {
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values[key] = value;

        }
        public static void SetSetting<T>(string key, T value)
        {
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values[key] = Serialize(value);
        }

        public static bool IsSettingExists(string key)
        {
            var settings = ApplicationData.Current.LocalSettings;
            return settings.Values.ContainsKey(key);
        }
     
        public static void RemoveSetting(string key)
        {
            var settings =  ApplicationData.Current.LocalSettings;
            if (IsSettingExists(key))
                 settings.Values.Remove(key);
        }
    }
}
