using System;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Topics;
using VKCore.API.VKModels.Wall;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Profile;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public class GroupTopicsViewModel : BaseViewModel
    {
        private TopicsClass _topics;
        public ICommand BoardOpenCommand { get; set; }
        public TopicsClass Topics
        {
            get { return _topics; }
            set { _topics = value; RaisePropertyChanged("Topics"); }
        }

        void Load(GroupsClass group)
        {
            BoardOpenCommand =  new DelegateCommand(t =>
            {
                NavigateToCurrentPage(t, new Scenario() { ClassType = typeof(ProfileMainPage) });
            });

            VKRequest.Dispatch<TopicsClass>(
                 new VKRequestParameters(
                   SBoard.board_getTopics, "group_id", String.Format("{0}", group.id), "extended","1", "preview","2"),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         Topics = res.Data;
                         SetSources(Topics);
                     }
                 });
        }

        public GroupTopicsViewModel(GroupsClass group)
        {
            Load(group);
        }

        private void SetSources(TopicsClass topics)
        {
            if(topics ==null ) return;
            foreach (var t in topics.items)
            {
                if (t.updated_by > 0)
                {
                    var a = topics.profiles.FirstOrDefault(w => w.id == t.updated_by);
                    if(a !=null) t.UpadtedBy = new PostedBy() {PostedByUser = a};
                }
                else
                {
                    var a = topics.groups.FirstOrDefault(w => w.id == t.updated_by);
                    if (a != null) t.UpadtedBy = new PostedBy() { PostedByGroup = a };
                }
            }
            
        }
    }
}
