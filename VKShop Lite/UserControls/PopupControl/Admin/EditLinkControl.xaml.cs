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
    public sealed partial class EditLinkControl : ContentDialog
    {
        private GroupsClass group = null;
        private Action<GroupLink> callback = null;
        private GroupLink link = null;
        public EditLinkControl(Action<GroupLink> callback, GroupsClass group, GroupLink link)
        {
            this.InitializeComponent();
            this.group = group;
            this.callback = callback;
            this.link = link;
            if (link != null)
            {
                this.Adress.Text = link.url;
                this.Description.Text = link.desc;
            }
        }
        private void Create()
        {

            if (group != null && !string.IsNullOrEmpty(Description.Text) && link!=null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("group_id", String.Format("{0}", group.id));
                param.Add("text", Description.Text);
                VKRequest.Dispatch<int>(
               new VKRequestParameters(
                 SGroups.groups_editLink, param),
               (res) =>
               {

                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {

                       this.Hide();
                       GroupLink temp = link;
                       link.desc = Description.Text;
                       if (callback != null) callback.Invoke(temp);
                       MessagesHelper.ShowMessage("Редактирование ссылки", "Ссылка успешно отредактирована");

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
