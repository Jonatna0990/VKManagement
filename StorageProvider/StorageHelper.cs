using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace StorageProvider
{
    public enum CacheType
    {
        Audio, Collection, Image
    }

    public enum DownloadingState
    {
        Downloaded,
        NoDownloaded,
        Donwloading,
        Cancel,
        Error
    }
    public static class StorageHelper
    {
        public const string ImageCacheFolder = "_imagecache";
        public const string CollectionCacheFolder = "_collectioncache";
        public const string AudioCacheFolder = "_audiocache";


        public static string GetCacheFolder(CacheType type)
        {
            string folder = "";
            switch (type)
            {
                case CacheType.Audio:
                    folder = AudioCacheFolder;
                    break;
                case CacheType.Collection:
                    folder = CollectionCacheFolder;
                    break;
                case CacheType.Image:
                    folder = ImageCacheFolder;
                    break;
            }
            return folder;

        }
        public static async Task<bool> IsMemomryAvailable(StorageFile file)
        {

            var a = await GetFreeSpace();
            var b = await GetFileSize(file);
            return b < 200000000 && a > 400000000;
        }

        public static async Task<bool> IsMemomryAvailable(long file_size)
        {
            var a = await GetFreeSpace();
            return file_size < 200000000 && a > 400000000;
        }

        public static async Task<bool> IsMemomryAvailable(string url)
        {
            var a = await Download(url);
            return false;
        }

        public static async Task<StorageFile> FileFromUrl(string url, CacheType type)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(GetCacheFolder(type), CreationCollisionOption.OpenIfExists);

            string key = GenerateKey(url);

            StorageFile file = null;

            try
            {
                file = await cacheFolder.GetFileAsync(key);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("File " + key + " is not cached");

                byte[] bytes = await Download(url);
                Debug.WriteLine(GetSizeString(Convert.ToUInt64(bytes.Length)));

                file = await cacheFolder.CreateFileAsync(key, CreationCollisionOption.GenerateUniqueName);

                await FileIO.WriteBytesAsync(file, bytes);
            }

            return file;
        }

        public static async Task<StorageFile> DownloadFileWithProgress(string url, Action<long> progressCallback, CacheType type)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            StorageFolder cacheFolder =
                await localFolder.CreateFolderAsync(GetCacheFolder(type), CreationCollisionOption.OpenIfExists);

            string key = GenerateKey(url);
            StorageFile path = null;
            StorageFile file = null;

            try
            {
                file = await cacheFolder.GetFileAsync(key);
                Debug.WriteLine("File " + key + " already cached");
                path = file;
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("File " + key + " is not cached");

                byte[] bytes = await Download(url);
                if (bytes != null)
                {
                    Debug.WriteLine(GetSizeString(Convert.ToUInt64(bytes.Length)));

                    file = await cacheFolder.CreateFileAsync(key, CreationCollisionOption.GenerateUniqueName);
                    await FileIO.WriteBytesAsync(file, bytes);
                    Stream stream = new MemoryStream(bytes);
                    var istream = stream.AsInputStream();

                    using (var reader = new DataReader(istream))
                    {
                        using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                        {
                            using (IOutputStream outputStream = fileStream.GetOutputStreamAt(0))
                            {
                                using (DataWriter writer = new DataWriter(outputStream))
                                {
                                    long writtenBytes = 0;
                                    const int bufferSize = 8192;

                                    uint loadedBytes = 0;
                                    while ((loadedBytes = (await reader.LoadAsync(bufferSize))) > 0) //!!!
                                    {
                                        IBuffer buffer = reader.ReadBuffer(loadedBytes);
                                        writer.WriteBuffer(buffer);
                                        uint tmpWritten = await writer.StoreAsync(); //!!!
                                        writtenBytes += tmpWritten;
                                        progressCallback.Invoke(writtenBytes * 100 / bytes.Length);
                                    }
                                }
                            }
                        }
                    }
                }
                if (file != null) path = file;
            }
            return path;
        }

        public static string GenerateKey(string data)
        {
            HashAlgorithmProvider sha1 = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            IBuffer bytesBuffer = CryptographicBuffer.CreateFromByteArray(bytes);
            IBuffer hashBuffer = sha1.HashData(bytesBuffer);

            return CryptographicBuffer.EncodeToHexString(hashBuffer);
        }

        public static async Task<bool> FileExists(string url, CacheType type)
        {
            string path = "";
            bool exists = false;
            switch (type)
            {
                case CacheType.Audio:
                    path = AudioCacheFolder;
                    break;
                case CacheType.Collection:
                    path = CollectionCacheFolder;
                    break;
                case CacheType.Image:
                    path = ImageCacheFolder;
                    break;
            }
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(path, CreationCollisionOption.OpenIfExists);
            string key = GenerateKey(url);
            StorageFile file = null;

            try
            {
                file = await cacheFolder.GetFileAsync(key);
                exists = true;
            }
            catch (FileNotFoundException)
            {

            }
            return exists;


        }
        public static Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            return task.IsCompleted
                ? task
                : task.ContinueWith(
                    completedTask => completedTask.GetAwaiter().GetResult(),
                    cancellationToken,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }

        public static async Task<T> WithWaitCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();

            using (cancellationToken.Register(
                        s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs))
                if (task != await Task.WhenAny(task, tcs.Task))
                    throw new OperationCanceledException(cancellationToken);

            return await task;
        }
        public static async Task<ulong> GetFileSize(StorageFile storageFile)
        {
            BasicProperties pro = await storageFile.GetBasicPropertiesAsync();
            return pro.Size;
        }
        public static async Task<byte[]> Download(string url)
        {
            byte[] bytes = null;
            try
            {
                Uri uri = new Uri(url);
                HttpClient httpClient = new HttpClient();
                bytes = await httpClient.GetByteArrayAsync(uri);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }

            return bytes;

        }
        public static async Task<UInt64> GetFreeSpace()
        {

            StorageFolder local = ApplicationData.Current.LocalFolder;
            var retrivedProperties = await local.Properties.RetrievePropertiesAsync(new string[] { "System.FreeSpace" });
            return (UInt64)retrivedProperties["System.FreeSpace"];
        }
        public static string GetSizeString(ulong sizeInB, double promoteLimit = 1024, double decimalLimit = 10, string separator = " ")
        {
            if (sizeInB < promoteLimit)
                return string.Format("{0}{1}B", sizeInB, separator);

            var sizeInKB = sizeInB / 1024.0;

            if (sizeInKB < decimalLimit)
                return string.Format("{0:F1}{1}KB", sizeInKB, separator);

            if (sizeInKB < promoteLimit)
                return string.Format("{0:F0}{1}KB", sizeInKB, separator);

            var sizeInMB = sizeInKB / 1024.0;

            if (sizeInMB < decimalLimit)
                return string.Format("{0:F1}{1}MB", sizeInMB, separator);

            if (sizeInMB < promoteLimit)
                return string.Format("{0:F0}{1}MB", sizeInMB, separator);

            var sizeInGB = sizeInMB / 1024.0;

            if (sizeInGB < decimalLimit)
                return string.Format("{0:F1}{1}GB", sizeInGB, separator);

            if (sizeInGB < promoteLimit)
                return string.Format("{0:F0}{1}GB", sizeInGB, separator);

            var sizeInTB = sizeInGB / 1024.0;

            if (sizeInTB < decimalLimit)
                return string.Format("{0:F1}{1}TB", sizeInTB, separator);

            return string.Format("{0:F0}{1}TB", sizeInTB, separator);
        }

        public static void DeleteAllCacheFiles()
        {
            DeleteImagesCacheFiles();
            DeleteCollectionCacheFiles();
            DeleteAudioCacheFiles();
        }

        public static async void DeleteImagesCacheFiles()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(ImageCacheFolder, CreationCollisionOption.OpenIfExists);
            await cacheFolder.DeleteAsync();

        }

        public static async void DeleteCollectionCacheFiles()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(CollectionCacheFolder, CreationCollisionOption.OpenIfExists);
            await cacheFolder.DeleteAsync();
        }

        public static async void DeleteAudioCacheFiles()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder cacheFolder = await localFolder.CreateFolderAsync(AudioCacheFolder, CreationCollisionOption.OpenIfExists);
            await cacheFolder.DeleteAsync();
        }
    }
}
