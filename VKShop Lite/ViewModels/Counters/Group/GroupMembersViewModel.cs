using System;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Profile;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public class GroupMembersViewModel : BaseViewModel
    {
        private GroupMembersRoot _membersRoot;
        
        public GroupMembersRoot MembersRoot
        {
            get { return _membersRoot; }
            set { _membersRoot = value;RaisePropertyChanged("MembersRoot"); }
        }

     
        public GroupMembersViewModel(GroupsClass group)
        {
            Load(group);
           

        }
        public void Load(GroupsClass group)
        {


            VKRequest.Dispatch<GroupMembersRoot>(
                  new VKRequestParameters(
                    SExecute.get_group_members, "group_id", String.Format("-{0}", group.id),"sort", "time_asc"),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                          MembersRoot = res.Data;
                      }
                  });
        }

    }
}
