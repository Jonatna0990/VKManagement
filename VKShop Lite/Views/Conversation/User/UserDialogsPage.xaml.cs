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
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter;
            if (param != null)
            {
                this.DataContext = new DialogsPageViewModel(e.Parameter);
            }
          

        }
      
        

    }
}
