using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters
{
    public class PhotoPageViewModel : BaseViewModel
    {
        private CountersAlbumClass _albumCollection;

        public CountersAlbumClass AlbumCollection
        {
            get { return _albumCollection; }
            set { _albumCollection = value; RaisePropertyChanged("AlbumCollection"); }
        }

        private void Load(int id)
        {
            VKRequest.Dispatch<CountersAlbumClass>(
                new VKRequestParameters(
                  SExecute.get_albums, "owner_id", String.Format("{0}", id)),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        AlbumCollection = res.Data;
                    }
                });

        }

        public PhotoPageViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
            this,
            message =>
            { if (message != null) Load(-message.id); });
            Messenger.Default.Register<UserClass>(
           this,
           message =>
           {
               Load((int)message.id);
           });
        }
    }
}
