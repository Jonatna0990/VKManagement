using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKShop_Lite.ViewModels.Conversation.User;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Conversation.User
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class UserDialogsPage : Page
    {
        public UserDialogsPage()
        {
            this.InitializeComponent();
            
            NavigationCacheMode = NavigationCacheMode.Required;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListView1.SelectedItem = -1;
            base.OnNavigatedTo(e);
           
            if (e.NavigationMode == NavigationMode.New)
            this.DataContext = new DialogsPageViewModel(e.Parameter);

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ListView1.SelectedItem = -1;
            base.OnNavigatedFrom(e);
           
        }
    }
}
