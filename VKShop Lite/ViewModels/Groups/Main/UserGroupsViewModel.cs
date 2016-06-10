using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.UserControls.PopupControl.Group;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;
using CreateGroupPopup = VKShop_Lite.UserControls.PopupControl.Group.CreateGroupPopup;
using GroupMainPage = VKShop_Lite.Views.Groups.Main.GroupMainPage;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class UserGroupsViewModel : BaseViewModel
    {
        private Dictionary<string, string> paramsDictionary = null; 
        public GroupsClass SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                RaisePropertyChanged("SelectedGroup");
                this.NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(GroupMainPage) });

            }
        }

        private bool is_filter_open = false;
        public UserGroupsViewModel()
        {
            RegisterTasks("load");
            ReloadCommand = new DelegateCommand(t => { LoadGroups();});
            paramsDictionary = new Dictionary<string, string>();
            OpenFilterCommand = new DelegateCommand(async t =>
            {
                if (filterControl != null)
                {
                   await filterControl.ShowAsync();
                }
                else
                {
                    var p = new SearchGroupFilterControl(a =>
                    {
                        paramsDictionary = a;

                    });
                    filterControl = p;
                    await filterControl.ShowAsync();
                }
               
               
            });
            LoadGroups();
          
            OpenCreatePopupCommand = new DelegateCommand(async t =>
            {
                CreateGroupPopup popup = new CreateGroupPopup();
                await popup.ShowAsync();
                var group = popup.CreatedGroup;
                if (group != null)
                {
                    NavigateToCurrentPage(popup.CreatedGroup, new Scenario() { ClassType = typeof(GroupMainPage) });
                }
            });
              
        }
        
        public ICommand OpenCreatePopupCommand { get; set; }
        private ObservableCollection<GroupsClass> _editorList;
        private ObservableCollection<GroupsClass> _mainList;
        private ObservableCollection<GroupsClass> _eventList;
        private ObservableCollection<GroupsClass> _localsearchList;
        private VKCollection<GroupsClass> _globalseacrhList;
        private SearchGroupFilterControl filterControl;
        private string _searchQuery;
        private PageMode _mode = PageMode.Normal;
        private GroupsClass _selectedGroup;
        public ICommand OpenFilterCommand { get; set; }

        public PageMode Mode
        {
            get { return _mode; }
            set { _mode = value; RaisePropertyChanged("Mode");}
        }

        public ObservableCollection<GroupsClass> MainList
        {
            get { return _mainList; }
            set { _mainList = value; RaisePropertyChanged("MainList"); }
        }
        public ObservableCollection<GroupsClass> EditorList
        {
            get { return _editorList; }
            set { _editorList = value; RaisePropertyChanged("EditorList"); }
        }
        public ObservableCollection<GroupsClass> EventList
        {
            get { return _eventList; }
            set { _eventList = value; RaisePropertyChanged("EventList"); }
        }
        public ObservableCollection<GroupsClass> LocalSearchList
        {
            get { return _localsearchList; }
            set { _localsearchList = value; RaisePropertyChanged("LocalSearchList"); }
        }
        public VKCollection<GroupsClass> GlobalSearchList
        {
            get { return _globalseacrhList; }
            set { _globalseacrhList = value; RaisePropertyChanged("GlobalSearchList"); }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                if (!string.IsNullOrEmpty(value))
                { Search(value.Trim()); Mode = PageMode.Search; }
                RaisePropertyChanged("SearchQuery");
              
            }
        }

        public  void LoadGroups()
        {
            TaskStarted("load");
           VKRequest.Dispatch<VKList<GroupsClass>>(
               new VKRequestParameters(
                 SGroups.groups_get, "extended", "1","fields", "members_count,start_date"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       TaskFinished("load");
                       IsLoaded =false;
                       MainList = new ObservableCollection<GroupsClass>();
                       MainList = res.Data.items.ToObservableCollection();
                       EditorList = new ObservableCollection<GroupsClass>();
                       EventList = new ObservableCollection<GroupsClass>();
                       foreach (var t in MainList)
                       {
                           if (t.is_admin == 1)
                           {
                               EditorList.Add(t);
                           }
                           if(t.group_type == GroupType._event) EventList.Add(t);
                       }

                   }
                   else
                       TaskError("load", "ошибка загрузки");
               });
        }

        private void Search(string param)
        {
            if (!paramsDictionary.ContainsKey("q")) paramsDictionary.Add("q", param);
            else paramsDictionary["q"] = param;
            VKRequest.Dispatch<VKList<GroupsClass>>(
             new VKRequestParameters(
               SGroups.groups_search, paramsDictionary),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     IsLoaded = false;
                     GlobalSearchList = new VKCollection<GroupsClass>();
                     GlobalSearchList.items = res.Data.items.ToObservableCollection();
                     GlobalSearchList.count = res.Data.count;
                     LocalSearchList = new ObservableCollection<GroupsClass>();
                     foreach (var t in MainList)
                     {
                         if (t.name.ToLower().StartsWith(param.ToLower()))
                         {
                             LocalSearchList.Add(t);
                         }
                         if (t.group_type == GroupType._event) EventList.Add(t);
                     }

                 }
             });
        }
        public void LoadEvents()
        {
            VKRequest.Dispatch<VKList<GroupsClass>>(
               new VKRequestParameters(
                 SGroups.groups_get, "extended", "1", "fields", "members_count"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       IsLoaded = false;
                       MainList = new ObservableCollection<GroupsClass>();
                       MainList = res.Data.items.ToObservableCollection();
                       EditorList = new ObservableCollection<GroupsClass>();
                       foreach (var t in MainList)
                       {
                           if (t.is_admin == 1)
                           {
                               EditorList.Add(t);
                           }
                       }

                   }
               });
        }
    }
    public enum PageMode { Normal,Search}
}
