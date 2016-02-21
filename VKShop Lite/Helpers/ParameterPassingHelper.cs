using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace VKShop_Lite.Helpers
{
    public static class ParameterPassingHelper
    {
        private const string KEY = "PARAM";
        public static string GetPagam() 
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(KEY))
            {
                return null;
            }
            String tokenString = ApplicationData.Current.LocalSettings.Values[KEY].ToString();

             return tokenString;

        }
        public static void SetPagam(string value) 
        {
           
            ApplicationData.Current.LocalSettings.Values[KEY] = value;

        }/*
        public static T GetPagam<T>() where T : class
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(KEY))
            {
                return null;
            }
            String tokenString = ApplicationData.Current.LocalSettings.Values[KEY].ToString();

            T account = JsonConvert.DeserializeObject<T>(tokenString);
            return account;

        }
        public static void SetPagam<T>(object value) where T : class
        {
            string output = JsonConvert.SerializeObject(value);
            ApplicationData.Current.LocalSettings.Values[KEY] = output;

        }*/
    }
}
