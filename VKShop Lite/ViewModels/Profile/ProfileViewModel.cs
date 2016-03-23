using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl.Profile;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.User;

namespace VKShop_Lite.ViewModels.Profile
{
    public class ProfileViewModel : BaseViewModel
    {
        private UserClass _user;

        public UserClass User
        {
            get { return _user; }
            set { _user = value;RaisePropertyChanged("User"); }
        }
        public ICommand GroupsOpenCommand { get; set; }
        public ICommand FriendsOpenCommand { get; set; }
        public ICommand FollowersOpenCommand { get; set; }
        public ICommand DeleteFriendCommand { get; set; }
        public ICommand AddFriendCommand { get; set; }
        public ProfileViewModel(UserClass user)
        {
            RegisterTasks("profile");
            DeleteFriendCommand = new DelegateCommand(
                t =>
                {
                    DeleteFriend(t as UserClass);
                });
            AddFriendCommand = new DelegateCommand(t =>
            {
                AddFriend(t as UserClass);


            });
            FollowersOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileFollowersPage) });
            });
            FriendsOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileFriendsPage) });
            });
            GroupsOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileGroupsPage) });
            });
            Load(user);
        }
        private void DeleteFriend(UserClass friend)
        {
            if (friend != null)
            {
                var commands = new Dictionary<string, Action>();
                commands.Add("Удалить", () =>
                {

                    Dictionary<string, string> param = new Dictionary<string, string>();

                    if (friend != null) param.Add("user_id", String.Format("{0}", friend.id));

                    VKRequest.Dispatch<UserDeleteClass>(
                      new VKRequestParameters(
                        SFriends.friends_delete, param),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              Load(friend);
                          }
                      });
                });
                commands.Add("Отмена", null);
                MessagesHelper.ShowDialogMessage("Удалить из друзей",String.Format("Вы действительно хотите удалить {0} из списка друзей?",friend.full_name), commands);


            }


        }
        private async void AddFriend(UserClass friend)
        {
            if (friend != null)
            {

                AddFriendControl friendControl = new AddFriendControl(friend, t =>
                {
                    Load(friend);
                });
                await friendControl.ShowAsync();

            }


        }


        private void Load(UserClass user)
        {
            TaskStarted("profile");
            if (user != null)
            {
                VKRequest.Dispatch<List<UserClass>>(
                 new VKRequestParameters(
                             SUsers.user_get, "user_ids", string.Format("{0}", user.id), "fields", "photo_100,counters,is_friend,can_write_private_message,can_post,friend_status,blacklisted,blacklisted_by_me"),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         User = res.Data.FirstOrDefault();
                         TaskFinished("profile");
                     }
                     else TaskError("members", "ошибка загрузки");
                 });
            }
  
           
        }

    }
}
