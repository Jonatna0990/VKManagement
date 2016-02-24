using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.Core;
using VKCore.API.VKModels.Topics;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.User
{
    public class UserFollowersViewModel : BaseViewModel
    {
        private UserClass user = null;
        private VKCollection<UserClass> _usersCollection;

        public VKCollection<UserClass> UsersCollection
        {
            get { return _usersCollection; }
            set { _usersCollection = value; RaisePropertyChanged("UsersCollection"); }
        }

        public UserFollowersViewModel(UserClass usr)
        {
            user = usr;
            Load();
        }

        private void Load()
        {
            VKRequest.Dispatch<VKCollection<UserClass>>(
               new VKRequestParameters(
                 SUsers.user_getFollowers, "user_id", String.Format("{0}", user.id), "fields", "photo_100"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       UsersCollection = res.Data;
                   }
               });
        }
    }
}
