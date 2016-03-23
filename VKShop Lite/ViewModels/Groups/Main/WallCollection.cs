using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class WallCollection : BaseViewModel
    {

        public ICommand LoadMorePostsCommand { get; set; }
        public ICommand LoadMorePostponedCommand { get; set; }
        public ICommand LoadMoreSuggestsCommand { get; set; }
        private GroupsClass _main;
        public GroupsClass MainGroup
        {
            get { return _main; }
            set { _main = value; RaisePropertyChanged("MainGroup"); }
        }

        public WallRoot GroupWall
        {
            get { return _groupWall; }
            set { _groupWall = value; RaisePropertyChanged("GroupWall"); }
        }

        private Visibility _isLoaded = Visibility.Visible;
        private Visibility _isAdmin = Visibility.Collapsed;
        private WallRoot _groupWall;

        public ObservableCollection<WallMainClass> wall
        {
            get { return _wall; }
            set { _wall = value; RaisePropertyChanged("wall"); }
        }

        public ObservableCollection<WallMainClass> postponed { get; set; }
        public ObservableCollection<WallMainClass> suggests { get; set; }
        public virtual Visibility IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }
        private GroupsClass param;
        private int posts_offset = 0;
        private int postponed_posts_offset = 0;
        private int suggests_posts_offset = 0;
        private ObservableCollection<WallMainClass> _wall;

        public WallCollection(GroupsClass group)
        {
            RegisterTasks("group");
            param = group;
            LoadMorePostsCommand = new  DelegateCommand(t =>
            {
               LoadMorePosts();
            });
            LoadMorePostponedCommand = new DelegateCommand(t =>
            {
                LoadMorePostponedNews();
            });
            LoadMoreSuggestsCommand = new DelegateCommand(t =>
            {
                LoadMoreSuggestsNews();
            });
            Load();
        }
        /// <summary>
        /// Загружает информацию о группе. Id<0
        /// </summary>
        public void Load()
        {
            TaskStarted("group");
            if (param != null)
            {
                int is_admin = 0;
                if (param.admin_level > 1) is_admin = 1;
                VKRequest.Dispatch<WallWithGroup>(
                          new VKRequestParameters(
                                      SExecute.load_group_full, "group_id", param.id.ToString(), "is_admin", is_admin.ToString()),
                          (res) =>
                          {
                              var q = res.ResultCode;
                              if (res.ResultCode == VKResultCode.Succeeded)
                              {
                                  wall = SetNewsSorces(res.Data.wall);
                                  MainGroup = res.Data.group.FirstOrDefault();
                                  posts_offset = res.Data.wall.items.Count;
                                  TaskFinished("group");
                              }
                              else
                                  TaskError("members", "ошибка загрузки");
                          });
            }
         
        
        }
        private void LoadMorePosts()
        {
            VKRequest.Dispatch<WallRoot>(
                     new VKRequestParameters(
                                 SWall.wall_get, "owner_id", string.Format("-{0}", param.id),"offset",posts_offset.ToString(), "extended", "1"),
                     (res) =>
                     {
                         var q = res.ResultCode;
                         if (res.ResultCode == VKResultCode.Succeeded)
                         {
                             var temp = SetNewsSorces(res.Data);
                             if (wall != null)
                             {
                                 foreach (var t in temp)
                                 {
                                     wall.Add(t);
                                 }
                             }
                             posts_offset += 20;
                             IsLoaded = Visibility.Collapsed;
                         }
                     });
        }

        private void LoadMoreSuggestsNews()
        {
            VKRequest.Dispatch<WallRoot>(
                     new VKRequestParameters(
                                 SWall.wall_get, "owner_id", string.Format("-{0}", param.id), "extended", "1","offset",suggests_posts_offset.ToString(), "filter", "suggests"),
                     (res) =>
                     {
                         var q = res.ResultCode;
                         if (res.ResultCode == VKResultCode.Succeeded)
                         {
                             var temp = SetNewsSorces(res.Data);
                             if (wall != null)
                             {
                                 foreach (var t in temp)
                                 {
                                     suggests.Add(t);
                                 }
                             }
                             suggests_posts_offset += 20;
                             IsLoaded = Visibility.Collapsed;
                         }
                     });
        }

        private void LoadMorePostponedNews()
        {
            VKRequest.Dispatch<WallRoot>(
                     new VKRequestParameters(
                                 SWall.wall_get, "owner_id", string.Format("-{0}", param.id), "extended", "1", "offset", postponed_posts_offset.ToString(),"filter", "postponed"),
                     (res) =>
                     {
                         var q = res.ResultCode;
                         if (res.ResultCode == VKResultCode.Succeeded)
                         {
                             IsLoaded = Visibility.Collapsed;
                            // GroupWall = SetNewsSorces(res.Data);
                         }
                     });
        }
        private ObservableCollection<WallMainClass> SetNewsSorces(WallRoot news)
        {
            ObservableCollection<WallMainClass> wall = new ObservableCollection<WallMainClass>();
            wall = news.items;
            foreach (var t in wall)
            {
                if (t.IsSigner)
                {
                    foreach (var tt in news.profiles)
                    {
                        if (t.signer_id == tt.id)
                            t.SignerUser = tt;
                    }

                }
                if (t.from_id < 0)
                {
                    foreach (var tt in news.groups)
                    {
                        if (Math.Abs(t.from_id) == tt.id)
                        {
                            t.Postedby = new PostedBy() { PostedByGroup = tt };
                        }
                    }
                }
                else
                {
                    foreach (var tt in news.profiles)
                    {

                        if (t.from_id == tt.id)
                        {
                            t.Postedby = new PostedBy() { PostedByUser = tt };
                        }
                    }
                }

                if (t.IsRepost)
                {
                    var rep = t.copy_history.FirstOrDefault();
                    if (rep.from_id > 0)
                    {
                        foreach (var tt in news.profiles)
                        {

                            if (rep.from_id == tt.id)
                            {
                                t.Repostedby = new PostedBy() { PostedByUser = tt };
                            }
                        }
                    }
                    if (rep.from_id < 0)
                    {
                        foreach (var tt in news.groups)
                        {
                            if (Math.Abs(rep.from_id) == tt.id)
                            {
                                t.Repostedby = new PostedBy() { PostedByGroup = tt };
                            }
                        }
                    }

                }
            }

            return wall;
        }

    }
}
