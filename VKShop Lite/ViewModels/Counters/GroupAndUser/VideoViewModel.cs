using System;
using System.Collections.Generic;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class VideoViewModel : BaseViewModel
    {
        private VKCollection<VideoClass> _audioCollection;

        public VKCollection<VideoClass> VideoCollection
        {
            get { return _audioCollection; }
            set { _audioCollection = value; RaisePropertyChanged("VideoCollection"); }
        }

        private void Load(GroupsClass group, UserClass user)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (group != null) param.Add("owner_id", String.Format("-{0}", group.id));
            else param.Add("owner_id", String.Format("{0}", user.id));

            VKRequest.Dispatch<VKCollection<VideoClass>>(
                new VKRequestParameters(
                  SVideos.video_get, param),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        VideoCollection = res.Data;
                    }
                });

        }

        public VideoViewModel(GroupsClass group, UserClass user)
        {
            Load(group,user);
        }
    }
}
