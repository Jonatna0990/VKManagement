using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Group;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters;
using VKShop_Lite.Views.Groups.Admin;
using VKShop_Lite.Views.Groups.Main;
using VKShop_Lite.Views.Groups.Market;

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
        public ICommand AudioOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand PhotoOpenCommand { get; set; }
        public ICommand GroupInfoEditOpenCommand { get; set; }
        public ICommand MarketOpenCommand { get; set; }
        public ICommand CreatePostCommand { get; set; }
        //CreatePostControl
        public GroupMainViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
                 this,
                 message =>
                 {
                     WallColl = new WallCollection(message);
                 });
            MembersOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t,new Scenario() { ClassType = typeof(GroupMembersPage)});
            });
            TopicOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(GroupTopicsPage) });
            });
            AudioOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(AudioPage) });
            });
            VideoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(VideoPage) });
            });
            PhotoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(PhotoAlbumsPage) });
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
