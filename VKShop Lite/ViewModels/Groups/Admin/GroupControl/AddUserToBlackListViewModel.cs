using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Popups;
using VKCore.API.Core;
using VKCore.API.VKModels.Ban;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Admin;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class AddUserToBlackListViewModel : BaseViewModel
    {
        private BanUserClass _ban;
        private GroupsClass group;
        public BanUserClass ban
        {
            get { return _ban; }
            set { _ban = value; RaisePropertyChanged("ban");}
        }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteFromBlacklistCommand { get; set; }
        public AddUserToBlackListViewModel(BanParamClass ban)
        {
            this.ban = ban.ban;
            this.group = ban.group;
            SaveCommand = new DelegateCommand(t => { Save(); } );
            DeleteFromBlacklistCommand = new DelegateCommand(t =>
            {

                PrepeareToDelete();
            });
        }
        private void PrepeareToDelete()
        {
            var commands = new Dictionary<string, Action>();
            commands.Add("Удалить", DeleteFromBlacklist);
            commands.Add("Отмена", null);
            MessagesHelper.ShowDialogMessage("Удаление из чёрного списка", "Вы действительно хотите удалить этого пользователя из списка?", commands);

        }
        private  void DeleteFromBlacklist()
        {
            if (ban != null && group !=null)
            {
                VKRequest.Dispatch<int>(
                  new VKRequestParameters(
                    SGroups.groups_unbanUser, "group_id", group.id.ToString(), "user_id", ban.id.ToString()),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {

                         
                          PopupEx popup = new PopupEx("Удаление из чёрного списка", "Пользователь успешно удален");
                           popup.ShowAsync();
                          NavigateToCurrentPage(group, new Scenario() { ClassType = typeof(GroupBackListPage) }); ClearBackStack();
                      }
                      else
                      {
                          var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                          t.ShowAsync();
                      }
                  });
            }
        }

        private void Save()
        {
            Dictionary<string,string> param = new Dictionary<string, string>();
            
            if (ban != null)
            {
                param.Add("group_id", group.id.ToString());
                param.Add("user_id", ban.id.ToString());
                param.Add("end_date",DateTimeHelper.SetDifferenceForBlackList(ban.ban_info.block_date).ToString());
                param.Add("reason",ban.ban_info.reason.ToString());
                param.Add("comment", ban.ban_info.comment);
                param.Add("comment_visible", ban.ban_info.comment_visible.ToString());
                VKRequest.Dispatch<int>(
                  new VKRequestParameters(
                    SGroups.groups_banUser,  param),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {

                          PopupEx popup = new PopupEx("Сохранение", "Настройки успешно сохранены");
                          popup.ShowAsync();
                      }
                      else
                      {
                          var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                          t.ShowAsync();
                      }
                  });
            }
        }
    }
}
