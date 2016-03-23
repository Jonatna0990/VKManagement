using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKShop_Lite.ViewModels.Counters.GroupAndUser;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Counters
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PhotoAlbumsPage : Page
    {
        public PhotoAlbumsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is GroupsClass) this.DataContext = new PhotoViewModel(e.Parameter as GroupsClass, null);
            else this.DataContext = new PhotoViewModel(null, e.Parameter as UserClass);
            

        }
    }
}
