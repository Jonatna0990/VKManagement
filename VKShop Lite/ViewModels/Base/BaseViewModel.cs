using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
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
        private bool _isOpenAppBar;
        public ICommand AudioOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand PhotoOpenCommand { get; set; }
        public ICommand UserPageOpenCommand { get; set; }
        public ICommand DocsOpenCommand { get; set; }
        public ICommand NavigateToGroupCommand { get; set; }
         
        public bool IsOpenAppBar
        {
            get { return _isOpenAppBar; }
            set { _isOpenAppBar = value; RaisePropertyChanged("IsOpenAppBar"); }
        }
        public BaseViewModel()
        {
            
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
        }
        public virtual void NavigateToCurrentPage(object param, Scenario page)
        {
            UserMainPage.CurrentFrame.Navigate(page.ClassType, param);
            
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
    }
}
