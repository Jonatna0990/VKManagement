using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.Helpers.Files;
using VKShop_Lite.UserControls.Attachment;
using ВКонтакте.Models.List;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Market
{
    public sealed partial class MarketAlbumCreateControl : ContentDialog
    {
        private string group_id = "";
        private PhotoClass album_photo = null;
        private Action<MarketAlbumId> callback = null;
        public MarketAlbumCreateControl(string gr,Action<MarketAlbumId> callbackAction)
        {
            this.InitializeComponent();
            callback = callbackAction;
            group_id = gr;
        }

       
        void Create()
        {
            if (string.IsNullOrEmpty(group_id) == null || string.IsNullOrEmpty(Name.Text)) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("owner_id", String.Format("-{0}", group_id));
            param.Add("title", Name.Text);
            if (MainSwitch.IsOn) param.Add("main_album", "1");
            if (album_photo != null) param.Add("photo_id", album_photo.id.ToString());
            VKRequest.Dispatch<MarketAlbumId>(
           new VKRequestParameters(
             SMarket.market_addAlbum, param),
           (res) =>
           {

               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {

                   this.Hide();
                   if (callback != null) callback.Invoke(res.Data);
                   PopupEx popup = new PopupEx("Дообавление побдорки", "Побдорка успешно добавлена");
                   popup.ShowAsync();
               }

               else
               {
                   PopupEx popup = new PopupEx("Ошибка", res.Error.error_msg);
                   popup.ShowAsync();
               }


           });

        }


        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Create();
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
                album_photo = t;
                AlbumImage.Source = new BitmapImage() {UriSource =new Uri(t.photoMax)};
            }, a, UploadType.PhotoMarketProductUpload, Convert.ToInt64(group_id));
        }
    }
}
