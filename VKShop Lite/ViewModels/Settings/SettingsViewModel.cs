using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.Media.Playback;
using Windows.UI.Popups;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.User;
using VKCore.Helpers.Files;
using VKShop_Lite.UserControls.Attachment;
using VKShop_Lite.UserControls.PopupControl.About;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Auth;
using VKShop_Lite.Views.Main;

namespace VKShop_Lite.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private UserClass _user;
        public ICommand ExitCommand { get; set; }
        public ICommand ChangePhotoCommand { get; set; }
        public ICommand OpenAboutCommand { get; set; }

        public UserClass User
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged("User"); }
        }

        public SettingsViewModel()
        {
            ExitCommand = new DelegateCommand(t =>
            {Logout();
           
            });
            OpenAboutCommand = new DelegateCommand(t => 
            {
                var a = new AboutAppControl();
                a.ShowAsync();
            });
            ChangePhotoCommand= new DelegateCommand(t => { ChangePhoto(); });
            LoadUserInfo();
        }

        private async void ChangePhoto()
        {
            var a = await FilesHelper.GetImageFiles();
            var aa = new APhotoUploadControl(t =>
            {
                LoadUserInfo();
            }, a, UploadType.PhotoProfileUpload);
        }

        private void LoadUserInfo()
        {
            if (VKSDK.GetAccessToken().UserId != null)
            {
                VKRequest.Dispatch<List<UserClass>>(
                 new VKRequestParameters(
                             SUsers.user_get, "user_ids", string.Format("{0}", VKSDK.GetAccessToken().UserId), "fields", "photo_100"),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         User = res.Data.FirstOrDefault();
                       
                     }
                 });
            }

        }
        private async void Logout()
        {
            var dialog = new MessageDialog(
                "Вы действительно хотите выйти?",
                "Выход из учетной записи");

            dialog.Commands.Add(new UICommand("Да") { Id = 0 });
            dialog.Commands.Add(new UICommand("Отмена") { Id = 1 });

            var result = await dialog.ShowAsync();
            if (result.Id.ToString() == "0")
            {
                if(BackgroundMediaPlayer.Current.CurrentState == MediaPlayerState.Playing || BackgroundMediaPlayer.Current.CurrentState == MediaPlayerState.Paused) BackgroundMediaPlayer.Shutdown();

                VKSDK.Logout();
                UserMainPage.Current.Frame.Navigate(typeof (AuthPage));
             

            }

        }
    }
}
