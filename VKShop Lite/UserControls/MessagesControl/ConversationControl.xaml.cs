using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using VKCore.API.VKModels.Sticker;
using System.Windows.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.MessagesControl
{
    public sealed partial class ConversationControl : UserControl , INotifyPropertyChanged
    {
        public static DependencyProperty SendCommandProperty =
       DependencyProperty.Register(
           "SendCommand",
           typeof(ICommand),
           typeof(ConversationControl),
           new PropertyMetadata(null));
        public ICommand SendCommand
        {
            get { return (ICommand)GetValue(SendCommandProperty); }
            set { SetValue(SendCommandProperty, value); }
        }

        public static DependencyProperty SelectStickerCommandProperty =
      DependencyProperty.Register(
          "SelectStickerCommand",
          typeof(ICommand),
          typeof(ConversationControl),
          new PropertyMetadata(null));
        public ICommand SelectStickerCommand
        {
            get { return (ICommand)GetValue(SelectStickerCommandProperty); }
            set { SetValue(SelectStickerCommandProperty, value); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private Thickness _mainThickness;

        public Thickness MainThickness
        {
            get { return _mainThickness; }
            set { _mainThickness = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("MainThickness"));
                }
            }
        }

        public ConversationControl()
        {
            MainThickness= new Thickness(-12, 0, -20, 70);
            this.InitializeComponent();
            Loaded += ConversationControl_Loaded;
        }

        private async void ConversationControl_Loaded(object sender, RoutedEventArgs e)
        {
            /*StorageFolder picturesLibrary = KnownFolders.PicturesLibrary;
            var file = await picturesLibrary.GetFilesAsync();
            foreach (var t in file)
            {
                if (FolderList.Items != null)
                    FolderList.Items.Add(new StoragePhotoClass() { image = await FilesHelper.LoadImage(t), file = t});
            }*/
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
                MainThickness = new Thickness(-12, 0, -20, 320);
            }
            else
            {
                if (EmojiControl.Visibility == Visibility.Visible)
                { EmojiAndAttachPanel.Visibility = Visibility.Collapsed; MainThickness = new Thickness(-12, 0, -20, 70); }
                else { AttachPanel.Visibility = Visibility.Collapsed; EmojiControl.Visibility = Visibility.Visible; }
                
            }
        }

        private void MessageTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Visible)
            {
                EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
                MainThickness = new Thickness(-12, 0, -20, 70);
            }

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
                MainThickness = new Thickness(-12, 0, -20, 320);
            }
            else
            {
                if (AttachPanel.Visibility == Visibility.Visible)
                { EmojiAndAttachPanel.Visibility = Visibility.Collapsed; MainThickness = new Thickness(-12, 0, -20, 70); }
                else { EmojiControl.Visibility = Visibility.Collapsed; AttachPanel.Visibility = Visibility.Visible; }
                
            }
        }
        private void EmojiControl_OnStickerSelected(object sender, StickerClass e)
        {
            if (EmojiAndAttachPanel.Visibility == Visibility.Visible)
            {
                EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
                MainThickness = new Thickness(-12, 0, -20, 70);
                SelectStickerCommand?.Execute(e);
            }
          
        }

        private void FolderList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          /*  var a = sender as GridView;
            if (a != null && a.SelectedItems.Count > 0 && a.SelectedItems.Count <= 10)
            {
                PhtotoAttachItem.Visibility = Visibility.Visible;
                PhtotoAttachkBlock.Text = String.Format("добавить {0} фотографий", a.SelectedItems.Count);
            }
            else PhtotoAttachItem.Visibility = Visibility.Collapsed;*/



        }

        private  void PhtotoAttachItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
        /*    PhtotoAttachItem.Visibility = Visibility.Collapsed;
            PhtotoAttachkBlock.Text = "";*/

        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
           // PhtotoAttachItem.Visibility = Visibility.Collapsed;
           // PhtotoAttachkBlock.Text = "";
            EmojiControl.Visibility = Visibility.Collapsed;
            EmojiAndAttachPanel.Visibility = Visibility.Collapsed;
            MainThickness = new Thickness(-12, 0, -20, 70);
            SendCommand?.Execute(null);
        }
    }
}
