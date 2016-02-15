using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters
{
    public class VideoPageViewModel : BaseViewModel
    {
        private VKCollection<VideoClass> _audioCollection;

        public VKCollection<VideoClass> VideoCollection
        {
            get { return _audioCollection; }
            set { _audioCollection = value; RaisePropertyChanged("VideoCollection"); }
        }

        private void Load(int id)
        {
            VKRequest.Dispatch<VKCollection<VideoClass>>(
                new VKRequestParameters(
                  SVideos.video_get, "owner_id", String.Format("{0}", id)),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        VideoCollection = res.Data;
                    }
                });

        }

        public VideoPageViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
            this,
            message =>
            {
                Load(-message.id);
            });
            Messenger.Default.Register<UserClass>(
           this,
           message =>
           {
               Load((int)message.id);
           });
        }
    }
}
