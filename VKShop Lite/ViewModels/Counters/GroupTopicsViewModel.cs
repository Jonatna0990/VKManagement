using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Topics;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters
{
    public class GroupTopicsViewModel : BaseViewModel
    {
        private TopicsClass _topics;

        public TopicsClass Topics
        {
            get { return _topics; }
            set { _topics = value; RaisePropertyChanged("Topics"); }
        }

        void Load(int id)
        {
            VKRequest.Dispatch<TopicsClass>(
                 new VKRequestParameters(
                   SBoard.board_getTopics, "group_id", String.Format("{0}", id), "extended","1", "preview","2"),
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

        public GroupTopicsViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
             this,
             message =>
             {
                 Load(message.id);
             });
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
