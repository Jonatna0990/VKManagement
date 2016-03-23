using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKCore.Helpers.Cache
{
    /// <summary>
    /// StorageHelper интерфейс
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStorageHelper<T>
    {
        /// <summary>
        /// удаление файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteAsync(string fileName);

        /// <summary>
        /// Сохранение файла
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task SaveAsync(T Obj, string fileName);

        /// <summary>
        /// загрузка объектов из файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<T> LoadAsync(string fileName);

        /// <summary>
        /// Удаление всех файлов из указанной директории
        /// </summary>
        /// <returns></returns>
        Task DeleteAllFiles();
    }
}
