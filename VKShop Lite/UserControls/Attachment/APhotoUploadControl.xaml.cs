using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using VKCore.API.Core;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Photo;
using VKCore.Util;
using VKShop_Lite.Helpers.Files;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Attachment
{
    public sealed partial class APhotoUploadControl : UserControl
    {
       
        public const string DeleteCommandPropertyName = "DeleteCommand";
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.RegisterAttached(
           DeleteCommandPropertyName,
           typeof(ICommand),
           typeof(APhotoUploadControl),
           new PropertyMetadata(
               null));
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        public APhotoUploadControl(Action<PhotoClass> callbackAction, StorageFile file, UploadType type,  long group_id=0, bool is_main = false, long album_id=0)
        {
            this.InitializeComponent();
            Upload(file,type, callbackAction, is_main, group_id, album_id);
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            DeleteCommand?.Execute(this);
        }

        private void PhotoAlbumUploadRequest(StorageFile file, Action<PhotoClass> callbackAction, long album_id,long group_id)
        {
            VKUploadRequest.CreatePhotoAlbumUploadRequest(album_id,group_id).Dispatch(file, (prog) =>
            {
                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });
            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);
                 
                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });
        }
        private void PhotoMessageUploadRequest(StorageFile file, Action<PhotoClass> callbackAction)
        {
            VKUploadRequest.CreatePhotoMessageUploadRequest().Dispatch(file, (prog) =>
            {


                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });


            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);

                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });
        }
        private void PhotoProfileUploadRequest(StorageFile file, Action<PhotoClass> callbackAction, long owner_id)
        {
            VKUploadRequest.CreatePhotoProfileUploadRequest(owner_id).Dispatch(file, (prog) =>
            {


                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });


            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);

                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });

        }
        private void PhotoWallUploadRequest(StorageFile file, Action<PhotoClass> callbackAction, long owner_id)
        {
            VKUploadRequest.CreatePhotoWallUploadRequest(owner_id).Dispatch(file, (prog) =>
            {


                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });


            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);

                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });
        }
        private void PhotoMarketAlbumUploadRequest(StorageFile file, Action<PhotoClass> callbackAction, long group_id)
        {
            if (group_id == 0) return;
            VKUploadRequest.PhotoMarketCategoryAlbumRequest(group_id).Dispatch(file, (prog) =>
            {
                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });


            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);

                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });

        }
        private void PhotoMarketProductUploadRequest(StorageFile file, Action<PhotoClass> callbackAction, long group_id, bool is_main)
        {
            if (group_id == 0) return;
            VKUploadRequest.PhotoMarketProductUploadRequest(group_id, is_main).Dispatch(file, (prog) =>
            {
                VKExecute.ExecuteOnUIThread(() =>
                {
                    Logger(prog);
                });


            }, s =>
            {
                if (s.ResultCode == VKResultCode.Succeeded)
                {
                    UploadProgress.IsActive = false;
                    callbackAction.Invoke(s.Data);

                }
                else
                {
                    UploadProgress.IsActive = false;
                    AttachText.Text = "ошибка";
                }
                Logger(s.Data);
            });

        }
        private async void Upload(StorageFile file, UploadType type, Action<PhotoClass> callbackAction, bool is_main, long owner_id = 0, long album_id = 0)
        {
            
            if (file != null)
            {
                this.AttachImage.Source = await FilesHelper.LoadImage(file);
                switch (type)
                {

                    case UploadType.PhotoAlbumUpload: PhotoAlbumUploadRequest(file,callbackAction,album_id, owner_id); break;
                    case UploadType.PhotoMessageUpload: PhotoMessageUploadRequest(file, callbackAction); break;
                    case UploadType.PhotoProfileUpload: PhotoProfileUploadRequest(file, callbackAction, owner_id); break;
                    case UploadType.PhotoWallUpload: PhotoWallUploadRequest(file, callbackAction,owner_id); break;

                    case UploadType.PhotoMarketAlbumUpload: PhotoMarketAlbumUploadRequest(file, callbackAction, owner_id); break;
                    case UploadType.PhotoMarketProductUpload: PhotoMarketProductUploadRequest(file, callbackAction, owner_id, is_main); break;
                }
            }
        }
        void Logger(object log)
        {
            Debug.WriteLine(log);
        }
        
    }
}
