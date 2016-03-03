using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using VKCore.API.Core;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers.Files;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Attachment;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Market
{
    public sealed partial class MarketAlbumEditControl : ContentDialog
    {
        private MarketAlbum album = null;
        private Action<int> callback = null;
        private PhotoClass uploaded_photo = null;
        public MarketAlbum Album { get; set; }
        public MarketAlbumEditControl(MarketAlbum album, Action<int> callback )
        {
            this.InitializeComponent();
            RootGrid.Height = Window.Current.Bounds.Height;
            this.album = album;
            this.callback = callback;
            LoadAlbumInfo();
        }


        private void LoadAlbumInfo()
        {
            if (album != null)
            {
                VKRequest.Dispatch<VKCollection<MarketAlbum>>(
                     new VKRequestParameters(
                       SMarket.market_getAlbumById, "owner_id", String.Format("{0}", album.owner_id), "album_ids", String.Format("{0}", album.id), "extended", "1"),
                     (res) =>
                     {
                         var q = res.ResultCode;
                         if (res.ResultCode == VKResultCode.Succeeded)
                         {
                             Album = res.Data.items.FirstOrDefault();
                             this.AlbumName.Text = Album.title;
                             this.AlbumCoverImage.Source = new BitmapImage() {UriSource = new Uri(Album.photo.photoMax)};
                         }
                     });
            }
        }
        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
             if (string.IsNullOrEmpty(AlbumName.Text)) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("owner_id", String.Format("{0}", album.owner_id));
            param.Add("album_id", String.Format("{0}", album.id));

            if (IsMainAlbumToggle.IsOn) param.Add("main_album", "1");
            param.Add("title", AlbumName.Text);
            if(uploaded_photo !=null) param.Add("photo_id", uploaded_photo.id.ToString());
            VKRequest.Dispatch<int>(
                    new VKRequestParameters(
                      SMarket.market_editAlbum ,param),
                    (res) =>
                    {
                        var q = res.ResultCode;
                        if (res.ResultCode == VKResultCode.Succeeded)
                        {
                            callback?.Invoke(album.id);
                            this.Hide();
                            MessagesHelper.ShowMessage("Изменение подборки", "Подборка успешно изменена");
                        }
                        else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg);}
                    });

        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }

        private async void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            var a = await FilesHelper.GetImageFiles();
            var aa = new APhotoUploadControl(t =>
            {
                uploaded_photo = t;


                AlbumCoverImage.Source = new BitmapImage() { UriSource = new Uri(t.photoMax) };
            }, a, UploadType.PhotoMarketProductUpload, Convert.ToInt64(album.owner_id));

        }
    }
}
