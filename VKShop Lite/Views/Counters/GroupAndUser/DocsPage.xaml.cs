using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.Helpers.Files;
using VKShop_Lite.ViewModels.Counters.GroupAndUser;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Counters.GroupAndUser
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DocsPage : Page
    {
        public DocsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is GroupsClass) this.DataContext = new DocViewModel(e.Parameter as GroupsClass, null);
            else this.DataContext = new DocViewModel(null, e.Parameter as UserClass);

        }

      

       
    }
}
