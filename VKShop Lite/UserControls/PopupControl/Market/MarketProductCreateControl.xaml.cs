using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Photo;
using VKCore.Helpers.Files;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Attachment;
using ВКонтакте.Models.List;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Market
{
    public sealed partial class MarketProductCreateControl : ContentDialog
    {
        private string group_id = null;
        private PhotoClass product_photo = null;
        private Action<MarketProductId> callback = null;
        public MarketProductCreateControl(string gr, Action<MarketProductId> callbackAction)
        {
            this.InitializeComponent();
            RootGrid.Height = Window.Current.Bounds.Height;
            callback = callbackAction;
            group_id = gr;
            LoadCategories();
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }
        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            var q = e;
        }
        void LoadCategories()
        {
                VKRequest.Dispatch<VKList<MarketCategories>>(
            new VKRequestParameters(
              SMarket.market_getCategories,"count", "1000"),
            (res) =>
            {

                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {

                    CategoryBox.ItemsSource = res.Data.items;

                }
                else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }

            });
        }

        void Create()
        {
            if (string.IsNullOrEmpty(group_id) || string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Description.Text) 
                || CategoryBox.SelectionBoxItem == null || product_photo == null ||string.IsNullOrEmpty(Price.Text)) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("description", Description.Text);
            param.Add("owner_id", String.Format("-{0}", group_id));
            param.Add("name", Name.Text);
            param.Add("price", Price.Text);
            param.Add("category_id", (CategoryBox.SelectionBoxItem as MarketCategories).id.ToString());
            param.Add("main_photo_id", product_photo.id.ToString());
            VKRequest.Dispatch<MarketProductId>(
           new VKRequestParameters(
             SMarket.market_add, param),
           (res) =>
           {

               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {

                   this.Hide();
                   if (callback != null) callback.Invoke(res.Data);
                   MessagesHelper.ShowMessage("Дообавление товара", "Товар успешно добавлен");
               }

               else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }

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
            UploadProgressRing.IsActive = true;
            AddButton.Visibility = Visibility.Collapsed;
            var aa = new APhotoUploadControl(t =>
            {
                if (t.height < 400 || t.width < 400 || t.height > 7000 || t.width > 7000)
                {
                    MessageDialog z = new MessageDialog("Неверный формат изображения","Ошибка");
                    z.ShowAsync();
                }
                product_photo = t;
                AlbumImage.Source = new BitmapImage() { UriSource = new Uri(t.photoMax) };
                UploadProgressRing.IsActive = false;
            }, a, UploadType.PhotoMarketProductUpload, Convert.ToInt64(group_id),0, true);
           
        }
    }
}
