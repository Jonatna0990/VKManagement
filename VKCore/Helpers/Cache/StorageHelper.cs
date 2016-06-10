using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;
using Newtonsoft.Json;

namespace VKCore.Helpers.Cache
{
    /// <summary>
    /// Возможные значения хранилища
    /// </summary>
    public enum StorageType
    {

        /// <summary>Local</summary>
        Local,

        /// <summary>Temporary</summary>
        Temporary,
        /// <summary>Roaming</summary>
        Roaming,
   }

    /// <summary>
    /// Тип исполььзуемой сериализации
    /// </summary>
    public enum StorageSerializer
    {
        /// <summary>JSON</summary>
        JSON,
        /// <summary>XML</summary>
        XML
    }

    /// <summary>
    /// Сохранение  JSON объекта в файл
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StorageHelper<T> : IStorageHelper<T>
    {
        private ApplicationData _appData = Windows.Storage.ApplicationData.Current;

        [Obsolete]
        private StorageType _storageType;

        private string _subFolder;
        private StorageSerializer _serializerType;
        private StorageFolder _storageFolder;


        /// <summary>
        /// Устаревший конструктор , будут удалены в будущей версии
        /// </summary>
        /// <param name="StorageType"></param>
        /// <param name="subFolder"></param>
        /// <param name="serializerType"></param>
        [Obsolete]
        public StorageHelper(StorageType StorageType = StorageType.Local, string subFolder = null, StorageSerializer serializerType = StorageSerializer.JSON)
        {
            _storageType = StorageType;
            _subFolder = subFolder;
            _serializerType = serializerType;
        }

        /// <summary>
        /// Конструктор, который принимает в качестве входных данных storageFolder
        /// </summary>
        /// <param name="storageFolder">например: Windows.Storage.ApplicationData.Current.LocalFolder</param>
        /// <param name="subFolder"></param>
        /// <param name="serializerType"></param>
        public StorageHelper(StorageFolder storageFolder, string subFolder = null, StorageSerializer serializerType = StorageSerializer.JSON)
        {
            _storageFolder = storageFolder;
            _subFolder = subFolder;
            _serializerType = serializerType;
        }

        /// <summary>
        /// XML или JSON
        /// </summary>
        /// <returns></returns>
        internal string GetFileExtension()
        {
            switch (_serializerType)
            {
                case StorageSerializer.JSON:
                    return ".json";
                case StorageSerializer.XML:
                    return ".xml";
            }

            return string.Empty;
        }

        /// <summary>
        /// удаление файла
        /// </summary>
        /// <param name="fileName"></param>
        public async Task DeleteAsync(string fileName)
        {
            fileName = fileName + GetFileExtension();
            try
            {
                StorageFolder folder = await GetFolderAsync().ConfigureAwait(false);

                var contains = await folder.ContainsFileAsync(fileName).ConfigureAwait(false);
                if (contains)
                {
                    var file = await folder.GetFileAsync(fileName);
                    await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// сохранение объекта
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="fileName"></param>
        public async Task SaveAsync(T obj, string fileName)
        {

            fileName = fileName + GetFileExtension();
            try
            {
                if (obj != null)
                {
                    //Get file
                    StorageFile file = null;
                    StorageFolder folder = await GetFolderAsync().ConfigureAwait(false);
                    file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);


                    //Serialize object with JSON or XML serializer
                    string storageString = null;
                    switch (_serializerType)
                    {
                        case StorageSerializer.JSON:
                            storageString = JsonConvert.SerializeObject(obj);
                            //Write content to file
                            await FileIO.WriteTextAsync(file, storageString);
                            break;
                        case StorageSerializer.XML:

                            IRandomAccessStream sessionRandomAccess = await file.OpenAsync(FileAccessMode.ReadWrite);
                            IOutputStream sessionOutputStream = sessionRandomAccess.GetOutputStreamAt(0);
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            serializer.Serialize(sessionOutputStream.AsStreamForWrite(), obj);
                            sessionRandomAccess.Dispose();
                            await sessionOutputStream.FlushAsync();
                            sessionOutputStream.Dispose();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// загрузка объектов из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<T> LoadAsync(string fileName)
        {
            fileName = fileName + GetFileExtension();
            try
            {

                StorageFile file = null;
                StorageFolder folder = await GetFolderAsync().ConfigureAwait(false);

                var contains = await folder.ContainsFileAsync(fileName).ConfigureAwait(false);
                if (contains)
                {
                    file = await folder.GetFileAsync(fileName);

                   T result = default(T);

                    switch (_serializerType)
                    {
                        case StorageSerializer.JSON:
                            var data = await FileIO.ReadTextAsync(file);
                            result = JsonConvert.DeserializeObject<T>(data);
                            break;
                        case StorageSerializer.XML:
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            IInputStream sessionInputStream = await file.OpenReadAsync();
                            result = (T)serializer.Deserialize(sessionInputStream.AsStreamForRead());
                            sessionInputStream.Dispose();

                            break;
                    }

                    return result;
                }
                else
                {
                    return default(T);
                }

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Получение диектории
        /// </summary>
        /// <returns></returns>
        public async Task<StorageFolder> GetFolderAsync()
        {

            StorageFolder folder;

            if (_storageFolder != null)
                folder = _storageFolder;
            else
            {
                //This part is obsolete and will be removed
                switch (_storageType)
                {
                    case StorageType.Local:
                        folder = _appData.LocalFolder;
                        break;

                    case StorageType.Roaming:
                        folder = _appData.RoamingFolder;
                        break;
                    case StorageType.Temporary:
                        folder = _appData.TemporaryFolder;
                        break;

                    default:
                        throw new Exception(String.Format("Unknown StorageType: {0}", _storageType));
                }
            }

            if (!string.IsNullOrEmpty(_subFolder))
            {
                folder = await folder.CreateFolderAsync(_subFolder, CreationCollisionOption.OpenIfExists);
            }

            return folder;
        }

        /// <summary>
        /// Удаление всех файлов в указанной диектории
        /// </summary>
        /// <returns></returns>
        public async Task DeleteAllFiles()
        {
            StorageFolder folder = await GetFolderAsync().ConfigureAwait(false);

            try
            {
                await folder.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        /// <summary>
        /// Очистка кэша
        /// </summary>
        /// <returns></returns>
        public static Task ClearAll(StorageFolder storageFolder)
        {
            return Task.Run(async () =>
            {
                StorageHelper<object> storage = new StorageHelper<object>(storageFolder);
                var folder = await storage.GetFolderAsync().ConfigureAwait(false);

                //Удаление поддиректорий
                foreach (var sub in await folder.GetFoldersAsync())
                {
                    try
                    {
                        await sub.DeleteAsync(StorageDeleteOption.PermanentDelete);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }

                //Удаление файлов
                foreach (var file in await folder.GetFilesAsync())
                {
                    try
                    {
                        await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    }
                }
            });
        }

    }
}
