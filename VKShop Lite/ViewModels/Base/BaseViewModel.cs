using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.Views.Counters;
using VKShop_Lite.Views.Counters.GroupAndUser;
using VKShop_Lite.Views.Main;

namespace VKShop_Lite.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {
        public ICommand AudioOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand PhotoOpenCommand { get; set; }


        public BaseViewModel()
        {
            AudioOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(AudioPage) });
            });
            VideoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(VideoPage) });
            });
            PhotoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(PhotoAlbumsPage) });
            });
        }
        public virtual void NavigateToCurrentPage(object param, Scenario page) 
        {
            Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;
            ToggleButton toggle = UserMainPage.Current.FindName("HamburgerButton") as ToggleButton;
            if (toggle != null) toggle.IsChecked = false;
            if (scenarioFrame != null)
            {
                scenarioFrame.Navigate(page.ClassType,param);
            }
        }

       
        public void NavigateToPage<T>(object sender, Scenario page) where T : class
        {
            var _sender = sender as T;
            
            Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;

            if (scenarioFrame != null)
            {
                scenarioFrame.Navigate(page.ClassType, _sender);
               
            }

        }
    }
}
