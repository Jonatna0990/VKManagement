using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Sticker;
using VKCore.Helpers.Files;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.MessagesControl
{
    public sealed partial class ConversationControl : UserControl
    {
     
        
        
        public ConversationControl()
        {
            this.InitializeComponent();
            Loaded += ConversationControl_Loaded;
        }

        private async void ConversationControl_Loaded(object sender, RoutedEventArgs e)
        {
            StorageFolder picturesLibrary = KnownFolders.PicturesLibrary;
            var file = await picturesLibrary.GetFilesAsync();
            foreach (var t in file)
            {
                if (FolderList.Items != null) FolderList.Items.Add(await FilesHelper.LoadImage(t));
            }
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

        private void FolderList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as GridView;
            if (a != null && a.SelectedItems.Count > 0)
            {
                PhtotoAttachItem.Visibility = Visibility.Visible;
                PhtotoAttachkBlock.Text = String.Format("добавить {0} фотографий", a.SelectedItems.Count);
            }
            else PhtotoAttachItem.Visibility = Visibility.Collapsed;



        }
    }
}
