using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.User
{
    public class ProfileGroupsViewModel : BaseViewModel
    {
        private UserClass user = null;
        private ObservableCollection<GroupsClass> _usersCollection;

        public ObservableCollection<GroupsClass> UsersCollection
        {
            get { return _usersCollection; }
            set { _usersCollection = value;RaisePropertyChanged("UsersCollection"); }
        }

        public ProfileGroupsViewModel(UserClass user)
        {
            this.user = user;
            Load();
        }

        private void Load()
        {
            if (user != null)
            {
                VKRequest.Dispatch<VKCollection<GroupsClass>>(
               new VKRequestParameters(
                 SGroups.groups_get, "user_id", String.Format("{0}", user.id), "extended", "1", "fields", "members_count"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       UsersCollection = res.Data.items;
                   }
               });
            }
        }
    }
}
