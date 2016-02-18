﻿using System;
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
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Photo;
using VKShop_Lite.Helpers.Files;
using VKShop_Lite.UserControls.Attachment;
using ВКонтакте.Models.List;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Market
{
    public sealed partial class MarketProductCreateControl : ContentDialog
    {
        private GroupsClass group = null;
        private PhotoClass product_photo = null;
        private Action<MarketAlbumId> callback = null;
        public MarketProductCreateControl(GroupsClass gr, Action<MarketAlbumId> callbackAction)
        {
            this.InitializeComponent();
            callback = callbackAction;
            group = gr;
            LoadCategories();
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

                else
                {
                    PopupEx popup = new PopupEx("Ошибка", res.Error.error_msg);
                    popup.ShowAsync();
                }


        });
        }

        void Create()
        {
            if (group == null || string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Description.Text) 
                || CategoryBox.SelectionBoxItem == null || product_photo == null ||string.IsNullOrEmpty(Price.Text)) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("description", Description.Text);
            param.Add("owner_id", String.Format("-{0}", group.id));
            param.Add("name", Name.Text);
            param.Add("price", Price.Text);
            param.Add("category_id", (CategoryBox.SelectionBoxItem as MarketCategories).id.ToString());
            param.Add("main_photo_id", product_photo.id.ToString());
            VKRequest.Dispatch<MarketAlbumId>(
           new VKRequestParameters(
             SMarket.market_add, param),
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
                product_photo = t;
                AlbumImage.Source = new BitmapImage() { UriSource = new Uri(t.photoMax) };
            }, a, UploadType.PhotoMarketProductUpload, group.id,true);
        }
    }
}