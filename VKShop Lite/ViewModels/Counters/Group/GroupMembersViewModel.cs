using System;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public class GroupMembersViewModel : BaseViewModel
    {
        private GroupMembersRoot _membersRoot;
        private ICommand _reloadCommand;

        public GroupMembersRoot MembersRoot
        {
            get { return _membersRoot; }
            set { _membersRoot = value; RaisePropertyChanged("MembersRoot"); }
        }




        public GroupMembersViewModel(GroupsClass group)
        {
            RegisterTasks("members");
            Load(group);
            ReloadCommand = new DelegateCommand(t =>
            {
                Load(group);
            });

        }
        public void Load(GroupsClass group)
        {
            TaskStarted("members");
            if (group != null)
            {
                VKRequest.Dispatch<GroupMembersRoot>(
                new VKRequestParameters(
                  SExecute.get_group_members, "group_id", String.Format("-{0}", group.id), "sort", "time_asc"),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        MembersRoot = res.Data;
                        TaskFinished("members");
                    }
                    else
                    {
                       TaskError("members", "ошибка загрузки");
                    }
                });
            }
          
        }

    }
}
