using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;
using VKShop_Lite.Views.Settings;
using GroupMainPage = VKShop_Lite.Views.Groups.Main.GroupMainPage;
using UserGroupsPage = VKShop_Lite.Views.Groups.Main.UserGroupsPage;

namespace VKShop_Lite.ViewModels.UserMain
{
    public class UserMainViewModel : BaseViewModel
    {
        private UserClass _user;
        private bool _isPaneOpen;
        private int _unreadCount;
        public ICommand NavigateToPage { get; set; }
        public ICommand NavigeteToGroupsPage { get; set; }
        public ICommand NavigeteToMessagesPage { get; set; }
        public ICommand NavigeteToSettingsPage { get; set; }
        public ICommand ToggleSplitViewPaneCommand { get; private set; }

        public int UnreadCount
        {
            get { return _unreadCount; }
            set { _unreadCount = value; RaisePropertyChanged("UnreadCount"); }
        }


        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { _isPaneOpen = value; RaisePropertyChanged("IsPaneOpen"); }
        }

        public UserClass User
        {
            get { return _user; }
            private set { _user = value; RaisePropertyChanged("User"); }
        }

        public UserMainViewModel()
        {
            ToggleSplitViewPaneCommand= new DelegateCommand(t =>
            {
                this.IsPaneOpen = !this.IsPaneOpen;
            });
            NavigeteToGroupsPage = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(new object(), new Scenario() { ClassType = typeof(UserGroupsPage) }); ClearBackStack();
            });
            NavigateToPage = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage( t, new Scenario() {ClassType = typeof(GroupMainPage)}); ClearBackStack(true);
            });
            NavigeteToMessagesPage = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(UserDialogsPage) }); ClearBackStack(true);
            });
            NavigeteToSettingsPage= new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(SettingsPage) }); ClearBackStack(true);

            });
         
            Load();
            GetUnread();
        }

        
        private void Load()
        {
            VKRequest.Dispatch<List<UserClass>>(
              new VKRequestParameters(
                SUsers.user_get, "fields", "photo_100, city, online"),
              (res) =>
              {
                  var q = res.ResultCode;
                  if (res.ResultCode == VKResultCode.Succeeded)
                  {
                      User = res.Data.FirstOrDefault();

                  }
              });
        }

        private void GetUnread()
        {
                VKRequest.Dispatch<DialogsClass>(
               new VKRequestParameters(
                 SMessages.messages_getdialogs, "count", "0"),
               (res) =>
               {
                   UnreadCount = res.Data.unread_dialogs;
               });
        
        }
        protected override void Instatce_UnreadCount(object sender, int e)
        {
            UnreadCount = e;
        }

    }
}
