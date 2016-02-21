using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters;
using VKShop_Lite.Views.Groups.Admin;
using VKShop_Lite.Views.Groups.Main;
using VKShop_Lite.Views.Groups.Market;
using AudioPage = VKShop_Lite.Views.Counters.GroupAndUser.AudioPage;
using GroupMembersPage = VKShop_Lite.Views.Counters.Group.GroupMembersPage;
using GroupTopicsPage = VKShop_Lite.Views.Counters.Group.GroupTopicsPage;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class GroupMainViewModel : BaseViewModel
    {
        private WallCollection _wallColl;

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
        //CreatePostControl
        public GroupMainViewModel(GroupsClass group)
        {
            
            WallColl = new WallCollection(group);
           
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
