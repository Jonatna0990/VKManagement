using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Group;
using VKShop_Lite.ViewModels.Groups.Main;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Groups.Main
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new UserGroupsViewModel();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Visibility == Visibility.Collapsed)
            {
                SearchBox.Visibility = Visibility.Visible;
                SearchBox.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                this.BottomAppBar.IsOpen = false;
            }
            else
            {
                SearchBox.Focus(Windows.UI.Xaml.FocusState.Programmatic);
                this.BottomAppBar.IsOpen = false;
            }
           
        }
    }
}
