using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using VKShop_Lite.ViewModels.UserMain;
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
        public static event EventHandler OnBackKeyPressed = null;
        public bool ExitFromApp = true;
        public UserMainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Current = this;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;

        }

    
      

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
                OnBackKeyPressed?.Invoke(this,null);
                e.Handled = ExitFromApp;
            }
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.DataContext = new UserMainViewModel();
            RootFrame.Navigate(typeof (UserGroupsPage));
        }
   
    }
}
