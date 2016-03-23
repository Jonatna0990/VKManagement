using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Board;
using VKCore.API.VKModels.Wall;
using VKCore.Helpers;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public  class SelectedTopicViewModel : BaseViewModel
    {
        private BoardParamClass param;
        private ObservableCollection<BoarsClass> _messages;
        private string _sendingCommentText;
        private BoardRootClass board;
        public ICommand SendCommentCommand { get; set; }
        public ICommand DeleteAttachCommand { get; set; }

        

        public ObservableCollection<BoarsClass> comments
        {
            get { return _messages; }
            set { _messages = value;RaisePropertyChanged("comments"); }
        }

        

        public string SendingCommentText
        {
            get { return _sendingCommentText; }
            set { _sendingCommentText = value;RaisePropertyChanged("SendingCommentText"); }
        }

        public SelectedTopicViewModel(BoardParamClass boardParam)
        {
            comments = new ObservableCollection<BoarsClass>();
            param = boardParam;
            SendCommentCommand = new DelegateCommand(t =>
            {

                SendComment();
            });
            Load();
        }

        private void SendComment()
        {
            if (param != null)
            {
                VKRequest.Dispatch<int>(
             new VKRequestParameters(
               SBoard.board_addComment, "group_id", String.Format("{0}", param.group_id), "topic_id", String.Format("{0}", param.topic_id), "text", SendingCommentText),
             (res) =>
             {
                 var q = res.ResultCode;
                 if (res.ResultCode == VKResultCode.Succeeded)
                 {
                     var y = res.Data;
                     GetCommentById(y);
                     SendingCommentText = "";
                 }
             });
            }
        }

        private void GetCommentById(int id)
        {

            VKRequest.Dispatch<BoardRootClass>(
         new VKRequestParameters(
           SBoard.board_getComments, "group_id", String.Format("{0}", param.group_id), "topic_id", String.Format("{0}", param.topic_id), "extended", "1", "need_likes", "1", "start_comment_id", id.ToString(),"count","1"),
         (res) =>
         {
             var q = res.ResultCode;
             if (res.ResultCode == VKResultCode.Succeeded)
             {
                 var y = res.Data;
                 SetSources(y);

                 comments.Add(y.items.FirstOrDefault());

                 Messenger.Default.Send(y.items.FirstOrDefault());
             }
         });
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
                     var temp = y.items.ToObservableCollection();
                     foreach (var t in temp)
                     {
                         comments.Add(t);
                     }
                     Messenger.Default.Send(temp.LastOrDefault());
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
