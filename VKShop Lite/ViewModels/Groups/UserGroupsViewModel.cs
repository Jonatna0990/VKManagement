using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups
{
    public class UserGroupsViewModel : BaseViewModel
    {
        public UserGroupsViewModel()
        {
            LoadGroups();
        }
        private Visibility _isLoaded;

        public Visibility IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }
        public ICommand NavigateToGroupCommand { get; set; }
        private ObservableCollection<GroupsClass> _editorList;
        private ObservableCollection<GroupsClass> _mainList;
        private ObservableCollection<GroupsClass> _eventList;
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
}
