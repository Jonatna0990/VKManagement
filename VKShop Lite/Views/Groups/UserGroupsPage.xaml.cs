﻿using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Group;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Groups
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class UserGroupsPage : Page
    {
        public UserGroupsPage()
        {
            this.InitializeComponent();
            
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Visibility == Visibility.Collapsed) SearchBox.Visibility = Visibility.Visible;
            else
            {

            }
        }
    }
}
