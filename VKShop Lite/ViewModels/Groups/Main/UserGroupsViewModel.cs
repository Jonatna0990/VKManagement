using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups;
using ВКонтакте.Models.List;
using GroupMainPage = VKShop_Lite.Views.Groups.Main.GroupMainPage;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class UserGroupsViewModel : BaseViewModel
    {
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

        public UserGroupsViewModel()
        {
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
        private Visibility _isLoaded;

        public Visibility IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }
    
        public ICommand OpenCreatePopupCommand { get; set; }
        private ObservableCollection<GroupsClass> _editorList;
        private ObservableCollection<GroupsClass> _mainList;
        private ObservableCollection<GroupsClass> _eventList;
        private ObservableCollection<GroupsClass> _localsearchList;
        private VKCollection<GroupsClass> _globalseacrhList;
        private string _searchQuery;
        private PageMode _mode = PageMode.Normal;
        private GroupsClass _selectedGroup;

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

        public void LoadGroups()
        {
            VKRequest.Dispatch<VKList<GroupsClass>>(
               new VKRequestParameters(
                 SGroups.groups_get, "extended", "1","fields", "members_count,start_date"),
               (res) =>
               {
                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       IsLoaded = Visibility.Collapsed;
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
               });
        }

        private void Search(string param)
        {
            VKRequest.Dispatch<VKList<GroupsClass>>(
             new VKRequestParameters(
               SGroups.groups_search, "q", param),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     IsLoaded = Visibility.Collapsed;
                     GlobalSearchList = new VKCollection<GroupsClass>();
                     GlobalSearchList.items = res.Data.items.ToObservableCollection();
                     GlobalSearchList.count = res.Data.count;
                     LocalSearchList = new ObservableCollection<GroupsClass>();
                     foreach (var t in MainList)
                     {
                         if (t.name.Contains(param.ToLower()))
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
                       IsLoaded = Visibility.Collapsed;
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
