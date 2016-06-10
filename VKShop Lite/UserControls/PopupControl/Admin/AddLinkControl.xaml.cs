using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Link;
using VKShop_Lite.Helpers;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Admin
{
    public sealed partial class AddLinkControl : ContentDialog
    {
         private GroupsClass group = null;
         private Action<GroupLink> callback = null;
        public AddLinkControl(Action<GroupLink> callback,GroupsClass group)
        {
            this.InitializeComponent();
            this.group = group;
            this.callback = callback;
        }
        private void Create()
        {
            
            if (group != null && !string.IsNullOrEmpty(Description.Text) && !string.IsNullOrEmpty(Adress.Text))
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("group_id", String.Format("{0}", group.id));
                param.Add("link", Adress.Text);
                param.Add("text", Description.Text);
                VKRequest.Dispatch<GroupLink>(
               new VKRequestParameters(
                 SGroups.groups_addLink, param),
               (res) =>
               {

                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {

                       this.Hide();
                       if (callback != null) callback.Invoke(res.Data);
                       MessagesHelper.ShowMessage("Добавление ссылки", "Ссылка успешно добавлена");

                   }

                   else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }



               });

            }
         


        }
        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
