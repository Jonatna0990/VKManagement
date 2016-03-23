using System;
using System.Collections.Generic;
using System.Linq;
using VKCore.API.Core;
using VKCore.API.VKModels.Video;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class SelectedVideoViewModel : BaseViewModel
    {
        private VideoParamClass param = null;
        private VideoClass _video = null;

        public VideoClass Video
        {
            get { return _video; }
            set { _video = value; RaisePropertyChanged("Video");}
        }

        public SelectedVideoViewModel(VideoParamClass param)
        {
            this.param = param;
            Load();
            ReloadCommand = new DelegateCommand(t =>
            {
                Load();
            });
            RegisterTasks("vplayer");
            TaskStarted("vplayer");

        }

        private void Load()
        {
            Dictionary<string,string> paramDictionary = new Dictionary<string, string>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.access_key)) paramDictionary.Add("videos", String.Format("{0}_{1}_{2}", param.owner_id, param.video_id,param.access_key));
                paramDictionary.Add("videos", String.Format("{0}_{1}", param.owner_id, param.video_id));

                VKRequest.Dispatch<VKList<VideoClass>>(
             new VKRequestParameters(
               SVideos.video_get, paramDictionary),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     Video = res.Data.items.FirstOrDefault();
                     TaskFinished("vplayer");
                 }
                 else
                     TaskError("vplayer", "ошибка загрузки");
             });
            }
          
        }
    }
}
