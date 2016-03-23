using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
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
    public class BaseViewModel : ViewModelBase, IDisposable
    {
        private readonly Dictionary<string, LongRunningTask> _tasks = new Dictionary<string, LongRunningTask>();

        public Dictionary<string, LongRunningTask> Tasks
        {
            get { return _tasks; }
        }
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
                  
                   NavigateToCurrentPage(t, new Scenario()
                {
                    ClassType = typeof (DialogConversationPage)

                });
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

            }
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
                vm.Dispose();
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
        #region Fields
        private bool isDisposed;
        private Subject<Unit> whenDisposedSubject;
     

        #endregion
        #region Desctructors
        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class. Releases unmanaged
        /// resources and performs other cleanup operations before the <see cref="Disposable"/>
        /// is reclaimed by garbage collection. Will run only if the
        /// Dispose method does not get called.
        /// </summary>
        ~BaseViewModel()
        {
            this.Dispose(false);
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets the when errors changed observable event. Occurs when the validation errors have changed for a property or for the entire object.
        /// </summary>
        /// <value>
        /// The when errors changed observable event.
        /// </value>
        public IObservable<Unit> WhenDisposed
        {
            get
            {
                if (this.IsDisposed)
                {
                    return Observable.Return(Unit.Default);
                }
                else
                {
                    if (this.whenDisposedSubject == null)
                    {
                        this.whenDisposedSubject = new Subject<Unit>();
                    }
                    return this.whenDisposedSubject.AsObservable();
                }
            }
        }
        /// <summary>
        /// Gets a value indicating whether this <see cref="Disposable"/> is disposed.
        /// </summary>
        /// <value><c>true</c> if disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed
        {
            get { return this.isDisposed; }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            this.Cleanup();
            // Dispose all managed and unmanaged resources.
            this.Dispose(true);
            // Take this object off the finalization queue and prevent finalization code for this
            // object from executing a second time.
            GC.SuppressFinalize(this);
            LongPollService.Instatce.AddNewMessage -= AddNewMessage;
            LongPollService.Instatce.WriteMessage -= WriteMessage;
            LongPollService.Instatce.MessageFlagReset -= MessageFlagReset;
            LongPollService.Instatce.MakeOnline -= MakeOnline;
            LongPollService.Instatce.MakeOffline -= MakeOffline;
            LongPollService.Instatce.AddNewMessageChat -= AddNewMessageChat;
            LongPollService.Instatce.ChatChange -= ChatChange;
            LongPollService.Instatce.DeleteMessage -= DeleteMessage;
            LongPollService.Instatce.MessageFlagSet -= MessageFlagSet;
            LongPollService.Instatce.MessageUpdate -= MessageUpdate;
        }
        #endregion
        #region Protected Methods
        /// <summary>
        /// Disposes the managed resources implementing <see cref="IDisposable"/>.
        /// </summary>
        protected virtual void DisposeManaged()
        {
        }
        /// <summary>
        /// Disposes the unmanaged resources implementing <see cref="IDisposable"/>.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {
        }
        /// <summary>
        /// Throws a <see cref="ObjectDisposedException"/> if this instance is disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (this.isDisposed)
            {

                throw new ObjectDisposedException(this.GetType().Name);
            }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources, called from the finalizer only.</param>
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.isDisposed)
            {
                // If disposing managed and unmanaged resources.
                if (disposing)
                {
                    this.DisposeManaged();
                }
                this.DisposeUnmanaged();
                this.isDisposed = true;
                if (this.whenDisposedSubject != null)
                {
                    // Raise the WhenDisposed event.
                    this.whenDisposedSubject.OnNext(Unit.Default);
                    this.whenDisposedSubject.OnCompleted();
                    this.whenDisposedSubject.Dispose();
                }
            }
        }
        #endregion
    }
}
