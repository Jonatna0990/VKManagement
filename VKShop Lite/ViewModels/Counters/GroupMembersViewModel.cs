using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.ViewModels.Groups;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Counters
{
    public class GroupMembersViewModel : BaseViewModel
    {
        private GroupMembersRoot _membersRoot;
        
        public GroupMembersRoot MembersRoot
        {
            get { return _membersRoot; }
            set { _membersRoot = value;RaisePropertyChanged("MembersRoot"); }
        }

        public GroupMembersViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
               this,
               message =>
               {
                   Load(message.id);
               });

        }
        public void Load(int id)
        {


            VKRequest.Dispatch<GroupMembersRoot>(
                  new VKRequestParameters(
                    SExecute.get_group_members, "group_id", String.Format("-{0}", id)),
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
