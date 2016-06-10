using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.About
{
    public sealed partial class AboutAppControl : ContentDialog
    {
        public AboutAppControl()
        {
            this.InitializeComponent();
        }

     

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            this.Hide();
            var a = new PrivacyControl();
            a.ShowAsync();
        }
    }
}
