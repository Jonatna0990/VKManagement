using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.User;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.GroupAndUser;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class PhotoViewModel : BaseViewModel
    {
        private CountersAlbumClass _albumCollection;
        private Visibility _canAddVisibility = Visibility.Collapsed;
        private GroupsClass group = null;
        private UserClass user = null;
        private PhotoAlbumsClass _selectedAlbumsItem;


        public PhotoAlbumsClass SelectedAlbumsItem
        {
            get { return _selectedAlbumsItem; }
            set
            {
                _selectedAlbumsItem = value; RaisePropertyChanged("SelectedAlbumsItem");
                NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(SelectedPhotoAlbumPage) });

            }
        }

        public Visibility CanAddVisibility
        {
            get { return _canAddVisibility; }
            set { _canAddVisibility = value; RaisePropertyChanged("CanAddVisibility"); }
        }

        public CountersAlbumClass AlbumCollection
        {
            get { return _albumCollection; }
            set { _albumCollection = value; RaisePropertyChanged("AlbumCollection"); }
        }

        private void Load()
        {
            if (group != null || user != null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                if (group != null)
                {
                    param.Add("owner_id", String.Format("-{0}", group.id));
                    if (group.admin_level > 1) CanAddVisibility = Visibility.Visible;
                }
                else
                {
                    param.Add("owner_id", String.Format("{0}", user.id));
                    if (user.id.ToString() == VKSDK.GetAccessToken().UserId) CanAddVisibility = Visibility.Visible;
                }
                VKRequest.Dispatch<CountersAlbumClass>(
                    new VKRequestParameters(
                      SExecute.get_albums, param),
                    (res) =>
                    {
                        var q = res.ResultCode;
                        if (res.ResultCode == VKResultCode.Succeeded)
                        {
                            AlbumCollection = res.Data;
                            TaskFinished("palbum");
                        }
                        else TaskError("members", "ошибка загрузки");
                    });
            }
          

        }

        public PhotoViewModel(GroupsClass group, UserClass user)
        {
            this.group = group;
            this.user = user;
            RegisterTasks("palbum");
            TaskStarted("palbum");
            Load();
            ReloadCommand = new DelegateCommand(t => {Load(); });
        }
    }
}
