using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Admin.Messages;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Admin.Messages
{
    public class GroupDialogsViewModel : BaseViewModel
    {


        private GroupsClass group = null;
        public ICommand NavigateToConversationCommand { get; set; }
        private DialogsClass _dialogs;
        private List<long> users;
        public DialogsClass Dialogs
        {
            get { return _dialogs; }
            set { _dialogs = value; RaisePropertyChanged("Dialogs"); }
        }
        public GroupDialogsViewModel(GroupsClass group)
        {
            users= new List<long>();
            this.group = group;
            NavigateToConversationCommand = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(new GroupMessagesParam() {message = t as MessageRoot,group = group}, new Scenario() { ClassType = typeof(GroupConversationPage) });
            });
            if (VKSDK.IsHasToken("InizializeGroupsMessages"))
            {
                Load();
            }
            else
            {
                GetMessagesTokens();
            }

        }

        private void GetMessagesTokens()
        {
            VKRequest.Dispatch<VKList<GroupMessages>>(
           new VKRequestParameters(
             SGroups.groups_get, "filter", "admin", "extended", "1", "fields", "can_message"),
          async (res) =>
          {
              var q = res.ResultCode;
              if (res.ResultCode == VKResultCode.Succeeded)
              {

                  MessageDialog msg = new MessageDialog("Для настройки сообщений Вам необходимо разрешить доступ к группам", "Разрешение доступа");
                  msg.Commands.Add(new UICommand("продолжить", CommandHandlers, res.Data.items));
                  msg.Commands.Add(new UICommand("отмена", CommandHandlers));

                  await msg.ShowAsync();

              }
          });
        }
        public void CommandHandlers(IUICommand commandLabel)
        {
            var Actions = commandLabel.Label;
            switch (Actions)
            {
                //Okay Button.
                case "продолжить":
                    {
                        List<int> tokens = new List<int>();
                        List<GroupMessages> items = commandLabel.Id as List<GroupMessages>;
                        if (items != null)
                            foreach (var a in items)
                            {
                                if (!VKSDK.IsHasToken(a.id.ToString()))
                                {
                                    tokens.Add(a.id);
                                }
                            }
                        VKSDK.SetAccessTokenForMessages(new VKAccessToken() { AccessToken = "true" }, "InizializeGroupsMessages");
                        VKSDK.AuthorizeAdminMessages(string.Join(",", tokens.Select(n => n.ToString()).ToArray()), Load);



                    }

                    break;
                //Quit Button.
                case "отмена":
                    break;
                    //end.
            }
        }
        private void Load()
        {
            if (@group != null)
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
                           else
                           {
                               var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                               t.ShowAsync();
                           }
                       });
            }

        }
        void LoadUsers(List<long> users)
        {
            if (users.Count > 0)
            {
                  string temp = string.Join(",", users.Select(n => n.ToString()).ToArray());
            VKRequest.Dispatch<List<UserClass>>(
                      new VKRequestParameters(
                        SUsers.user_get, "user_ids", temp, "fields", "photo_100"),
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
}
