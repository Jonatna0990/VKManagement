using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.Messages
{
    public class GroupDialogsViewModel : BaseViewModel
    {
        private DialogsClass _dialogs;

        public DialogsClass Dialogs
        {
            get { return _dialogs; }
            set { _dialogs = value;RaisePropertyChanged("Dialogs"); }
        }

        private List<int> users; 
        public GroupDialogsViewModel( GroupsClass group)
        {
            Load(group);
        }

        void Load(GroupsClass group )
        {
            VKRequest.Dispatch<DialogsClass>(
                       new VKRequestParameters(
                         SMessages.messages_getdialogs, "get_group_messages", group.id.ToString()),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               Dialogs = res.Data;
                               foreach (var t in res.Data.messages)
                               {
                                   users.Add(t.message.user_id);
                               }
                               LoadUsers(users);
                           }
                       });
           
        }

        void LoadUsers(List<int> users)
        {
            string temp = string.Join(",", users.Select(n => n.ToString()).ToArray());
            VKRequest.Dispatch<List<UserClass>>(
                      new VKRequestParameters(
                        SUsers.user_get, "user_ids", temp,"fields","photo_100"),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              foreach (var t in Dialogs.messages)
                              {
                                  if (t.message.user_id > 0)
                                  {
                                      var a = res.Data.FirstOrDefault(w => w.id == t.message.user_id);
                                      if (a != null) t.message.MsgFrom = new MessageFrom(a);
                                  }
                              }
                          }
                      });

        }
    }
}
