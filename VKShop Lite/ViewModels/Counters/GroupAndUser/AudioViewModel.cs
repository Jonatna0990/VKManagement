using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VKCore.API.Core;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Helpers;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class AudioViewModel : BaseViewModel
    {
        public AudioClass SelectedAudio
        {
            get { return _selectedAudio; }
            set
            {
                _selectedAudio = value;
                RaisePropertyChanged("SelectedAudio");
                BasePlayerInstance.Base.Playlist = AudioCollection;
                BasePlayerInstance.Base.PlayTrack(value);
               
            }
        }

        private ObservableCollection<AudioClass> _audioCollection;
        private AudioClass _selectedAudio;

        public ObservableCollection<AudioClass> AudioCollection
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
                     AudioCollection = res.Data.items.ToObservableCollection();
                 }
             });
          
         
            
        }

        public AudioViewModel(GroupsClass group, UserClass user)
        {
            Load(group,user);
        }
    }
}
