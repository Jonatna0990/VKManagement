using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Sticker;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.CommentsControl
{
    public sealed partial class CommentsAddControl : UserControl
    {
        public CommentsAddControl()
        {
            this.InitializeComponent();
        }
        private void LoseFocus(object sender)
        {
            var control = sender as Control;
            var isTabStop = control.IsTabStop;
            control.IsTabStop = false;
            control.IsEnabled = false;
            control.IsEnabled = true;
            control.IsTabStop = isTabStop;
        }
        private async void EmojiButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Collapsed)
            {
                if (MessageTextBox.FocusState == FocusState.Pointer) LoseFocus(MessageTextBox);
                await Task.Delay(100);
                EmojiControl.Visibility = Visibility.Visible;
                AttachPanel.Visibility = Visibility.Collapsed;
                EmojiAndAttachPanel.Visibility = Visibility.Visible;
            }
            else
            {
                if (EmojiControl.Visibility == Visibility.Visible)
                    EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
                else { AttachPanel.Visibility = Visibility.Collapsed; EmojiControl.Visibility = Visibility.Visible; }
            }
        }

        private void MessageTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Visible) EmojiAndAttachPanel.Visibility = Visibility.Collapsed;

        }

        private async void AttachmentButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Collapsed)
            {
                if (MessageTextBox.FocusState == FocusState.Pointer) LoseFocus(MessageTextBox);
                await Task.Delay(100);
                //AttachPanel
                AttachPanel.Visibility = Visibility.Visible;
                EmojiControl.Visibility = Visibility.Collapsed;
                EmojiAndAttachPanel.Visibility = Visibility.Visible;
            }
            else
            {
                if (AttachPanel.Visibility == Visibility.Visible)
                    EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
                else { EmojiControl.Visibility = Visibility.Collapsed; AttachPanel.Visibility = Visibility.Visible; }

            }
        }
        private void EmojiControl_OnStickerSelected(object sender, StickerClass e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Visible) EmojiAndAttachPanel.Visibility = Visibility.Collapsed;

        }
        private async void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            EmojiControl.Visibility = Visibility.Collapsed;
            EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
            if (MessageTextBox.FocusState == FocusState.Pointer) LoseFocus(MessageTextBox);
            await Task.Delay(100);
        }
    }
}
