using System;
using System.Collections.Generic;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.User;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class PhotoViewModel : BaseViewModel
    {
        private CountersAlbumClass _albumCollection;

        public CountersAlbumClass AlbumCollection
        {
            get { return _albumCollection; }
            set { _albumCollection = value; RaisePropertyChanged("AlbumCollection"); }
        }

        private void Load(GroupsClass group, UserClass user)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (group != null) param.Add("owner_id", String.Format("-{0}", group.id));
            else param.Add("owner_id", String.Format("{0}", user.id));
            VKRequest.Dispatch<CountersAlbumClass>(
                new VKRequestParameters(
                  SExecute.get_albums, param),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        AlbumCollection = res.Data;
                    }
                });

        }

        public PhotoViewModel(GroupsClass group, UserClass user)
        {

            Load(group,user);
        }
    }
}
