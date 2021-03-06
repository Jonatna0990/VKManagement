﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Market;
using VKShop_Lite.ViewModels.Groups.Market;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Groups.Market.Edit
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SelectedProductEditPage : Page
    {
        public SelectedProductEditPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new SelectedProductViewModel(e.Parameter as MarketItem);

        }
    }
}
