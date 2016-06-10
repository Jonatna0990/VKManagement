using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKShop_Lite.Helpers;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Admin
{
    public sealed partial class AddUserToAdminControl : ContentDialog, INotifyPropertyChanged
    {
        private GroupsClass group = null;
         private Action<int> callback = null;
        private int _role = 0;
        private string _linkText;
        private bool _showLink = false;
        private UserClass _user;

        public event PropertyChangedEventHandler PropertyChanged;

        private  void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Role
        {
            get { return _role; }
            set { _role = value;
                OnPropertyChanged("Role");
            }
        }

        public UserClass User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged("User"); }
        }

        public string LinkText
        {
            get { return _linkText; }
            set { _linkText = value; OnPropertyChanged("LinkText"); }
        }

        public bool ShowLink
        {
            get { return _showLink; }
            set { _showLink = value; OnPropertyChanged("ShowLink"); }
        }

      

        public AddUserToAdminControl(Action<int> callback, GroupsClass group, UserClass user)
        {
            this.InitializeComponent();
            this.group = group;
            this.callback = callback;
            this.User = user;
        }
        private void Create()
        {

            if (group != null && User != null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("group_id", String.Format("{0}", group.id));
                param.Add("user_id", String.Format("{0}", User.id));
                param.Add("role",  GetRole(Role));
                if (ShowLink)
                {
                    param.Add("is_contact", "1");
                    param.Add("contact_position", String.Format("{0}", LinkText));

                }
                else param.Add("is_contact", "0");
                VKRequest.Dispatch<int>(
               new VKRequestParameters(
                 SGroups.groups_editManager, param),
               (res) =>
               {

                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {

                       this.Hide();
                       if (callback != null) callback.Invoke(res.Data);
                       MessagesHelper.ShowMessage("Назначение руководителя", "Руководитель успешно назначен");

                   }

                   else { this.Hide(); MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }



               });

            }



        }

        private string GetRole(int role)
        {
            string temp = "moderator";

            switch (role)
            {
                case 0:
                    return "moderator";
                case 1:
                    return "editor";
                case 2:
                    return "administrator";
            }
            return temp;
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
