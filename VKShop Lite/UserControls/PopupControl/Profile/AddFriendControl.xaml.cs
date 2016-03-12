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
using VKCore.API.VKModels.User;
using VKShop_Lite.Helpers;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Profile
{
    public sealed partial class AddFriendControl : ContentDialog
    {
        private UserClass friend = null;
        private Action<int> callbackAction = null; 
        public AddFriendControl(UserClass friend, Action<int> callbackAction)
        {
            this.InitializeComponent();
            this.friend = friend;
            this.callbackAction = callbackAction;
            if (friend != null) UserName.Text = friend.full_name;


        }

         
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (friend != null) param.Add("user_id", String.Format("{0}", friend.id));
            if(!string.IsNullOrEmpty(SendTextBox.Text)) param.Add("text", SendTextBox.Text);
            VKRequest.Dispatch<int>(
              new VKRequestParameters(
                SFriends.friends_add, param),
              (res) =>
              {
                  var q = res.ResultCode;
                  if (res.ResultCode == VKResultCode.Succeeded)
                  {
                      Hide();
                      callbackAction?.Invoke(res.Data);
                  }
                  else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }
              });
        }
    }
}
