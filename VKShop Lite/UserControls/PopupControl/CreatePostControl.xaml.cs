using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Wall;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl
{
    public sealed partial class CreatePostControl : ContentDialog
    {
        private GroupsClass CreatedGroup { get; set; }
        private Action callbackAction { get; set; }
        public CreatePostControl(Action callback, GroupsClass group)
        {
            this.InitializeComponent();
            CreatedGroup = group;
            callbackAction = callback;
        }
        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (CreatedGroup == null) return;
            if (string.IsNullOrEmpty(PostText.Text)) return;
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("owner_id", String.Format("-{0}", CreatedGroup.id));
            param.Add("message", PostText.Text);

            VKRequest.Dispatch<PostClass>(
             new VKRequestParameters(
               SWall.wall_post, param),
             (res) =>
             {
                
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         
                            this.Hide();
                            if (callbackAction != null) callbackAction.Invoke();
                            PopupEx popup = new PopupEx("Запись на стене", "Запись успешно добавлена на стену");
                            popup.ShowAsync();
                     }
                   
                     else
                     {
                         var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                         t.ShowAsync();

                     }
              
        
             });
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
