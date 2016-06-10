using System;
using System.Collections.Generic;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Map;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupInfoEditViewModel : BaseViewModel
    {
       
        private GroupSettings _settings;
        private GeoClass location = null;
        private string _groupAddress;
        private bool _ageLimit016;
        private bool _ageLimit1618;
        private bool _ageLimitOver18;
        private GroupsClass _group;
        private string _description;
        private string _screenName;
        private string _title;
        private string _website;
        public ICommand AddLocationCommand { get; set; }
        public ICommand SaveSettingsCommand { get; set; }

        public string description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("description"); }
        }

        public string screen_name
        {
            get { return _screenName; }
            set { _screenName = value; RaisePropertyChanged("screen_name"); }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged("title"); }
        }

        public int group_type { get; set; }

        public string website
        {
            get { return _website; }
            set { _website = value; RaisePropertyChanged("website"); }
        }

        public int subject { get; set; }
        public int public_category { get; set; }
        public int public_subcategory { get; set; }
        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value; RaisePropertyChanged("Group"); }
        }

        private bool age_limit_0_16
        {
            get { return _ageLimit016; }
            set { _ageLimit016 = value; RaisePropertyChanged("age_limit_0_16"); }
        }

        private bool age_limit_16_18
        {
            get { return _ageLimit1618; }
            set { _ageLimit1618 = value; RaisePropertyChanged("age_limit_16_18"); }
        }

        private bool age_limit_over_18
        {
            get { return _ageLimitOver18; }
            set { _ageLimitOver18 = value; RaisePropertyChanged("age_limit_over_18"); }
        }

        public GroupSettings Settings
        {
            get { return _settings; }
            set { _settings = value; RaisePropertyChanged("Settings"); }
        }

        public string GroupAddress
        {
            get { return _groupAddress; }
            set { _groupAddress = value; RaisePropertyChanged("GroupAddress"); }
        }

        public GroupInfoEditViewModel(GroupsClass group)
        {

            this._group = group;
            AddLocationCommand = new DelegateCommand(t =>
            {
                AddMapLocation();
            });
            SaveSettingsCommand= new DelegateCommand(t =>
            {
                SaveSettings();
            });
            LoadSettings();

        }

        private async void AddMapLocation()
        {
            var a = new AddMapLocationControl(
                t =>
                {
                    if (t != null)
                    {
                        location = t;
                    }
                });
            UserControlFlyout flyout = new UserControlFlyout();
            flyout.ShowFlyout(a);

        }

        private void SaveSettings()
        {
            Dictionary<string,string> param = new Dictionary<string, string>();
            if (_group != null)
            {
                param.Add("group_id", _group.id.ToString());
                if (_group.group_type == GroupType._event || _group.group_type == GroupType.@group)
                {
                   
                    
                }

                if(!string.IsNullOrEmpty(description)) param.Add("description",description);
                if (!string.IsNullOrEmpty(title)) param.Add("title", title);
                if (!string.IsNullOrEmpty(screen_name)) param.Add("screen_name", screen_name);
                if (!string.IsNullOrEmpty(website)) param.Add("website", website);
                if(!string.IsNullOrEmpty(GroupAddress) && GroupAddress != Settings.address) param.Add("screen_name", GroupAddress);
                if(location !=null) SavePlace();
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

        private void SavePlace()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("latitude",location.lat.ToString());
            param.Add("longitude", location.@long.ToString());
            VKRequest.Dispatch<object>(
                new VKRequestParameters(
                            SGroups.groups_editPlace, "group_id", Math.Abs(_group.id).ToString()),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                    }
                });
        }

        private void SetAgeLimits(int limit)
        {
            switch (limit)
            {
                case 0:
                {
                    age_limit_0_16 = false;
                    age_limit_16_18 = false;
                    age_limit_over_18 = false;
                }
                    break;
                case 1:
                    {
                        age_limit_0_16 = true;
                        age_limit_16_18 = false;
                        age_limit_over_18 = false;
                    }
                    break;
                case 2:
                    {
                        age_limit_0_16 = false;
                        age_limit_16_18 = true;
                        age_limit_over_18 = false;
                    }
                    break;
                case 3:
                    {
                        age_limit_0_16 = false;
                        age_limit_16_18 = false;
                        age_limit_over_18 = true;
                    }
                    break;
                default:
                    break;
            }
            
        }
        private void LoadSettings()
        {
            if (_group != null)
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
                          GroupAddress = res.Data.address;
                          description = res.Data.description;
                          title = res.Data.title;
                          website = res.Data.website;
                          //SetAgeLimits(res.Data.age_limit);
                      }
                  });
            }
         

        }
    }
}
