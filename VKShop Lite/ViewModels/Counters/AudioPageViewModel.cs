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
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters
{
    public class AudioPageViewModel : BaseViewModel
    {
        private VKCollection<AudioClass> _audioCollection;

        public VKCollection<AudioClass> AudioCollection
        {
            get { return _audioCollection; }
            set { _audioCollection = value;RaisePropertyChanged("AudioCollection"); }
        }

        private void Load(int id)
        {
            VKRequest.Dispatch<VKCollection<AudioClass>>(
                new VKRequestParameters(
                  SAudios.audio_get, "owner_id", String.Format("{0}", id)),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        AudioCollection = res.Data;
                    }
                });
            
        }

        public AudioPageViewModel()
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
