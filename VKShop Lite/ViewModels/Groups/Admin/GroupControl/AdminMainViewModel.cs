using System.Windows.Input;
using VKCore.API.VKModels.Group;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Admin;
using VKShop_Lite.Views.Groups.Admin.Messages;
using VKShop_Lite.Views.Groups.Market;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class AdminMainViewModel : BaseViewModel
    {
        private GroupsClass _group;
        public ICommand InfoOpenCommand { get; set; }
        public ICommand ServiceOpenCommand { get; set; }
        public ICommand MessagesOpenCommand { get; set; }
        public ICommand MembersOpenCommand { get; set; }
        public ICommand BlacklistOpenCommand { get; set; }
        public ICommand LinksOpenCommand { get; set; }
        public ICommand MarketOpenCommand { get; set; }

        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value;RaisePropertyChanged("Group"); }
        }

        public AdminMainViewModel(GroupsClass group)
        {
            Group = group;
            InfoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupInfoEditPage) });
            });
            ServiceOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupServicesPage) });
            });
            MessagesOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupDialogsPage) });
            });
            MembersOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupMembersEditPage) });
            });
            BlacklistOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupBackListPage) });
            });
            LinksOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(GroupLinksPage) });
            });
            MarketOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(Group, new Scenario() { ClassType = typeof(MarketMainPage) });
            });
        }
    }
}
