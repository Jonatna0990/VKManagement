using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.ViewModels.Conversation.User;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupInfoEditViewModel : BaseViewModel
    {
        private GroupsClass group = null;
        private GroupSettings _settings;

        public GroupSettings Settings
        {
            get { return _settings; }
            set { _settings = value; RaisePropertyChanged("Settings"); }
        }

        public GroupInfoEditViewModel(GroupsClass group)
        {

            this.@group = group;
            LoadSettings();

        }

        private void LoadSettings()
        {
            if (@group != null)
            {
                VKRequest.Dispatch<GroupSettings>(
                  new VKRequestParameters(
                              SGroups.groups_getSettings, "group_id", Math.Abs(group.id).ToString()),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                          Settings = res.Data;
                      }
                  });
            }
         

        }
    }
}
