using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Helpers;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Audio
{
    public sealed partial class AddAudioControl : UserControl
    {
        private Action<IList<AudioClass>> callbackAction = null;
        private UserClass user = null;
        UserControlFlyout flyout;
        public AddAudioControl(UserClass user,Action<IList<AudioClass>> callbackAction)
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
            IList <AudioClass> list = new List<AudioClass>();
            if (AudioList.SelectedItem != null)
            {
                if (AudioList.SelectionMode == ListViewSelectionMode.Single && e.AddedItems.Count == 1)
                {
                    list.Add(AudioList.SelectedItem as AudioClass);
                    callbackAction?.Invoke(list);
                    flyout.CloseFloyout();
                }
            }
        }
        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            flyout.CloseFloyout();
        }

        private void Selection_OnClick(object sender, RoutedEventArgs e)
        {
            AudioList.SelectionMode = ListViewSelectionMode.Multiple;

            Selection.Visibility = Visibility.Collapsed;
            Cancel.Visibility = Visibility.Collapsed;

            Send.Visibility = Visibility.Visible;
            CancelSelection.Visibility = Visibility.Visible;
        }

        private void CancelSelection_OnClick(object sender, RoutedEventArgs e)
        {
            AudioList.SelectionMode = ListViewSelectionMode.Single;
            Selection.Visibility = Visibility.Visible;
            Cancel.Visibility = Visibility.Visible;

            Send.Visibility = Visibility.Collapsed;
            CancelSelection.Visibility = Visibility.Collapsed;
        }

        private void Send_OnClick(object sender, RoutedEventArgs e)
        {
            IList<AudioClass> list = new List<AudioClass>();
            if (AudioList.SelectedItems != null )
            {
                list = new List<AudioClass>();
                foreach (var t in AudioList.SelectedItems)
                {
                    list.Add(t as AudioClass);
                }
                callbackAction?.Invoke(list);
                flyout.CloseFloyout();
            }
              
        }
    }
}
