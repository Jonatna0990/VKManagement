using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace VKShop_Lite.Helpers
{
    public class UserControlFlyout
    {
         private static Popup _popup;

        
        public void ShowFlyout(UserControl control)
        {
            _popup = new Popup();
            _popup.Closed += OnPopupClosed;
            Window.Current.Activated += OnWindowActivated;
            _popup.IsLightDismissEnabled = true;
            _popup.Width = Window.Current.Bounds.Width;
            _popup.Height = Window.Current.Bounds.Height;

            control.Width = Window.Current.Bounds.Width;
            control.Height = Window.Current.Bounds.Height;

            _popup.Child = control;
            _popup.IsOpen = true;
        }

        public void CloseFloyout()
        {
            if (_popup != null)
            {
                _popup.IsOpen = false;
            }
          
        }

        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                _popup.IsOpen = false;
            }
        }

        void OnPopupClosed(object sender, object e)
        {
            Window.Current.Activated -= OnWindowActivated;
        }
    }
}
