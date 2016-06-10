using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;

namespace VKCore.Helpers.Cache
{
    public static class StorageExtensions
    {
        /// <summary>
        /// Метод преобразования Uri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string ToCacheKey(this Uri uri)
        {
            if (uri == null)
                throw new ArgumentNullException("uri");

            string hashedResult = uri.GetHashCode().ToString();
            string pattern = "[\\~#%&*{}/:<>?|\"-]";
            string replacement = " ";

            Regex regEx = new Regex(pattern);
            string sanitized = Regex.Replace(regEx.Replace(hashedResult, replacement), @"\s+", "_");

            return sanitized;
        }


        /// <summary>
        /// Метод, проверяющий существование директории
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static async Task<bool> ContainsFileAsync(this StorageFolder folder, string fileName)
        {
           
            //return (await folder.GetFilesAsync()).Where(file => file.Name == fileName).Any();
            
            //#if NETFX_CORE
            //        var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);
            //        return item != null;
            //#endif

            try
            {
                await folder.GetFileAsync(fileName);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
