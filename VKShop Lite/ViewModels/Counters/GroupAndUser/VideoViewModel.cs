using System;
using System.Collections.Generic;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters;
using VKShop_Lite.Views.Profile;
using SelectedVideoMainPage = VKShop_Lite.Views.Counters.GroupAndUser.SelectedVideoMainPage;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class VideosViewModel : BaseViewModel
    {
     
        public VideoClass SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                VideoParamClass param = new VideoParamClass()
                {
                    owner_id = value.owner_id,
                    video_id = value.id,


                };
                if (!string.IsNullOrEmpty(value.access_key)) param.access_key = value.access_key;
                NavigateToCurrentPage(param, new Scenario() { ClassType = typeof(SelectedVideoMainPage) });

            }
        }

        private VKCollection<VideoClass> _audioCollection;
        private VideoClass _selectedItem;

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

        public VideosViewModel(GroupsClass group, UserClass user)
        {
            Load(group,user);
        }
    }
}
