using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Group;
using VKShop_Lite.ViewModels.Counters;
using VKShop_Lite.ViewModels.Counters.Group;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Counters.Group
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class GroupTopicsPage : Page
    {
        public GroupTopicsPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new GroupTopicsViewModel(e.Parameter as GroupsClass);

        }
    }
}
