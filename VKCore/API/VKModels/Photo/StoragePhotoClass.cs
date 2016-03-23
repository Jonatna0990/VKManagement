using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;

namespace VKCore.API.VKModels.Photo
{
    public class StoragePhotoClass : ViewModelBase
    {
        private BitmapImage _image;
        public StorageFile file { get; set; }

        public BitmapImage image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged("image");}
        }
    }
}
