using System;
using System.Collections.Generic;
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
using VKCore.API.Core;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Audio
{
    public sealed partial class AddAudioControl : ContentDialog
    {
        private Action<AudioClass> callbackAction = null;
        private UserClass user = null;
        public AddAudioControl(UserClass user,Action<AudioClass> callbackAction)
        {
            this.InitializeComponent();
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
                VKRequest.Dispatch<VKCollection<AudioClass>>(
                 new VKRequestParameters(
                   SAudios.audio_get, param),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         AudioList.ItemsSource = res.Data.items.ToObservableCollection();
                     }
                 });

            }
         
        }
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as ListView;
            if (a != null) callbackAction?.Invoke(a.SelectedItem as AudioClass);
            this.Hide();
        }
    }
}
