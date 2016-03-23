using System;
using System.Collections.Generic;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKShop_Lite.Helpers;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupServiceViewModel : BaseViewModel
    {
        private GroupsClass _group;
        private GroupSettings _settings;
        private int _messagesSettings;
        public ICommand SaveSettingsCommand { get; set; }
        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value; RaisePropertyChanged("Group"); }
        }

        public int MessagesSettings
        {
            get { return _messagesSettings; }
            set { _messagesSettings = value; RaisePropertyChanged("MessagesSettings"); }
        }

        public GroupSettings Settings
        {
            get { return _settings; }
            set { _settings = value; RaisePropertyChanged("Settings"); }
        }

        public GroupServiceViewModel(GroupsClass group)
        {
            this.Group = group;
            SaveSettingsCommand = new DelegateCommand(t =>
            {
                SaveSettings();
            });
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (Group != null)
            {
                VKRequest.Dispatch<GroupSettings>(
                  new VKRequestParameters(
                              SGroups.groups_getSettings, "group_id", Math.Abs(_group.id).ToString()),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                          Settings = res.Data;
                          MessagesSettings = Settings.messages;


                      }
                  });
            }


        }
        private void SaveSettings()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            if (Group != null)
            {
                param.Add("group_id", Group.id.ToString());
                param.Add("messages", MessagesSettings.ToString());
                param.Add("wall", Settings.wall.ToString());
                param.Add("photos", Settings.photos.ToString());
                param.Add("video", Settings.video.ToString());
                param.Add("audio", Settings.audio.ToString());
                param.Add("docs", Settings.docs.ToString());
                param.Add("topics", Settings.topics.ToString());
                param.Add("wiki", Settings.wiki.ToString());
                param.Add("market", Settings.market.ToString());
                VKRequest.Dispatch<int>(
                  new VKRequestParameters(
                              SGroups.groups_edit, param),
                  (res) =>
                  {
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                          MessagesHelper.ShowMessage("Изменения сохранены", "Основная информация сообщества сохранена.");
                      }
                      else MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg);
                  });
            }
        }
    }
}
