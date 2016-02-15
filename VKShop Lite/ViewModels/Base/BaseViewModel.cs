using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using VKShop_Lite.Common;
using VKShop_Lite.Views.Main;

namespace VKShop_Lite.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {
       
        public virtual void NavigateToCurrentPage(object param, Scenario page)
        {
            Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;
            ToggleButton toggle = UserMainPage.Current.FindName("HamburgerButton") as ToggleButton;
            if (toggle != null) toggle.IsChecked = false;
            SetParam(param);
            if (scenarioFrame != null)
            {
                scenarioFrame.Navigate(page.ClassType, param);
            }
        }

        public  object SendParam { get; set; }
        public void SetParam<T>(T t)
        {
            MessengerInstance.Send(t);
            Messenger.Default.Send<T>(t);
          
        }

        public T GetParam<T>() where T : class
        {
            Messenger.Default.Register<T>(
               this,
               message =>
               {
                   SendParam = message as T; 
               });
            return SendParam as T;
        }
        public void NavigateToPage<T>(object sender, Scenario page) where T : class
        {
            var _sender = sender as T;
            
            Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;
            if (scenarioFrame != null)
            {
                scenarioFrame.Navigate(page.ClassType, _sender);
                SetParam(_sender);
            }

        }
    }
}
