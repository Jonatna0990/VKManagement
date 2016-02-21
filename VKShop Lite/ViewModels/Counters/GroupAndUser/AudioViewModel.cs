using System;
using System.Collections.Generic;
using VKCore.API.Core;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class AudioViewModel : BaseViewModel
    {
        private VKCollection<AudioClass> _audioCollection;

        public VKCollection<AudioClass> AudioCollection
        {
            get { return _audioCollection; }
            set { _audioCollection = value;RaisePropertyChanged("AudioCollection"); }
        }

        private void Load(GroupsClass group,UserClass user)
        {
            Dictionary<string,string> param = new Dictionary<string, string>();

            if (group != null) param.Add("owner_id", String.Format("-{0}", group.id));
            else param.Add("owner_id", String.Format("{0}", user.id));
            VKRequest.Dispatch<VKCollection<AudioClass>>(
             new VKRequestParameters(
               SAudios.audio_get,  param),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     AudioCollection = res.Data;
                 }
             });
          
         
            
        }

        public AudioViewModel(GroupsClass group, UserClass user)
        {
            Load(group,user);
        }
    }
}
