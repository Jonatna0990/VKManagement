using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Messages;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Admin.Messages
{
    public class GroupMessagesViewModel : BaseViewModel
    {
        public ICommand NavigateToConversationCommand { get; set; }
        private ObservableCollection<GroupMessages> _groups;

        public ObservableCollection<GroupMessages> Groups
        {
            get { return _groups; }
            set { _groups = value; RaisePropertyChanged("Groups");}
        }

        public GroupMessagesViewModel()
        {
            NavigateToConversationCommand  = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(GroupDialogsPage) });
            });
            Load();
        }
        private void Load()
        {
            VKRequest.Dispatch<VKList<GroupMessages>>(
             new VKRequestParameters(
               SGroups.groups_get, "filter", "admin","extended","1", "fields", "can_message"),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {

                     Groups = res.Data.items.Where(t=>t.can_message == 1).ToObservableCollection();
                     foreach (var t in Groups)
                     {
                         VKRequest.Dispatch<VKCollection<MessageRoot>>(
                        new VKRequestParameters(
                          SMessages.messages_getdialogs, "get_group_messages", t.id.ToString()),
                        (resa) =>
                        {
                            var qq = resa.ResultCode;
                            if (resa.ResultCode == VKResultCode.Succeeded)
                            {
                                if(resa.Data.count !=0)
                                    t.MessagesCollection = resa.Data;
                            }
                        });
                     }
                     List<int> tokens = new List<int>();
                     foreach (var a in res.Data.items)
                     {
                         if (!VKSDK.IsHasToken(a.id.ToString()))
                         {
                             tokens.Add(a.id);
                         }
                     }
                     if (tokens.Count > 0)
                     {
                         VKSDK.AuthorizeAdminMessages(string.Join(",", tokens.Select(n => n.ToString()).ToArray()));
                     }
                 }
             });
        }

    }
}
