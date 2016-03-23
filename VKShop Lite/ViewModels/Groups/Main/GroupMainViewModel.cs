using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VKCore.API.VKModels.Group;
using VKShop_Lite.Common;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Admin;
using VKShop_Lite.Views.Groups.Market;
using GroupMembersPage = VKShop_Lite.Views.Counters.Group.GroupMembersPage;
using GroupTopicsPage = VKShop_Lite.Views.Counters.Group.GroupTopicsPage;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class GroupMainViewModel : BaseViewModel
    {
        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value;RaisePropertyChanged("Group"); }
        }

        private WallCollection _wallColl;
        private GroupsClass _group;

        public WallCollection WallColl
        {
            get { return _wallColl; }
            set { _wallColl = value; RaisePropertyChanged("WallColl"); }
        }
        public ICommand MembersOpenCommand { get; set; }
        public ICommand TopicOpenCommand { get; set; }
        public ICommand GroupInfoEditOpenCommand { get; set; }
        public ICommand MarketOpenCommand { get; set; }
        public ICommand CreatePostCommand { get; set; }
        public ICommand AdminOpenCommand { get; set; }

      //  public ObservableCollection<> 
        //CreatePostControl
        public GroupMainViewModel(GroupsClass group)
        {
            
            Group = group;
            WallColl = new WallCollection(group);

            AdminOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(AdminMainPage) });
            });
            MembersOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t,new Scenario() { ClassType = typeof(GroupMembersPage)});
            });
            TopicOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(GroupTopicsPage) });
            });
           
            GroupInfoEditOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(GroupInfoEditPage) });
            });
            MarketOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(MarketMainPage) });
            });
            CreatePostCommand= new DelegateCommand(async t =>
            {
                CreatePostControl popup = new CreatePostControl(() =>
                {
                    WallColl.Load();
                },WallColl.MainGroup);
                await popup.ShowAsync();
            
               
            });
        }

        

    }
}
