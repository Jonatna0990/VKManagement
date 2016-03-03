using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Photo;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Images
{
    public sealed partial class ImagesFilpViewControl : Page
    {
        private ObservableCollection<PhotoClass> _photos;

        public ObservableCollection<PhotoClass> photos
        {
            get { return _photos; }
            set { _photos = value; }
            
        }

        private PhotoClass selected_photo = null;
        public ImagesFilpViewControl()
        {
            
            this.InitializeComponent();
          

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PhotoSendParamClass param = e.Parameter as PhotoSendParamClass;
            if (param != null)
            {
                this.photos = param.photos;
                this.selected_photo = param.selected_photo;
                SetSources();
            }
          

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
