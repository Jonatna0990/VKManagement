using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Group;
using VKShop_Lite.ViewModels.Groups.Admin.Messages;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Groups.Messages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class GroupMessagesPage : Page
    {
        public GroupMessagesPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new GroupMessagesViewModel();
            Messenger.Default.Send<GroupMessages>(e.Parameter as GroupMessages);
        }

    }
}
