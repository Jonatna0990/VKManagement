using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.User;
using VKShop_Lite.Views.Profile;

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
        private void Load(UserClass user)
        {
            VKRequest.Dispatch<List<UserClass>>(
                  new VKRequestParameters(
                              SUsers.user_get, "user_ids", string.Format("{0}", user.id), "fields", "photo_100,counters"),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                          User = res.Data.FirstOrDefault();

                      }
                  });
            FollowersOpenCommand =  new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileFollowersPage) });
            });
            FriendsOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileFriendsPage) });
            });
        }

        public ProfileViewModel(UserClass user)
        {
            Load(user);
        }
    }
}
