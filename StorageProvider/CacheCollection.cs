using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace StorageProvider
{
    /// <summary>
    /// Класс для кэширования списков типа ObservableCollection<T>
    /// </summary>

    public class CacheCollection
    {


        public static async void Save<T>(ObservableCollection<T> collection, string name)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(StorageHelper.CollectionCacheFolder, CreationCollisionOption.OpenIfExists);
            string key = StorageHelper.GenerateKey(name);
            StorageFile file = null;

            try
            {
                file = await cacheFolder.GetFileAsync(key);
                var json = JsonConvert.SerializeObject(collection);
                await FileIO.WriteTextAsync(file, json);
                Debug.WriteLine("File " + key + " saved");
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("File " + key + " is not cached");
                file = await cacheFolder.CreateFileAsync(key, CreationCollisionOption.GenerateUniqueName);
                var json = JsonConvert.SerializeObject(collection);
                await FileIO.WriteTextAsync(file, json);
            }


        }

        public static async Task<ObservableCollection<T>> Load<T>(string name)
        {
            ObservableCollection<T> temp = null;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(StorageHelper.CollectionCacheFolder, CreationCollisionOption.OpenIfExists);
            string key = StorageHelper.GenerateKey(name);
            StorageFile file = null;

            try
            {
                file = await cacheFolder.GetFileAsync(key);
                var q = await FileIO.ReadTextAsync(file);
                temp = JsonConvert.DeserializeObject<ObservableCollection<T>>(q);
                Debug.WriteLine("File " + key + " loaded");
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("File " + key + " is not cached");
            }
            return temp;
        }

        public static async void Delete(string name)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(StorageHelper.CollectionCacheFolder, CreationCollisionOption.OpenIfExists);
            string key = StorageHelper.GenerateKey(name);
            StorageFile file = null;
            try
            {
                file = await cacheFolder.GetFileAsync(key);
                await file.DeleteAsync();
                Debug.WriteLine("File " + key + " deleted");


            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("File " + key + "  not deleted");
            }

        }


    }
}
