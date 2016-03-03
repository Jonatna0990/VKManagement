using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Photo;
using VKCore.Helpers.Files;
using VKShop_Lite.UserControls.Attachment;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Counters
{
    public sealed partial class CreatePhotoControl : ContentDialog
    {
        private PhotoAlbumsClass group_id = null;
        private PhotoClass album_photo = null;
        private Action<PhotoClass> callback = null;
        public CreatePhotoControl(PhotoAlbumsClass gr, Action<PhotoClass> callbackAction)
        {
            this.InitializeComponent();
            callback = callbackAction;
            group_id = gr;
        }
      

        private async void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var a = await FilesHelper.GetImageFiles();
            if (a != null)
            {
                var aa = new APhotoUploadControl(t =>
                {
                    album_photo = t;
                    if (callback != null) callback.Invoke(t);
                    AlbumImage.Source = new BitmapImage() { UriSource = new Uri(t.photoMax) };
                }, a, UploadType.PhotoAlbumUpload, Math.Abs(group_id.owner_id), group_id.id);


            }

        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PopupEx popup = new PopupEx("Дообавление фотографии", "Фотография успешно добавлена");
            popup.ShowAsync();
        }
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
