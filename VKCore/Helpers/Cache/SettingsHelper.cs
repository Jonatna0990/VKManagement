using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VKCore.Helpers.Cache
{
    /// <summary>
    /// Settings helper for compatibility between Windows Phone and Windows 8
    /// </summary>
    public static class SettingsHelper
    {

        /// <summary>
        /// Установка значения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(string key, T value)
        {

            ApplicationData.Current.LocalSettings.Values[key] = value;

        }


        /// <summary>
        /// Проверка существования ключа
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            bool isContains = false;

            isContains = ApplicationData.Current.LocalSettings.Values.Keys.Contains(key);

            return isContains;
        }


        /// <summary>
        /// Получает значения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            T value = default(T);

            value = (T)ApplicationData.Current.LocalSettings.Values[key];

            return value;
        }


        /// <summary>
        /// Получает значения по указанному типу и ключу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T Get<T>(string key, T defaultValue)
        {
            bool isContains = SettingsHelper.Contains(key);
            if (!isContains)
            {
                return defaultValue;
            }
            return Get<T>(key);
        }

        /// <summary>
        /// Удаляет данные из хранилища 
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {

            ApplicationData.Current.LocalSettings.Values.Remove(key);

        }
    }
}
