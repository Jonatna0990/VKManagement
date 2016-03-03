using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.UserMain;
using VKShop_Lite.Views.Groups;
using UserGroupsPage = VKShop_Lite.Views.Groups.Main.UserGroupsPage;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Main
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class UserMainPage : Page
    {
        public static UserMainPage Current;
        public static Frame CurrentFrame;
        public UserMainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Current = this;
            CurrentFrame = RootFrame;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

        }

    
      

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
                e.Handled = true;
            }
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = new UserMainViewModel();
            RootFrame.Navigate(typeof (UserGroupsPage));
        }
   
    }
}
