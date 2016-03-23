using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;

namespace VKCore.API.VKModels.Attachment
{
    public class UploadAttachmentClass : ViewModelBase
    {
        private UserClass _postedByUser;
        private GroupsClass _postedByGroup;
        private double _uploadProgress = 0;
        private BitmapImage _image;
        private UploadAttachmentClass _attachment;


        public UploadAttachmentClass Attachment
        {
            get { return _attachment; }
            set { _attachment = value;RaisePropertyChanged("Attachment"); }
        }

        public string Text { get; set; }

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value; RaisePropertyChanged("Image");
            }
        }

        public double UploadProgress
        {
            get { return _uploadProgress; }
            set { _uploadProgress = value; RaisePropertyChanged("UploadProgress"); }
        }

    }
}
