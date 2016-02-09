using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using VKShop_Lite.Common;

namespace VKShop_Lite.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {

        public virtual void NavigateToCurrentPage(object param, Scenario page)
        {
            Frame scenarioFrame = Window.Current.Content as Frame;
            if (scenarioFrame != null) scenarioFrame.Navigate(page.ClassType, param);
        }

        private static object SendParam;
        public void SetParam<T>(T t)
        {
            SendParam = t;
        }

        public T GetParam<T>() where T : class
        {
            return SendParam as T;
        }
        public void NavigateToPage<T>(object sender, Scenario page) where T : class
        {
            var _sender = sender as T;
            SetParam(_sender);
            Frame scenarioFrame = Window.Current.Content as Frame;
            if (scenarioFrame != null)
            {
                scenarioFrame.Navigate(page.ClassType, _sender);

            }

        }
    }
}
