using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using VKShop_Lite.Views.Conversation.User;
using VKShop_Lite.Views.Groups.Admin;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupBlackListViewModel : BaseViewModel
    {
        private GroupsClass group = null;
        private ObservableCollection<BanUserClass> _blacklist;

        public ObservableCollection<BanUserClass> blacklist
        {
            get { return _blacklist; }
            set { _blacklist = value; RaisePropertyChanged("blacklist"); }
        }
        public ICommand DeleteFromBlacklistCommand { get; set; }
        public ICommand OpenBlackListUserCommand { get; set; }
        public GroupBlackListViewModel(GroupsClass group)
        {
            this.group = group;
            DeleteFromBlacklistCommand = new DelegateCommand(t =>
            {

                PrepeareToDelete(t as BanUserClass);
            });
            OpenBlackListUserCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(new BanParamClass {ban = t as BanUserClass, group =group}, new Scenario()
                {
                    ClassType = typeof(AddUserToBlackLst)

                });
            });
            RegisterTasks("blacklist");
            Load();
        }

        private void PrepeareToDelete(BanUserClass user)
        {
            var commands = new Dictionary<string, Action>();
            commands.Add("Удалить", () =>
            {

                DeleteFromBlacklist(user);
            });
            commands.Add("Отмена", null);
            MessagesHelper.ShowDialogMessage("Удаление из чёрного списка", "Вы действительно хотите удалить этого пользователя из списка?", commands);

        }
        private void DeleteFromBlacklist(BanUserClass user)
        {
            if (user != null)
            {
                VKRequest.Dispatch<int>(
                  new VKRequestParameters(
                    SGroups.groups_unbanUser, "group_id", group.id.ToString(), "user_id", user.id.ToString()),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {

                          blacklist.Remove(user);
                          PopupEx popup = new PopupEx("Удаление из чёрного списка", "Пользователь успешно удален");
                          popup.ShowAsync();
                      }
                      else
                      {
                          var t = new MessageDialog(res.Error.error_msg,"Ошибка");
                          t.ShowAsync();
                      }
                  });
            }
        }
        private void Load()
        {
            if (group != null)
            {
                TaskStarted("blacklist");
                VKRequest.Dispatch<VKList<BanUserClass>>(
                   new VKRequestParameters(
                     SGroups.groups_getBanned, "group_id", group.id.ToString(), "fields", "photo_100"),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {

                           blacklist = res.Data.items.ToObservableCollection();
                           TaskFinished("blacklist");
                       }
                       else
                           TaskError("members", "ошибка загрузки");
                   });
            }
          
        }
    }
    
}
