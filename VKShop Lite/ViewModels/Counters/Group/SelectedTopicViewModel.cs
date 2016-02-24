using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.Core;
using VKCore.API.VKModels.Board;
using VKCore.API.VKModels.Topics;
using VKCore.API.VKModels.Wall;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public  class SelectedTopicViewModel : BaseViewModel
    {
        private BoardRootClass board;

        public ObservableCollection<BoarsClass> messages
        {
            get { return _messages; }
            set { _messages = value;RaisePropertyChanged("messages"); }
        }

        private BoardParamClass param;
        private ObservableCollection<BoarsClass> _messages;

        public SelectedTopicViewModel(BoardParamClass boardParam)
        {
            param = boardParam;
            Load();
        }

        private void Load()
        {
            if (param != null)
            {
                VKRequest.Dispatch<BoardRootClass>(
             new VKRequestParameters(
               SBoard.board_getComments, "group_id", String.Format("{0}", param.group_id), "topic_id", String.Format("{0}", param.topic_id), "extended", "1", "need_likes", "1"),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     var y = res.Data;
                     SetSources(y);
                     messages = y.items.ToObservableCollection();
                 }
             });
            }
          

        }

        private void SetSources(BoardRootClass root)
        {
            if (root != null)
            {
                foreach (var t in root.items)
                {
                    if (t.from_id > 0)
                    {
                        var a = root.profiles.FirstOrDefault(w => w.id == t.from_id);
                        if (a != null) t.posted_by = new PostedBy() { PostedByUser = a };
                    }
                    else
                    {
                        var a = root.groups.FirstOrDefault(w => Math.Abs(w.id) == Math.Abs(t.from_id));
                        if (a != null) t.posted_by = new PostedBy() { PostedByGroup = a };
                    }
                }
            }

        }

        
    }
}
