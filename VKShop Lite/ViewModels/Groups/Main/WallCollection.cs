using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Main
{
    public class WallCollection : BaseViewModel
    {
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

        public virtual Visibility IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; RaisePropertyChanged("IsLoaded"); }
        }
        private GroupsClass param;
        public WallCollection(GroupsClass par)
        {
            if(par == null) return;
            param = par;
            Load();
        }
        /// <summary>
        /// Загружает информацию о группе. Id<0
        /// </summary>
        public void Load()
        {
            VKRequest.Dispatch<List<GroupsClass>>(
                        new VKRequestParameters(
                                    SGroups.groups_getById, "group_id", string.Format("{0}", param.id), "fields", "members_count,description,site,links,finish_date,fixed_post,verified,can_post,can_see_all_posts,city,place,start_date,links,status,contacts,counters,market,is_closed"),
                        (res) =>
                        {
                            var q = res.ResultCode;
                            if (res.ResultCode == VKResultCode.Succeeded)
                            {
                               MainGroup = res.Data.FirstOrDefault();
                            }
                        });
            VKRequest.Dispatch<WallRoot>(
                       new VKRequestParameters(
                                   SWall.wall_get, "owner_id", string.Format("-{0}", param.id),"extended","1"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               IsLoaded = Visibility.Collapsed;
                               GroupWall = SetNewsSorces(res.Data);
                           }
                       });
        }
        private WallRoot SetNewsSorces(WallRoot news)
        {
            WallRoot main = news;
            foreach (var t in main.items)
            {
                if (t.IsSigner)
                {
                    foreach (var tt in main.profiles)
                    {
                        if (t.signer_id == tt.id)
                            t.SignerUser = tt;
                    }

                }
                if (t.owner_id < 0)
                {
                    foreach (var tt in main.groups)
                    {
                        if (Math.Abs(t.owner_id) == tt.id)
                        {
                            t.Postedby = new PostedBy() { PostedByGroup = tt };
                        }
                    }
                }
                else
                {
                    foreach (var tt in main.profiles)
                    {

                        if (t.owner_id == tt.id)
                        {
                            t.Postedby = new PostedBy() { PostedByUser = tt };
                        }
                    }
                }

                if (t.IsRepost)
                {
                    var rep = t.copy_history.FirstOrDefault();
                    if (rep.owner_id > 0)
                    {
                        foreach (var tt in main.profiles)
                        {

                            if (rep.owner_id == tt.id)
                            {
                                t.Repostedby = new PostedBy() { PostedByUser = tt };
                            }
                        }
                    }
                    if (rep.owner_id < 0)
                    {
                        foreach (var tt in main.groups)
                        {
                            if (Math.Abs(rep.owner_id) == tt.id)
                            {
                                t.Repostedby = new PostedBy() { PostedByGroup = tt };
                            }
                        }
                    }

                }
            }

            return main;
        }

    }
}
