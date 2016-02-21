using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace VKShop_Lite.Helpers.Files
{
    public class FilesHelper
    {
        private static readonly IEnumerable<string> SupportedImageFileTypes = new List<string> { ".jpeg", ".jpg", ".png" };

        public static async Task<StorageFile> GetImageFiles()
        {
            
            var fop = new FileOpenPicker();
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.SuggestedStartLocation = PickerLocationId.Desktop;

            foreach (var fileType in SupportedImageFileTypes.ToList())
            {
                fop.FileTypeFilter.Add(fileType);
            }
            var a = await fop.PickSingleFileAsync();
            return a;
        }

        public static async Task<StorageFolder> GetFolders()
        {
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            folderPicker.FileTypeFilter.Add(".jpg");
            folderPicker.FileTypeFilter.Add(".jpeg");
            folderPicker.FileTypeFilter.Add(".png");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            return folder;
        }
        public static async Task<BitmapImage> LoadImage(StorageFile file)
        {
            BitmapImage bitmapImage = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
            bitmapImage.SetSource(stream);
            return bitmapImage;

        }
    }
}
