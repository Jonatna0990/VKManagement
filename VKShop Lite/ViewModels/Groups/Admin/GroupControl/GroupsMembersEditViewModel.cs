using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupsMembersEditViewModel : BaseViewModel
    {
        private GroupsClass group = null;
        private ObservableCollection<UserClass> _users;
        private ObservableCollection<AdminRole> _admins;
        private ObservableCollection<UserClass> _requests;

        public ObservableCollection<UserClass> users
        {
            get { return _users; }
            set { _users = value; RaisePropertyChanged("users"); }
        }

        public ObservableCollection<UserClass> requests
        {
            get { return _requests; }
            set { _requests = value; RaisePropertyChanged("requests");
            }
        }

        public ObservableCollection<AdminRole> admins
        {
            get { return _admins; }
            set { _admins = value; RaisePropertyChanged("admins"); }
        }
        public ICommand AddUserToBlackList { get; set; }
        public ICommand AcceptUserAddRequestCommand { get; set; }
        public ICommand RefuseUserAddRequestCommand { get; set; }
        public GroupsMembersEditViewModel(GroupsClass group)
        {
            this.group = group;
            AcceptUserAddRequestCommand = new DelegateCommand(t =>
            {
                AcceptUserAddRequest(t as UserClass);
            });
            RefuseUserAddRequestCommand = new DelegateCommand(t =>
            {
                
                RefuseUserAddRequest(t as UserClass);
            });
            AddUserToBlackList = new DelegateCommand(t =>
            {
                AddToBlackList(t as UserClass);
            });
            Load();
            LoadAdmin();
            LoadRequest();
        }

        private void AddToBlackList(UserClass user)
        {
            if (user != null)
            {
                VKRequest.Dispatch<int>(
           new VKRequestParameters(
                       SGroups.groups_banUser, "group_id", Math.Abs(group.id).ToString(), "user_id", user.id.ToString()),
           (res) =>
           {
               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                   PopupEx popup = new PopupEx("Добавление в чёрный список", "Пользователь успешно добавлен");
                   popup.ShowAsync();
                   users.Remove(user);
               }
               else
               {
                   var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                   t.ShowAsync();
               }
           });
            }
        }
        private void AcceptUserAddRequest(UserClass user)
        {
            if (group != null)
            {
                VKRequest.Dispatch<int>(
             new VKRequestParameters(
                         SGroups.groups_approveRequest, "group_id", Math.Abs(group.id).ToString(), "user_id",user.id.ToString()),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     requests.Remove(user);
                     users.Insert(0,user);
                 }
             });
            }
        }
        private void RefuseUserAddRequest(UserClass user)
        {
            if (group != null)
            {

                VKRequest.Dispatch<int>(
             new VKRequestParameters(
                         SGroups.groups_removeUser, "group_id", Math.Abs(group.id).ToString(), "user_id", user.id.ToString()),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     requests.Remove(user);
                 }
             });
            }
        }
        private void Load()
        {
            if (group != null)
            {
                VKRequest.Dispatch<VKList<UserClass>>(
             new VKRequestParameters(
                         SGroups.groups_getMembers, "group_id", Math.Abs(group.id).ToString(),"fields","photo_100"),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                      users = res.Data.items.ToObservableCollection();
                 }
             });
            }
          
        }

        private void LoadAdmin()
        {
            if (group != null)
            {
                VKRequest.Dispatch<VKList<AdminRole>>(
             new VKRequestParameters(
                         SGroups.groups_getMembers, "group_id", Math.Abs(group.id).ToString(), "fields", "photo_100","filter", "managers"),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     admins = res.Data.items.ToObservableCollection();
                 }
             });
            }


        }

        private void LoadRequest()
        {
            if (group != null)
            {
                VKRequest.Dispatch<VKList<UserClass>>(
             new VKRequestParameters(
                         SGroups.groups_getRequests, "group_id", Math.Abs(group.id).ToString(), "fields", "photo_100"),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     requests = res.Data.items.ToObservableCollection();
                 }
             });
            }


        }
    }
}
