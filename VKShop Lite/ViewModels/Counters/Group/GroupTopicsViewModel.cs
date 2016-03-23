using System;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Board;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Topics;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.Group;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public class GroupTopicsViewModel : BaseViewModel
    {
        private TopicsClass _topics;
        public ICommand BoardOpenCommand { get; set; }
        private GroupsClass groups = null;
        public TopicsClass Topics
        {
            get { return _topics; }
            set { _topics = value; RaisePropertyChanged("Topics"); }
        }

        void Load(GroupsClass group)
        {
            if (group != null) groups = group;
            BoardOpenCommand =  new DelegateCommand(t =>
            {
                if (t is TopicComment)
                {
                    TopicComment top = t as TopicComment;
                    BoardParamClass param = new BoardParamClass() { group_id = groups.id, topic_id = top.id};
                    NavigateToCurrentPage(param, new Scenario() { ClassType = typeof(SelectedTopicMainPage) });

                }
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
                    var a = topics.groups.FirstOrDefault(w => Math.Abs(w.id) == Math.Abs(t.updated_by));
                    if (a != null) t.UpadtedBy = new PostedBy() { PostedByGroup = a };
                }
            }
            
        }
    }
}
