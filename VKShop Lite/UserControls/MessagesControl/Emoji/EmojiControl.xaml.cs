using System;
using System.ComponentModel;
using System.IO;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using VKCore.API.VKModels.Sticker;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.MessagesControl.Emoji
{
    public sealed partial class EmojiControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private  void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private StickerRootObject _sticker;
        public event EventHandler<StickerClass> StickerSelected;
        public StickerRootObject Sticker
        {
            get { return _sticker; }
            set { _sticker = value;
                OnPropertyChanged("Sticker");
            }
        }

        private async void LoadData()
        {
            string fileContent;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///Icons/Stickers/Stickers.txt"));
            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
                fileContent = await sRead.ReadToEndAsync();
            Sticker = JsonConvert.DeserializeObject<StickerRootObject>(fileContent);
         
        }
        public EmojiControl()
        {

            this.InitializeComponent();
            Sticker = new StickerRootObject();
            LoadData();
        }

     

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var listview = sender as ListView;
            if (listview != null)
            {
                var selecteditem = listview.SelectedItem as StickerClass;
                if(selecteditem !=null)
                    StickerSelected?.Invoke(sender, selecteditem);
            }
        }
    }
}
