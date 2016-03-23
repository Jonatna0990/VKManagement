using System;
using System.Collections.Generic;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.User
{
    public class ProfileFiendsViewModel : BaseViewModel
    {
        public VKCollection<UserClass> FriendsCollection
        {
            get { return _friendsCollection; }
            set { _friendsCollection = value;RaisePropertyChanged("FriendsCollection"); }
        }

        public VKCollection<UserClass> MutualCollection { get; set; }

        private UserClass user = null;
        private VKCollection<UserClass> _friendsCollection;

        public ProfileFiendsViewModel(UserClass user)
        {
            this.user = user;
            Load();
        }
        private void Load()
        {

            VKRequest.Dispatch<VKCollection<UserClass>>(
               new VKRequestParameters(
                 SFriends.friends_get, "user_id", String.Format("{0}", user.id), "fields", "photo_100"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       FriendsCollection = res.Data;
                   }
               });
            List<int> mutual_users = new List<int>();
            VKRequest.Dispatch<List<int>>(
            new VKRequestParameters(
              SFriends.friends_getMutual, "target_uid", String.Format("{0}", user.id)),
            (res) =>
            {
                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {
                    mutual_users = res.Data;
                }
            });

        }
    }
}
