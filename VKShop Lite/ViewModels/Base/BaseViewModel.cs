using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.LongPollServer;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl.About;
using VKShop_Lite.Views.Auth;
using VKShop_Lite.Views.Conversation.User;
using VKShop_Lite.Views.Counters;
using VKShop_Lite.Views.Counters.GroupAndUser;
using VKShop_Lite.Views.Groups.Main;
using VKShop_Lite.Views.Main;
using VKShop_Lite.Views.Profile;
using VideosPage = VKShop_Lite.Views.Counters.GroupAndUser.VideosPage;

namespace VKShop_Lite.ViewModels.Base
{
    public class BaseViewModel : ViewModelBase
    {
        private readonly Dictionary<string, LongRunningTask> _tasks = new Dictionary<string, LongRunningTask>();

        public Dictionary<string, LongRunningTask> Tasks
        {
            get { return _tasks; }
        }

        public Action OnLoaded;
        public Action OnError;
        public Action OnLoading;

        #region Long Running Tasks helpers

        protected void RegisterTasks(params string[] ids)
        {
            foreach (var id in ids)
            {
                _tasks.Add(id, new LongRunningTask());
            }
        }

        protected  void TaskStarted(string id)
        {
            
            _tasks[id].Error = null;
            _tasks[id].IsWorking = true;
         }

        protected void TaskFinished(string id)
        {
            _tasks[id].IsWorking = false;
        }

        protected void TaskError(string id, string error)
        {
            _tasks[id].Error = error;
            _tasks[id].IsWorking = false;
        }


        #endregion

        public static bool is_enabled = true;
        private bool _isOpenAppBar;
        private bool _isLoaded = true;
        private VKResultCode _resultCode;
        protected AttachmentsClass attachment = null;
        public ICommand AudioOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand PhotoOpenCommand { get; set; }
        public ICommand UserPageOpenCommand { get; set; }
        public ICommand DocsOpenCommand { get; set; }
        public ICommand NavigateToGroupCommand { get; set; }
        public ICommand OpenDialogCommand { get; set; }
        public ICommand OpenPlayerCommand { get; set; }
        public virtual ICommand ReloadCommand { get; set; }
        public ICommand PrivacyOpenCommand { get; set; }
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }

        public VKResultCode ResultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; RaisePropertyChanged("ResultCode"); }
        }

        public bool IsOpenAppBar
        {
            get { return _isOpenAppBar; }
            set { _isOpenAppBar = value; RaisePropertyChanged("IsOpenAppBar"); }
        }
       
        public BaseViewModel()
        {
            UserMainPage.OnBackKeyPressed += UserMainPage_OnBackKeyPressed;
            
               OpenDialogCommand = new DelegateCommand(t =>
               {
                   if (t != null)
                   {
                       NavigateToCurrentPage(t, new Scenario()
                       {
                           ClassType = typeof(DialogConversationPage)

                       });
                   }
                 
            });
            
            UserPageOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileMainPage) });
            });
            AudioOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(AudiosPage) });
            });
            VideoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(VideosPage) });
            });
            PhotoOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(PhotoAlbumsPage) });
            });
            NavigateToGroupCommand = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(GroupMainPage) });
            });
            DocsOpenCommand = new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(DocsPage) });
            });
            OpenPlayerCommand = new DelegateCommand(t =>
            {
                this.NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(AudioPlayerMainPage) });

            });
            PrivacyOpenCommand= new DelegateCommand(t => { var a = new PrivacyControl();
                                                             a.ShowAsync();
            });
            VKSDK.AccessDenied += VKSDK_AccessDenied;
            if (VKSDK.IsLoggedIn)
            {
                LongPollService.Instatce.AddNewMessage += AddNewMessage;
                LongPollService.Instatce.WriteMessage += WriteMessage;
                LongPollService.Instatce.MessageFlagReset += MessageFlagReset;
                LongPollService.Instatce.MakeOnline += MakeOnline;
                LongPollService.Instatce.MakeOffline += MakeOffline;
                LongPollService.Instatce.AddNewMessageChat += AddNewMessageChat;
                LongPollService.Instatce.ChatChange += ChatChange;
                LongPollService.Instatce.DeleteMessage += DeleteMessage;
                LongPollService.Instatce.MessageFlagSet += MessageFlagSet;
                LongPollService.Instatce.MessageUpdate += MessageUpdate;
                LongPollService.Instatce.UnreadCount += Instatce_UnreadCount;
            }
            UserMainPage.OnNavigated += UserMainPage_OnNavigated;
        }

       

        protected virtual void UserMainPage_OnNavigated(object sender, NavigationEventArgs e)
        {
           

        }

          public virtual void UserMainPage_OnBackKeyPressed(object sender, EventArgs e)
          {

          }

          private void VKSDK_AccessDenied(object sender, VKAccessDeniedEventArgs e)
          {
              var frame = Window.Current.Content as Frame;
              if (frame != null) frame.Navigate(typeof(AuthPage));
          }



          public virtual void NavigateToCurrentPage(object param, Scenario page)
          {
              Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;
              if (scenarioFrame != null)
              {
                  var vm = scenarioFrame.DataContext as BaseViewModel;
                  if (scenarioFrame.CanGoBack)
                  {

                  }
                  scenarioFrame.Navigate(page.ClassType, param);
              }

          }

          protected void ClearBackStack(bool is_secondpage = false)
          {
              Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;
              if (scenarioFrame != null)
              {
                  scenarioFrame.BackStack.Clear();
                 if(is_secondpage) scenarioFrame.BackStack.Add(new PageStackEntry(typeof(UserGroupsPage),null, new CommonNavigationTransitionInfo()));
              }

          }
          public void NavigateToPage<T>(object sender, Scenario page) where T : class
          {
              var _sender = sender as T;

              Frame scenarioFrame = UserMainPage.Current.FindName("RootFrame") as Frame;

              if (scenarioFrame != null)
              {
                  scenarioFrame.Navigate(page.ClassType, _sender);

              }

          }
          protected virtual void MessageUpdate(object sender, LongPollMessageFlagsEventArgs e)
          {

          }

          protected virtual void MessageFlagSet(object sender, LongPollMessageFlagsEventArgs e)
          {

          }

          protected virtual void DeleteMessage(object sender, LongPollDeleteMessageEventArgs e)
          {

          }

          protected virtual void ChatChange(object sender, LongPollChatChangeEventArgs e)
          {

          }
          protected virtual void Instatce_UnreadCount(object sender, int e)
          {

          }
          protected virtual void AddNewMessageChat(object sender, LongPollMessageChatEventArgs e)
          {

          }

          protected virtual void MakeOffline(object sender, LongPollUserStatusEventArgs e)
          {

          }

          protected virtual void MakeOnline(object sender, LongPollUserStatusEventArgs e)
          {

          }

          protected virtual void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
          {

          }

          protected virtual void WriteMessage(object sender, LongPollUserEventArgs e)
          {

          }

          protected virtual void AddNewMessage(object sender, LongPollMessageEventArgs e)
          {

          }
         
       
    
    }
}
