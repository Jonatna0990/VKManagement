using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKShop_Lite.ViewModels.Base;

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
        }

        public ProfileViewModel(UserClass user)
        {
            Load(user);
        }
    }
}
