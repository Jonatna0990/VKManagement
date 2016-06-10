using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Helpers;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.Video
{
    public sealed partial class AddVideoControl : UserControl
    {
        private Action<VideoClass> callbackAction = null;
        private UserClass user = null;
        UserControlFlyout flyout;
        public AddVideoControl(UserClass user, Action<VideoClass> callbackAction)
        {
            this.InitializeComponent();
            flyout = new UserControlFlyout();
            this.user = user;
            this.callbackAction = callbackAction;
            LoadMusic();
        }

        private void LoadMusic()
        {
            if (user != null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("owner_id", String.Format("{0}", user.id));
                VKRequest.Dispatch<VKCollection<VideoClass>>(
                 new VKRequestParameters(
                   SVideos.video_get, param),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         VideoList.ItemsSource = res.Data.items.ToObservableCollection();
                     }
                 });
            }
         
        }
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as GridView;
            if (a != null) callbackAction?.Invoke(a.SelectedItem as VideoClass);
            flyout.CloseFloyout();
        }
    }
}
