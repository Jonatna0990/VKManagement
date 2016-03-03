using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using VKCore.API.VKModels.Attachment;

namespace VKCore.Helpers.Files
{
    
    public class FilesHelper
    {
  
        private static readonly IEnumerable<string> SupportedImageFileTypes = new List<string> { ".jpeg", ".jpg", ".png" };
        private static readonly IEnumerable<string> SupportedVideoFileTypes = new List<string> { ".avi", ".mp4" };
        private static readonly IEnumerable<string> SupportedDocFileTypes = new List<string> { ".doc",".docx",".pdf",".djvu",".rtf", ".gif", ".txt", ".rar",".zip",".xls",".xlsx",".ppt",".pptx" };
        private static readonly IEnumerable<string> SupportedAudioFileTypes = new List<string> { ".mp3"};
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
        public static async Task<StorageFile> GetDocFiles()
        {

            var fop = new FileOpenPicker();
            fop.ViewMode = PickerViewMode.Thumbnail;
            fop.SuggestedStartLocation = PickerLocationId.Desktop;

            foreach (var fileType in SupportedDocFileTypes.ToList())
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
        public static AttachType GetAttachType(StorageFile file)
        {
            if (file != null)
            {

                bool found_photo = SupportedImageFileTypes.Contains(file.FileType);
                if(found_photo) return AttachType.Photo;

                bool found_video = SupportedVideoFileTypes.Contains(file.FileType);
                if (found_video) return AttachType.Video;

                bool found_doc = SupportedDocFileTypes.Contains(file.FileType);
                if (found_doc) return AttachType.Doc;

                bool found_audio = SupportedAudioFileTypes.Contains(file.FileType);
                if (found_audio) return AttachType.Audio;
                
            } 
            return AttachType.Unknown;
        }
        static readonly string[] SizeSuffixes = { "байт", "кб", "мб", "гб", "тб" };
        public static string SizeSuffix(long value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }
        public static string GetFileSize(BasicProperties file_size)
        {
            if (file_size != null)
            {
               
                string[] sizes = { "B", "KB", "MB", "GB" };
                var len = file_size.Size;
                int order = 0;
                while (len >= 1024 && order + 1 < sizes.Length)
                {
                    order++;
                    len = len / 1024;
                }
                
                string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                return result;
            }
            return "";
          

        }

        public static async void DownloadDocFile(string url)
        {
            string uriToLaunch = url;

            // Create a Uri object from a URI string 
            var uri = new Uri(uriToLaunch);
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }

        }
    }
}
