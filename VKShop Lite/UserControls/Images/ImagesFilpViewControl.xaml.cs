using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Photo;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Images
{
    public sealed partial class ImagesFilpViewControl : Page
    {
        private ObservableCollection<PhotoClass> _photos;
        private PhotoSendParamClass param = null;
        public ObservableCollection<PhotoClass> photos
        {
            get { return _photos; }
            set { _photos = value; }
            
        }

        private PhotoClass selected_photo = null;
        public ImagesFilpViewControl(PhotoSendParamClass param)
        {
            this.param = param;
            this.InitializeComponent();
            if (param != null)
            {
                this.photos = param.photos;
                this.selected_photo = param.selected_photo;
                SetSources();
            }


        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
         
          

        }

        private  void SetSources()
        {
            if (photos != null && photos.Count > 0)
            {
                ImagesFlipView.ItemsSource = photos;
                if (selected_photo != null) ImagesFlipView.SelectedItem = selected_photo;
            }
        }

        private void ImagesFlipView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImagesCountersText.Text = String.Format("{0} из {1}", (ImagesFlipView.SelectedIndex + 1), photos.Count);
        }
    }
}
