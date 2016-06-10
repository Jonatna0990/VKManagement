using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.LongPollServer;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.Helpers;
using VKCore.Helpers.Files;
using VKCore.Util;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Audio;
using VKShop_Lite.UserControls.Images;
using VKShop_Lite.UserControls.Map;
using VKShop_Lite.UserControls.MessagesControl;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.UserControls.Video;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.GroupAndUser;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Admin.Messages
{
    public class GroupConversationViewModel : BaseViewModel, IConversatible 
    {
        private ObservableCollection<MessageClass> messages;
        private Dictionary<string, string> param = null;
        private MarketItem product = null;
        private ObservableCollection<AttachmentsClass> _attachPhotoCollection;
        private string _userWriteText;
        private LockerClass locker;
        private List<StorageFile> _sendPhotos;
        private static LockerClass Locker { get; set; }
        private string _sendingMessage;
        private MessageFrom _messageFrom;
        private bool _addAttachEnabled = true;
        private bool _addMapEnabled = true;
        private ListViewSelectionMode _selectMessageMode = ListViewSelectionMode.None;
        private ObservableCollection<MessageClass> _fwdMessages;
        private int offset = 0;
        private int total_msg_count = 0;
        private bool has_offset = true;
        private GeoClass position = null;
        private AttachmentsClass _selectedPhoto;
        private AttachmentsClass _selectedAudio;
        private List<long> users;
        private ObservableCollection<MessageClass> _messages;
        private MessageRoot _user;
        private UserControlFlyout flyout;
        public string UserWriteText
        {
            get { return _userWriteText; }
            set { _userWriteText = value; RaisePropertyChanged("UserWriteText"); }
        }
        public ICommand SendMessageCommand { get; set; }
        public ICommand SelectedStickerCommand { get; set; }
        public ICommand TypingCommand { get; set; }


        public ICommand AddPhotoAttachCommand { get; set; }
        public ICommand AddPhotoCameraCommand { get; set; }
        public ICommand AddDocAttachCommand { get; set; }
        public ICommand AddAudioAttachCommand { get; set; }
        public ICommand AddVideoAttachCommand { get; set; }
        public ICommand AddMapLocationCommand { get; set; }
        public ICommand DeleteAttachCommand { get; set; }
        public ICommand DeleteMessageCommand { get; set; }
        public ICommand SelectionModeChangeCommand { get; set; }
        public ICommand ReplyFwdMessagesCommand { get; set; }
        public ICommand CopyMessageCommand { get; set; }

        public ICommand LoadMoreCommand { get; set; }
        public ICommand PhotosOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand DocOpenCommand { get; set; }
        public ICommand AudioOpenCommand { get; set; }
        public ICommand MapOpenCommand { get; set; }
        public ICommand WallOpenCommand { get; set; }
        private DialogsClass _dialogs;
        private GroupsClass group;
        public MessageRoot user
        {
            get { return _user; }
            set { _user = value; RaisePropertyChanged("user"); }
        }

        public ObservableCollection<MessageClass> Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("Messages"); }
        }
        public string SendingMessageText
        {
            get { return _sendingMessage; }
            set { _sendingMessage = value; RaisePropertyChanged("SendingMessageText"); }
        }
        public bool AddAttachEnabled
        {
            get { return _addAttachEnabled; }
            set { _addAttachEnabled = value; RaisePropertyChanged("AddAttachEnabled"); }
        }

        public bool AddMapEnabled
        {
            get { return _addMapEnabled; }
            set { _addMapEnabled = value; RaisePropertyChanged("AddMapEnabled"); }
        }
        public DialogsClass Dialogs
        {
            get { return _dialogs; }
            set { _dialogs = value; RaisePropertyChanged("Dialogs"); }
        }

        public ObservableCollection<AttachmentsClass> AttachCollection
        {
            get { return _attachPhotoCollection; }
            set { _attachPhotoCollection = value; RaisePropertyChanged("AttachCollection"); }
        }
        public AttachmentsClass SelectedPhoto
        {
            get { return _selectedPhoto; }
            set { _selectedPhoto = value; RaisePropertyChanged("SelectedPhoto"); }
        }
        public List<StorageFile> SendPhotos
        {
            get { return _sendPhotos; }
            set { _sendPhotos = value; RaisePropertyChanged("SendPhotos"); }
        }
        public AttachmentsClass SelectedAudio
        {
            get { return _selectedAudio; }
            set
            {
                _selectedAudio = value;
                RaisePropertyChanged("SelectedAudio");


            }
        }

        protected override void UserMainPage_OnNavigated(object sender, NavigationEventArgs e)
        {
            base.UserMainPage_OnNavigated(sender, e);
            if (group != null)
            {
                LongPollService.GroupInstatce(group.id).AddNewMessage -= AddNewMessage;
                LongPollService.GroupInstatce(group.id).MessageFlagReset -= MessageFlagReset;
                LongPollService.GroupInstatce(group.id).MakeOnline -= MakeOnline;
                LongPollService.GroupInstatce(group.id).MakeOffline -= MakeOffline;
                LongPollService.GroupInstatce(group.id).WriteMessage -= WriteMessage;
            }
           
        }

        public GroupConversationViewModel(GroupMessagesParam group)
        {
            this.user = group.message;
            this.group = group.group;
            LongPollService.GroupInstatce(group.group.id).AddNewMessage += AddNewMessage;
            LongPollService.GroupInstatce(group.group.id).MessageFlagReset += MessageFlagReset;
            LongPollService.GroupInstatce(group.group.id).MakeOnline += MakeOnline;
            LongPollService.GroupInstatce(group.group.id).MakeOffline += MakeOffline;
            LongPollService.GroupInstatce(group.group.id).WriteMessage += WriteMessage;
            if (user != null)
            {
                locker = new LockerClass(2, user.message.user_id);
                Locker = new LockerClass(5, 0);

                Locker.Locked += Locker_Locked1;
                locker.Locked += Locker_Locked;
                LoadAll();
                
            }
            flyout = new UserControlFlyout();
            param = new Dictionary<string, string>();
            SendPhotos = new List<StorageFile>();
            Messages = new ObservableCollection<MessageClass>();
            if (AttachCollection == null) AttachCollection = new ObservableCollection<AttachmentsClass>();
            AttachCollection.CollectionChanged += AttachPhotoCollection_CollectionChanged;
            AddDocAttachCommand = new DelegateCommand(t => { LoadDoc(); });
            AddAudioAttachCommand = new DelegateCommand(t => { AddAudio(); });
            AddVideoAttachCommand = new DelegateCommand(t => { AddVideo(); });
            AddPhotoAttachCommand = new DelegateCommand(t => { AddAttachPhotos(); });
            DeleteAttachCommand = new DelegateCommand(t =>
            {
                var photo = t as AttachmentsClass;
                AttachCollection.Remove(photo);
            });
            AddPhotoCameraCommand = new DelegateCommand(t => { LoadImage(); });
            AddMapLocationCommand = new DelegateCommand(t => { AddMapLocation(); });
            SelectedStickerCommand = new DelegateCommand(t =>
            {
                var stickerClass = t as StickerClass;
                if (stickerClass != null) PrepareSendMessage(stickerClass.id);
            });
            SendMessageCommand = new DelegateCommand(t => { PrepareSendMessage(); });
            TypingCommand = new DelegateCommand(t => {  });
            LoadMoreCommand = new DelegateCommand(t =>
            {
                if (has_offset)
                {

                   LoadAll();
                }

            });
            PhotosOpenCommand = new DelegateCommand(t =>
            {

                if (t != null)
                {
                    var a = t as ObservableCollection<AttachmentsClass>;

                    ObservableCollection<PhotoClass> ph = new ObservableCollection<PhotoClass>();
                    foreach (var p in a)
                    {
                        if (p.photo != null) ph.Add(p.photo);
                    }
                    var k = new Popup();
                    k.Child = new ImagesFilpViewControl(new PhotoSendParamClass { photos = ph, selected_photo = SelectedPhoto.photo });
                    k.IsLightDismissEnabled = true;
                    k.IsOpen = true;

                }

            });
            VideoOpenCommand = new DelegateCommand(t =>
            {
                if (t != null)
                {
                    AttachmentsClass video = t as AttachmentsClass;
                    if (video != null)
                    {
                        VideoParamClass video_param = new VideoParamClass()
                        {
                            owner_id = video.video.owner_id,
                            video_id = video.video.id,
                        };

                        NavigateToCurrentPage(video_param, new Scenario() { ClassType = typeof(SelectedVideoMainPage) });
                    }
                }


            });
            AudioOpenCommand = new DelegateCommand(t =>
            {
                if (t != null)
                {
                    var a = t as ObservableCollection<AttachmentsClass>;
                    ObservableCollection<AudioClass> ph = new ObservableCollection<AudioClass>();
                    foreach (var p in a)
                    {
                        if (p.audio != null) ph.Add(p.audio);
                    }
                    if (SelectedAudio != null)
                    {
                        if (SelectedAudio.audio != null)
                        {
                            AudioClass audio_param = SelectedAudio.audio;
                            BasePlayerInstance.Base.Playlist = ph;
                            BasePlayerInstance.Base.PlayTrack(audio_param);
                        }
                    }
                }
            });

           
        }
        private void AttachPhotoCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (AttachCollection.Count >= 10) AddAttachEnabled = false;
            else AddAttachEnabled = true;
        }
        private void Locker_Locked(object sender, EventArgs e)
        {
            LockerClass t = sender as LockerClass;
            if (t != null)
            {
                if (user.message.user_id == t.LockerId)
                    UserWriteText = "";
            }
        }
        private void Locker_Locked1(object sender, EventArgs e)
        {
            locker.Stop();
        }
        private async void LoadImage()
        {
            var a = await FilesHelper.GetImageFiles();
            if (a != null)
            {
                var ph = new PhotoClass() { Image = await FilesHelper.LoadImage(a) };
                var attach = new AttachmentsClass() { photo = ph };
                AttachCollection.Add(attach);
                VKUploadRequest.CreatePhotoMessageUploadRequest().Dispatch(a, (prog) =>
                {


                    VKExecute.ExecuteOnUIThread(() =>
                    {
                        ph.is_loaded = prog;
                    });


                }, s =>
                {

                    attach.photo = s.Data;
                });
            }
        }
        private async void AddMapLocation()
        {
            var a = new AddMapLocationControl(
                t =>
                {
                    if (t != null)
                    {
                        AttachCollection.Add(new AttachmentsClass() { location = t });
                        position = t;
                    }
                });
            UserControlFlyout flyout = new UserControlFlyout();
            flyout.ShowFlyout(a);

        }
        private async void LoadDoc()
        {
            var a = await FilesHelper.GetDocFiles();
            if (a != null)
            {
                BasicProperties file_size = await a.GetBasicPropertiesAsync();

                Debug.WriteLine(FilesHelper.GetFileSize(file_size));
                VKUploadRequest.DocProfileUploadRequest(0).Dispatch(a, i => { }, x =>
                {

                }, c =>
                {

                    var doc = c.Data;
                    doc.is_loaded = false;
                    AttachCollection.Add(new AttachmentsClass() { doc = doc });


                    if (c.ResultCode != VKResultCode.Succeeded)
                    {
                        PopupEx popup = new PopupEx("Загрузка документа", "При загрузке документа возникла ошибка " + c.Error.error_msg);
                        popup.ShowAsync();
                    }

                });
            }

        }
        private async void AddVideo()
        {

            var a = new AddVideoControl(new UserClass() { id = Convert.ToInt64(VKSDK.GetAccessToken().UserId) }, t =>
            {
                AttachCollection.Add(new AttachmentsClass() { video = t });
            });
            flyout.ShowFlyout(a);
        }
        private async void AddAudio()
        {
            var a = new AddAudioControl(new UserClass() { id = Convert.ToInt64(VKSDK.GetAccessToken().UserId) }, t =>
            {
                AttachCollection.Add(new AttachmentsClass() { audio = t.FirstOrDefault() });
            });
            flyout.ShowFlyout(a);
        }
        private async void UploadPhoto(List<StorageFile> pictureToUpload)
        {
            foreach (var VARIABLE in pictureToUpload.ToList())
            {
                var ph = new PhotoClass() { Image = await FilesHelper.LoadImage(VARIABLE) };
                var attach = new AttachmentsClass() { photo = ph };
                AttachCollection.Add(attach);
                VKUploadRequest.CreatePhotoMessageUploadRequest().Dispatch(VARIABLE, (prog) =>
                {


                    VKExecute.ExecuteOnUIThread(() =>
                    {
                        ph.is_loaded = prog;
                    });


                }, s =>
                {

                    attach.photo = s.Data;
                });
            }
        }
        private void AddAttachPhotos()
        {
            if (SendPhotos.Count > 0 && SendPhotos.Count < 10)
                UploadPhoto(SendPhotos);

        }
        public void PrepareSendMessage(int stricker_id = 0, GeoClass geo = null)
        {
            param.Clear();
            param.Add("get_group_messages", group.id.ToString());
            if (user == null) return;
            if (product == null)
            {
                if (!param.ContainsKey("user_id"))
                    param.Add("user_id", user.message.user_id.ToString());
            }
            else { if (!param.ContainsKey("peer_id")) param.Add("peer_id", user.message.user_id.ToString()); }
            if (!param.ContainsKey("random_id"))
                param.Add("random_id", Environment.TickCount.ToString());
            else param["random_id"] = Environment.TickCount.ToString();
            //есть стикер
            if (stricker_id != 0)
            {
                param.Add("sticker_id", stricker_id.ToString());
                SendMessage(param);
                return;
            }
            var attachs = ExtractAttachmentFromCollection();
            if (string.IsNullOrEmpty(SendingMessageText) && string.IsNullOrEmpty(attachs)) { return; }

            //есть текст
            if (!(string.IsNullOrEmpty(SendingMessageText))) param.Add("message", SendingMessageText);
            if (position != null)
            {
                param.Add("lat", position.lat.ToString());
                param.Add("long", position.@long.ToString());
            }
            if (!string.IsNullOrEmpty(attachs)) param.Add("attachment", attachs);

            SendMessage(param);
            SendingMessageText = "";
            AttachCollection.Clear();
            param.Clear();
        }
        private string ExtractAttachmentFromCollection()
        {
            string par = "";
            var temp_photos = AttachCollection.Where(t => t.photo != null);
            var temp_doc = AttachCollection.Where(t => t.doc != null);
            var temp_video = AttachCollection.Where(t => t.video != null);
            var temp_audio = AttachCollection.Where(t => t.audio != null);
            if (temp_photos.Any())
            {
                par = temp_photos.Aggregate(par, (current, t) => current + string.Format("photo{0}_{1},", t.photo.owner_id, t.photo.id));
            }
            if (temp_doc.Any())
            {
                par = temp_doc.Aggregate(par, (current, t) => current + string.Format("doc{0}_{1},", t.doc.owner_id, t.doc.id));
            }
            if (temp_video.Any())
            {
                par = temp_video.Aggregate(par, (current, t) => current + string.Format("video{0}_{1},", t.video.owner_id, t.video.id));
            }
            if (temp_audio.Any())
            {
                par = temp_audio.Aggregate(par, (current, t) => current + string.Format("audio{0}_{1},", t.audio.owner_id, t.audio.id));
            }
            return par;

        }

        private void Load()
        {
            if (user != null)
            {
                VKRequest.Dispatch<VKList<MessageClass>>(
            new VKRequestParameters(
                SMessages.messages_getHistory, "user_id", user.message.user_id.ToString(), "count", "30", "get_group_messages", group.id.ToString()),
            (res) =>
            {
                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {
                    if (Messages.Count == 0)
                    {
                        res.Data.items.Reverse();
                        total_msg_count = res.Data.count;
                        var t = res.Data.items.ToObservableCollection();
                        foreach (var VARIABLE in t)
                        {
                            Messages.Add(VARIABLE);
                        }
                        Messenger.Default.Send(t.LastOrDefault());

                    }
                    else
                    {
                        if (total_msg_count > 0 && total_msg_count == offset) has_offset = false;
                        var t = res.Data.items.ToObservableCollection();
                        if (t.Count > 0)
                            foreach (var VARIABLE in t)
                            {
                                Messages.Insert(0, VARIABLE);
                            }
                    }

                    offset += res.Data.items.Count;
                    GetFwdSources();
                }

            });
            }
          

        }
        private void LoadAll()
        {
            Load();
            ReadMessages();
        }
    
        private long ConvertToTimestamp()
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (long)span.TotalSeconds;
        }
        public void SendMessage(Dictionary<string, string> param)
        {
            VKRequest.Dispatch<int>(
               new VKRequestParameters(
                   SMessages.messages_send, param),
               (res) =>
               {
                   var q = new MessageClass();
                   if (param.ContainsKey("message"))
                   {
                       string a = "";
                       param.TryGetValue("message", out a);
                       q._out = 1;
                       q.date = ConvertToTimestamp();
                       q.body = a;

                       // this.Add(q);

                   }
                   Logger(res.ResultCode);

                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       q.id = res.Data;


                   }
                   else
                   {
                       var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                       t.ShowAsync();
                   }

               });
        }
        public void ReadMessages()
        {
            VKRequest.Dispatch<int>(
           new VKRequestParameters(
               SMessages.messages_markAsRead, "peer_id", user.message.user_id.ToString(), "get_group_messages", group.id.ToString()),
           (res) =>
           {
               Logger(res.ResultCode);

               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                 
               }
             

           });
        }
        private void GetMsgById(long id)
        {
            VKRequest.Dispatch<VKList<MessageClass>>(
                new VKRequestParameters(
                    SMessages.messages_getById, "message_ids", id.ToString(), "get_group_messages", group.id.ToString()),
                (res) =>
                {
                    var q = res.ResultCode;
                    Logger(res.ResultCode);
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        if (res.Data.items.FirstOrDefault()._out == 0)
                        {
                            ReadMessages();
                        }
                        var msg = res.Data.items.FirstOrDefault();
                        Messages.Add(msg);
                        Messenger.Default.Send(msg);
                        if (msg.fwd_messages != null) GetFwdSources();

                    }
                    else
                    {
                        var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                        t.ShowAsync();
                    }

                });
        }
        private void GetFwdSources()
        {
            List<long> user_list = new List<long>();
            List<long> group_list = new List<long>();
            string users = "";
            string groups = "";
            GetFwdMessagesSources(Messages, group_list, user_list);
            user_list = user_list.Distinct().ToList();
            group_list = group_list.Distinct().ToList();
            users = string.Join(",", user_list.Select(n => n.ToString()).ToArray());
            groups = string.Join(",", group_list.Select(n => n.ToString()).ToArray());
            SetFwdSources(users, groups);
        }
        private void GetFwdMessagesSources(ObservableCollection<MessageClass> messages, List<long> group, List<long> users)
        {
            if (messages == null) return;
            foreach (var a in messages)
            {
                if (a.fwd_messages != null)
                    GetFwdMessageNestedLevel(a, users, group);
            }

        }
        private void GetFwdMessageNestedLevel(MessageClass fwd_message, List<long> users, List<long> groups)
        {
            if (fwd_message == null) return;

            if (fwd_message.fwd_messages != null)
            {
                foreach (var q in fwd_message.fwd_messages)
                {
                    if (q.user_id < 0) { groups.Add(Math.Abs(q.user_id)); }
                    else { users.Add(q.user_id); }
                    GetFwdMessageNestedLevel(q, users, groups);
                }

            }
        }

        private void SetFwdMessagesSources(ObservableCollection<MessageClass> messages, List<UserClass> users = null, List<GroupsClass> groups = null)
        {

            if (users != null)
                foreach (var a in messages)
                {
                    if (a.fwd_messages != null)
                        SetUsers(a, users);
                }
            if (groups != null) foreach (var a in messages)
                {
                    if (a.fwd_messages != null)
                        SetGroups(a, groups);
                }


        }


        private void SetUsers(MessageClass message, List<UserClass> users)
        {
            if (message == null) return;

            if (message.fwd_messages != null)
            {
                foreach (var q in message.fwd_messages)
                {
                    if (q.user_id > 0)
                    {
                        var a = users.FirstOrDefault(w => w.id == q.user_id);
                        if (a != null) q.MsgFrom = new MessageFrom(a);
                    }
                    SetUsers(q, users);
                }

            }

        }

        private void SetGroups(MessageClass message, List<GroupsClass> groups)
        {
            if (message == null) return;

            if (message.fwd_messages != null)
            {
                foreach (var q in message.fwd_messages)
                {
                    if (q.user_id < 0)
                    {
                        var a = groups.FirstOrDefault(w => -w.id == q.user_id);
                        if (a != null)
                            q.MsgFrom = new MessageFrom(null, a);
                    }

                    SetGroups(q, groups);
                }

            }

        }

        private void SetFwdSources(string users = "", string groups = "")
        {
            if (string.IsNullOrEmpty(users) && string.IsNullOrEmpty(groups)) return;
            else
            {

                if (!string.IsNullOrEmpty(users))
                {
                    VKRequest.Dispatch<List<UserClass>>(
                        new VKRequestParameters(
                            SUsers.user_get, "user_ids", users, "fields", "photo_100"),
                        (res) =>
                        {
                            var q = res.ResultCode;
                            if (res.ResultCode == VKResultCode.Succeeded)
                            {
                                SetFwdMessagesSources(Messages, res.Data);
                            }
                        });
                }
                if (!string.IsNullOrEmpty(groups))
                {
                    VKRequest.Dispatch<List<GroupsClass>>(
                       new VKRequestParameters(
                         SGroups.groups_getById, "group_ids", groups, "fields", "photo_100"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               SetFwdMessagesSources(Messages, null, res.Data);


                           }
                       });
                }
            }

            var aasd = Messages;
        }
       private void AddNewMessage(object sender, LongPollMessageEventArgs e)
        {
            if (locker.LockerId == e.from_id && locker.IsLocked) { locker.Stop(); }
            if (is_enabled && e.from_id == locker.LockerId)
                GetMsgById(e.mid);

        }
        private void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.id == e.mid && is_enabled)
                {

                    List<VkLongPollMessageFlags> s = MessageFlagsHelper.CheckFlags(Convert.ToInt32(e.flags));
                    if (s.Contains(VkLongPollMessageFlags.Unread))
                    {
                        VARIABLE.read_state = 1;
                    }
                }
            }

        }
        private void MakeOnline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.user_id == e.uid)
                {

                    VARIABLE.MsgFrom.FromUser.SetApplicationIcon(e.extra, true);
                }
            }


        }
        private void MakeOffline(object sender, LongPollUserStatusEventArgs e)
        {
            foreach (var VARIABLE in Messages.ToList())
            {
                if (VARIABLE.user_id == e.uid)
                {

                    VARIABLE.MsgFrom.FromUser.SetApplicationIcon(0);
                }
            }
        }
        private void WriteMessage(object sender, LongPollUserEventArgs e)
        {
            if (locker.LockerId == e.uid && locker.IsLocked && is_enabled) locker.AddSeconds(3);
            else
            {
                if (e.uid == user.message.user_id && user.message.chat_id == null)
                {
                    UserWriteText = "Набирает сообщение"; locker.Start();
                }

            }
        }
        void Logger(object log)
        {
            Debug.WriteLine(log);
        }

    }
}
