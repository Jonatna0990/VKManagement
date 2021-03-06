﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.UserControls.CaptchaControl;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Group
{
    public sealed partial class CreateGroupPopup : ContentDialog
    {
        public CreateGroupPopup()
        {
            this.InitializeComponent();
        }
        public GroupsClass CreatedGroup { get; set; }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(GroupName.Text)) return;
            else
            {
                if (EventRadio.IsChecked == true || GroupRadio.IsChecked == true || PageRadio.IsChecked == true)
                {
                    var checkedButton = RadioContainer.Children.OfType<RadioButton>()
                                         .FirstOrDefault(r => r.IsChecked.Value);
                    if (checkedButton != null)
                    {
                        Dictionary<string,string> param = new Dictionary<string, string>();
                        param.Add("title", GroupName.Text);
                        if(checkedButton.Tag.ToString() == "public")
                            param.Add("subtype", (Subtitle.SelectedIndex+1).ToString());
                        param.Add("type",checkedButton.Tag.ToString());
                        
                        VKRequest.Dispatch<GroupsClass>(
                         new VKRequestParameters(
                           SGroups.groups_create, param),
                         (res) =>
                         {
                             var q = res.ResultCode;
                             if (res.ResultCode == VKResultCode.Succeeded)
                             {

                                 CreatedGroup = res.Data;
                                 this.Hide();
                               //  PopupEx popup = new PopupEx("test","test");
                               //  popup.ShowAsync();
                             }
                             if (res.ResultCode == VKResultCode.CaptchaRequired)
                             {

                             }
                             else
                             {
                                 var t = new MessageDialog(res.Error.error_msg);
                                 t.ShowAsync();

                             }
                         });
                    }
                 
                }

            }

        }
        private void CaptchaRequest(VKCaptchaUserRequest captchaUserRequest, Action<VKCaptchaUserResponse> action)
        {
            new VKCaptchaRequestUserControl().ShowCaptchaRequest(captchaUserRequest, action);
        }
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
