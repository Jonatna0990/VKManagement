using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Images;
using VKShop_Lite.ViewModels.Base;
using CreatePhotoControl = VKShop_Lite.UserControls.PopupControl.Counters.CreatePhotoControl;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class SelectedPhotoAlbumViewModel : BaseViewModel
    {
        private PhotoAlbumsClass photoAlbum = null;
        private ObservableCollection<PhotoClass> _photosCollection = null;
        private Visibility _canAddVisibility = Visibility.Collapsed;
        private PhotoClass _selectedImage;

        public ICommand AddPhotoCommand { get; set; }
        public ICommand OpenSelectedImage { get; set; }
        public ObservableCollection<PhotoClass> PhotosCollection
        {
            get { return _photosCollection; }
            set { _photosCollection = value; RaisePropertyChanged("PhotosCollection");}
        }

        public PhotoClass SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                UserControlFlyout flyout = new UserControlFlyout();
                flyout.ShowFlyout(new ImagesFilpViewControl(new PhotoSendParamClass { photos = PhotosCollection, selected_photo = value }));
            }
        }

        public Visibility CanAddVisibility
        {
            get { return _canAddVisibility; }
            set { _canAddVisibility = value; RaisePropertyChanged("CanAddVisibility"); }
        }

        public SelectedPhotoAlbumViewModel(PhotoAlbumsClass photoAlbum)
        {
            this.photoAlbum = photoAlbum;
            AddPhotoCommand = new DelegateCommand(t =>
            {
                var a = new CreatePhotoControl(photoAlbum, z =>
                {
                    var x = z;
                });
                a.ShowAsync();
            });
            OpenSelectedImage = new DelegateCommand(t =>
            {
            
            });
            if (photoAlbum.owner_id.ToString() == VKSDK.GetAccessToken().UserId) CanAddVisibility = Visibility.Visible;
            if(photoAlbum.can_upload > 0) CanAddVisibility = Visibility.Visible;
            Load();
        }

        private void Load()
        {
            Dictionary<string, string> paramDictionary = new Dictionary<string, string>();
            if (photoAlbum != null)
            {
                paramDictionary.Add("owner_id", String.Format("{0}", photoAlbum.owner_id));
                paramDictionary.Add("album_id", String.Format("{0}", photoAlbum.id));
                paramDictionary.Add("extended", "1");
                VKRequest.Dispatch<VKCollection<PhotoClass>>(
             new VKRequestParameters(
               SPhotos.photos_get, paramDictionary),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     PhotosCollection = res.Data.items.ToObservableCollection();
                 }
             });
            }
        }
    }
}
