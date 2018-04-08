using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json.Linq;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Link;
using VKCore.API.VKModels.LongPollServer;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.Helpers;
using VKCore.Helpers.Files;
using VKCore.UserControls.CaptchaControl;
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
using MessagesExtensions = VKShop_Lite.ViewModels.Conversation.Helper.MessagesExtensions;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class MessagesCollection : BaseViewModel, IConversatible
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

        private LockerClass GetMessagesLocker = null;

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
        private MessageClass _sendParam;
        private UserControlFlyout flyout;
    

        public ICommand SendMessageCommand { get; set; }
        public ICommand SelectedStickerCommand { get; set; }
        public ICommand TypingCommand { get; set; }

        public ICommand ResendMessageCommand { get; set; }
        public ICommand AddPhotoAttachCommand { get; set; }
        public ICommand AddPhotoCameraCommand { get; set; }
        public ICommand AddDocAttachCommand { get; set; }
        public ICommand AddAudioAttachCommand { get; set; }
        public ICommand AddVideoAttachCommand { get; set; }
        public  ICommand AddMapLocationCommand { get; set; }


        public ICommand DeleteAttachCommand { get; set; }
        public ICommand DeleteMessageCommand { get; set; }

        public ICommand SelectionModeChangeCommand { get; set; }
        public ICommand ReplyFwdMessagesCommand { get; set; }
        public ICommand CopyMessageCommand { get; set; }
        public ICommand LoadMoreCommand { get; set; }



        public ICommand PhotosOpenCommand { get; set; }
        public ICommand VideoOpenCommand { get; set; }
        public ICommand AudioOpenCommand { get; set; }
        public ICommand MapOpenCommand { get; set; }
        public ICommand WallOpenCommand { get; set; }
        public ICommand LinkOpenCommand { get; set; }
        public ICommand DocOpenCommand { get; set; }
        public ListViewSelectionMode SelectMessageMode
        {
            get { return _selectMessageMode; }
            set { _selectMessageMode = value; RaisePropertyChanged("SelectMessageMode"); }
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

        public AttachmentsClass SelectedAudio
        {
            get { return _selectedAudio; }
            set
            {_selectedAudio = value;
                RaisePropertyChanged("SelectedAudio");
                
               
            }
        }
        public MessageClass SendParam
        {
            get { return _sendParam; }
            set { _sendParam = value; RaisePropertyChanged("SendParam"); }
        }
        public MessageFrom messageFrom
        {
            get { return _messageFrom; }
            set { _messageFrom = value; RaisePropertyChanged("messageFrom"); }
        }

        public string SendingMessageText
        {
            get { return _sendingMessage; }
            set { _sendingMessage = value; RaisePropertyChanged("SendingMessageText"); }
        }
        public ObservableCollection<MessageClass> Messages
        {
            get { return messages; }
            set { messages = value; RaisePropertyChanged("Messages"); }
        }
        public List<StorageFile> SendPhotos
        {
            get { return _sendPhotos; }
            set { _sendPhotos = value; RaisePropertyChanged("SendPhotos"); }
        }
        public string UserWriteText
        {
            get { return _userWriteText; }
            set { _userWriteText = value; RaisePropertyChanged("UserWriteText"); }
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

        public ObservableCollection<MessageClass> FwdMessages
        {
            get { return _fwdMessages; }
            set { _fwdMessages = value; RaisePropertyChanged("FwdMessages"); }
        }

        public MessagesCollection(MessageClass message, MarketItem item =null)
        {
            GetMessagesLocker = new LockerClass(1,-10);
          
            if (PlayerBase.Instance.CurrentTrack !=null)
            {
                SelectedAudio = new AttachmentsClass();
                SelectedAudio.audio =  PlayerBase.Instance.CurrentTrack;
            }
            RegisterTasks("dialogs");
            SendParam = message;
            if (SendParam != null)
            {
                locker = new LockerClass(2, SendParam.user_id);
                Locker = new LockerClass(5, 0);
                Locker.Locked += Locker_Locked1;
                locker.Locked += Locker_Locked;
                LoadAll();
            
            }
            flyout = new UserControlFlyout();
            param = new Dictionary<string, string>();
            SendPhotos = new List<StorageFile>();
            FwdMessages = new ObservableCollection<MessageClass>();
            Messages = new ObservableCollection<MessageClass>() ;
            FwdMessages.CollectionChanged += FwdMessages_CollectionChanged;
            if(AttachCollection ==null) AttachCollection = new ObservableCollection<AttachmentsClass>();
            AttachCollection.CollectionChanged += AttachPhotoCollection_CollectionChanged;
            AddDocAttachCommand = new DelegateCommand(t =>{LoadDoc();});
            AddAudioAttachCommand = new DelegateCommand(t => { AddAudio(); });
            AddVideoAttachCommand = new DelegateCommand(t => { AddVideo(); });
            AddPhotoAttachCommand = new DelegateCommand(t =>{ AddAttachPhotos();});
            ResendMessageCommand = new DelegateCommand(t =>
            {
              
                if (t != null) PrepareSendMessage(0,null,t as MessageClass);
            });
            DeleteAttachCommand = new DelegateCommand(t =>
            {
                var photo = t as AttachmentsClass;
                AttachCollection.Remove(photo);
            });
            SelectionModeChangeCommand = new DelegateCommand(t =>{SelectionModeChange();});
            AddPhotoCameraCommand = new DelegateCommand(t =>{LoadImage();});
            AddMapLocationCommand = new DelegateCommand(t =>{AddMapLocation();});
            SelectedStickerCommand = new DelegateCommand(t =>
            {
                var stickerClass = t as StickerClass;
                if (stickerClass != null) PrepareSendMessage(stickerClass.id);
            });
            SendMessageCommand = new DelegateCommand(t =>{PrepareSendMessage();});
            TypingCommand = new DelegateCommand(t =>{Typing();});
            LoadMoreCommand= new DelegateCommand(t =>
            {
                if (has_offset && !GetMessagesLocker.IsLocked)
                {
                    GetMessagesLocker.Start();
                    LoadMessages();
                }
             
            });

            ReloadCommand = new DelegateCommand(t=> {LoadAll();});

            PhotosOpenCommand = new DelegateCommand(t =>
            {
              
                if (t != null && SelectedPhoto != null)
                {
                    var a = t as ObservableCollection<AttachmentsClass>;

                    ObservableCollection<PhotoClass> ph = new ObservableCollection<PhotoClass>();
                    if (a != null)
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
                    MessagesExtensions.OpenAudio(a,SelectedAudio);

                    ObservableCollection<AudioClass> ph = new ObservableCollection<AudioClass>();
                    if (a != null)
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
            DeleteMessageCommand = new DelegateCommand(t=> { DeleteMessage(t as MessageClass); });
            CopyMessageCommand = new DelegateCommand(t=> { MessagesExtensions.CopyMessage(t as MessageClass);  });
            if (item != null)
            {
                SendingMessageText = "Здравствуйте! Меня заинтересовал данный товар "+ ProductLinkCreator(item);
                product = item;
            }
            LinkOpenCommand = new DelegateCommand(t =>
            {
                AttachmentsClass link = t as AttachmentsClass;
                if (link != null)
                {
                    MessagesExtensions.OpenLink(link.link);
                }
            });
            DocOpenCommand = new DelegateCommand(t =>
            {
                AttachmentsClass link = t as AttachmentsClass;
                if (link != null)
                {

                    MessagesExtensions.OpenDoc(link.doc);
                }
            });
            EnterPressed();

        }

        protected override void UserMainPage_OnNavigated(object sender, NavigationEventArgs e)
        {
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

        private void LoadAll()
        {
            TaskStarted("dialogs");
            LoadMessages();
          
        }

        private void EnterPressed()
        {
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (str == "Windows.Mobile")
            {
                Windows.UI.Xaml.Window.Current.CoreWindow.KeyDown += (sender, arg) =>
                {
                    if (arg.VirtualKey == Windows.System.VirtualKey.Enter)
                    {

                      //  PrepareSendMessage();
                    }

                };
            }
           
        }
        private void FwdMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (FwdMessages.Count == 0) SelectionModeChange();
        }

      
        private async void AddMapLocation()
        {
            MessagesExtensions.AddMapLocation(t =>
            {
                AttachCollection.Add(new AttachmentsClass() { location = t, type = "map"});
            });
        }
        private void AttachPhotoCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (AttachCollection.Count >= 10) AddAttachEnabled = false;
            else AddAttachEnabled = true;
        }

      
        private const string imgSrc = "ms-appx-web:///assets/windows-sdk.png";

     
        private void DeleteMessage(MessageClass message)
        {
            MessagesExtensions.DeleteMessage(message, () =>
            {
                Messages.Remove(message);
            });
        }

        private  void LoadImage()
        {
             MessagesExtensions.AddImage(t =>
                {
                    AttachCollection.Add(t);
                });
         
        }
        private  void LoadDoc()
        {
            MessagesExtensions.AddDoc(t =>
            {
                AttachCollection.Add(new AttachmentsClass() { doc = t, type = "doc" });
            });
           

        }

        private  void AddVideo()
        {
            MessagesExtensions.AddVideo(t =>
            {
                AttachCollection.Add(new AttachmentsClass() { video = t, type = "video" });
            });
        }
        private void AddAudio()
        {

            MessagesExtensions.AddAudio(t =>

            {
                if (t.Count == 1)
                    AttachCollection.Add(new AttachmentsClass() { audio = t.FirstOrDefault(), type = "audio" });
                else
                    foreach (var m in t)
                    {
                        AttachCollection.Add(new AttachmentsClass() { audio = m, type = "audio" });

                    }
            });
           
        }
       
        private async void UploadPhoto(List<StorageFile> pictureToUpload)
        {
            foreach (var VARIABLE in pictureToUpload.ToList())
            {
                var ph = new PhotoClass() {Image = await FilesHelper.LoadImage(VARIABLE)};
                var attach = new AttachmentsClass() {photo = ph, type="photo" };
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
        private void CopyMessageText(MessageClass message)
        {
            
        }

        private void SelectionModeChange()
        {
            if (SelectMessageMode == ListViewSelectionMode.None) SelectMessageMode = ListViewSelectionMode.Multiple;
            else SelectMessageMode = ListViewSelectionMode.None;
        }

        private void FwdMessagesReply()
        {
            
        }
        public static string ProductLinkCreator(MarketItem item)
        {
            string link = "";

            link = @"http://vk.com/club" + Math.Abs(item.owner_id)+ "?w=product" + item.owner_id+ "_"+item.id;
            return link;
        }

        private void SetSourceInfo(List<UserClass> users, List<GroupsClass> group=null )
        {
            if (SendParam == null) return;
            if (users != null)
            {
                if(messageFrom == null && SendParam.chat_id == null)
                    messageFrom = new MessageFrom(users.Select(a => a).FirstOrDefault(x => x.id == SendParam.user_id));
                if (users.Count >= 1 && SendParam.chat_id != null)
                {
                  
                  foreach (var t in Messages)
                   {
                       foreach (var y in users)
                       {
                               if(t.user_id == y.id) t.MsgFrom = new MessageFrom(y);
                       }

                  }
                }
            }
            else
            {
                if (messageFrom == null)

                    messageFrom = new MessageFrom(null, group.Select(a => a).FirstOrDefault(x => x.id == SendParam.user_id));

            }
           

    
                      

            
            
        }

        private void GetFwdSources()
        {
            if (SendParam == null) return;
            List<long> user_list = new List<long>();
            List<long> group_list = new List<long>();
            string users = "";
            string groups = "";
            if (SendParam.chat_id != null)
            {
                user_list.AddRange(Messages.Select(t => t.from_id));
            }
            else 
            {
                if(SendParam.user_id<0) group_list.Add(Math.Abs(SendParam.user_id));
                else user_list.Add(SendParam.user_id);
            }
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
            if (message?.fwd_messages != null)
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
            if (message?.fwd_messages != null)
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
                                SetSourceInfo(res.Data);
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
                               SetSourceInfo(null,res.Data);


                           }
                       });
                }
            }

        }
        private void Locker_Locked(object sender, EventArgs e)
        {
            LockerClass t = sender as LockerClass;
            if (SendParam.user_id == t?.LockerId)
                UserWriteText = "";
        }

     
        private void Locker_Locked1(object sender, EventArgs e)
        {
           locker.Stop();
        }

    
        public void PrepareSendMessage(int stricker_id = 0, GeoClass geo = null, MessageClass message = null)
        {
            param.Clear();
            MessageClass msg = null;
            if (SendParam == null) return;
            if (message == null)
                msg = new MessageClass()
                {
                    state = MessageSendState.Sending,
                    _out = 1,
                    date = ConvertToTimestamp(),
                    read_state = 1
                };
            else msg = message;
            if (AttachCollection.Count > 0)
            {

                msg.attachments = new ObservableCollection<AttachmentsClass>();
                foreach (var t in AttachCollection)
                {
                    if (t != null ) msg.attachments.Add(t);
                }
            }
            if (product == null)
            {
                if (SendParam.chat_id != null)
                {
                    if (!param.ContainsKey("chat_id")) param.Add("chat_id", SendParam.chat_id.ToString());
                    else param["chat_id"] = SendParam.chat_id.ToString();
                }
                    
                else
                {
                    if (!param.ContainsKey("user_id"))
                        param.Add("user_id", SendParam.user_id.ToString());
                    else param["user_id"] = SendParam.user_id.ToString();
                }
            }
            else
            {

                if (!param.ContainsKey("peer_id")) param.Add("peer_id", SendParam.user_id.ToString());
                else param["peer_id"] = SendParam.user_id.ToString();
            }
            if (!param.ContainsKey("random_id"))
                param.Add("random_id", Environment.TickCount.ToString());
            else param["random_id"] = Environment.TickCount.ToString();
            //есть стикер
            if (stricker_id != 0)
            {
                param.Add("sticker_id", stricker_id.ToString());
                msg.attachments = new ObservableCollection<AttachmentsClass>();
                msg.attachments.Add(new AttachmentsClass() {sticker = new StickerClass(stricker_id, String.Format("http://vk.com/images/stickers/{0}/128.png",stricker_id)), type = "sticker"});
                SendMessage(param, t =>
                {
                    msg.id = t;
                    
                    if (t > 0)
                    {
                        msg.state = MessageSendState.Sent;
                        msg.read_state = 0;
                        SendingMessageText = "";
                        AttachCollection.Clear();
                        param.Clear();
                    }
                    else msg.state = MessageSendState.Error;
                });
                Messages.Add(msg);
                Messenger.Default.Send(msg);
                return;
            }
            var attachs = ExtractAttachmentFromCollection();
            if (string.IsNullOrEmpty(SendingMessageText) &&  string.IsNullOrEmpty(attachs) && position == null) { return; }

            //есть текст
            if (!(string.IsNullOrEmpty(SendingMessageText)))
            {
             
                param.Add("message", SendingMessageText);
                msg.body = SendingMessageText;
            }
            //есть карта
            if (position != null)
            {
                param.Add("lat", position.lat.ToString().Replace(',', '.'));
                param.Add("long", position.@long.ToString().Replace(',', '.'));
                msg.geo = new GeoClass() { lat = position.lat, @long = position.@long };
            }
            if (!string.IsNullOrEmpty(attachs)) param.Add("attachment", attachs);

            if (message == null)
             Messages.Add(msg);
            Messenger.Default.Send(msg);
            SendMessage(param, t =>
            {
                msg.id = t;
                if(t>0)
                {
                    msg.state = MessageSendState.Sent;
                    msg.read_state = 0;
                    SendingMessageText = "";
                    AttachCollection.Clear();
                    param.Clear();
                }
                else msg.state = MessageSendState.Error;
            });
        
            position = null;
        }

        private string ExtractAttachmentFromCollection()
        {
            string par = "";
            var temp_photos = AttachCollection.Where(t => t.photo != null);
            var temp_doc = AttachCollection.Where(t => t.doc != null);
            var temp_video = AttachCollection.Where(t => t.video != null);
            var temp_audio = AttachCollection.Where(t => t.audio != null);
            var temp_map = AttachCollection.Where(t => t.location != null);
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
            if (temp_map.Any())
            {
                position = temp_map.FirstOrDefault().location;
            }
            return par;

        }

     
        private void LoadChatMessages(int chat_id)
        {
            var chat = chat_id + 2000000000;
            VKRequest.Dispatch<VKList<MessageClass>>(
           new VKRequestParameters(
               SMessages.messages_getHistory, "peer_id", chat.ToString(), "count", "30", "offset", offset.ToString()),
           (res) =>
           {
               var q = res.ResultCode;
               if (res.ResultCode == VKResultCode.Succeeded)
               {
                   if (Messages.Count == 0)
                   {
                       total_msg_count = res.Data.count;
                       if (total_msg_count <= 30) has_offset = false;
                       res.Data.items.Reverse();
                       var t = res.Data.items.ToObservableCollection();
                       foreach (var VARIABLE in t)
                       {
                           Messages.Add(VARIABLE);
                       }
                       TaskFinished("dialogs");
                       ReadMessages(t.FirstOrDefault().id);
                   
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
                       ReadMessages(t.FirstOrDefault().id);
                   }
                   offset += res.Data.items.Count;
                   GetFwdSources();

               }

           });
        }

        private  void LoadUserOrGroupMessages(long user_id)
        {
            VKRequest.Dispatch<VKList<MessageClass>>(
            new VKRequestParameters(
                SMessages.messages_getHistory, "user_id", user_id.ToString(), "count","30", "offset", offset.ToString()),
            (res) =>
            {
                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {
                    if(Messages.Count == 0)
                    {
                        var m = res.Data.items;
                        m.Reverse();
                        total_msg_count = res.Data.count;
                        var t =m.ToObservableCollection();
                        foreach (var VARIABLE in t)
                        {
                            Messages.Add(VARIABLE);
                        }
                        Messenger.Default.Send(t.LastOrDefault());
                        TaskFinished("dialogs");
                        ReadMessages(m.FirstOrDefault().id);

                    }
                    else
                    {
                        if (total_msg_count > 0 && total_msg_count == offset) has_offset = false;
                        var t = res.Data.items.ToObservableCollection();
                        if(t.Count > 0)
                        foreach (var VARIABLE in t)
                        {
                            Messages.Insert(0,VARIABLE);
                        }
                        ReadMessages(t.FirstOrDefault().id);
                    }
                   
                    offset += res.Data.items.Count;
                    GetFwdSources();
                }
                else
                {
                    var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                    t.ShowAsync();
                }

            });
        }
        public void LoadMessages(int offset = 0)
        {
            if (SendParam == null) return;
            if (SendParam.chat_id == null) LoadUserOrGroupMessages(SendParam.user_id);
            else LoadChatMessages((int)SendParam.chat_id);


        }

       
        private void CaptchaRequest(VKCaptchaUserRequest captchaUserRequest, Action<VKCaptchaUserResponse> action)
        {
            new VKCaptchaRequestUserControl().ShowCaptchaRequest(captchaUserRequest, action);
        }
        private long ConvertToTimestamp()
        {
            //create Timespan by subtracting the value provided from
            //the Unix Epoch
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 1, 0, 0, 0).ToLocalTime());

            //return the total seconds (which is a UNIX timestamp)
            return (long)span.TotalSeconds;
        }
        public void SendMessage(Dictionary<string, string> param,Action<int> callbackAction  )
        {
            if (param != null)
                VKRequest.Dispatch<int>(
                    new VKRequestParameters(
                        SMessages.messages_send, param),
                    (res) =>
                    {
                        var q = new MessageClass();
                      
                        Logger(res.ResultCode);

                        if (res.ResultCode == VKResultCode.Succeeded)
                        {
                            q.id = res.Data;
                            callbackAction.Invoke(q.id);
                        }
                        else
                        {
                            callbackAction.Invoke(0);
                            var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                            t.ShowAsync();
                        }

                    });
        }

        public void ReadMessages(long start_message_id)
        {
            
            string peer = "";
            if (SendParam != null)
            {
                if( SendParam.chat_id != null) peer = (SendParam.chat_id + 2000000000).ToString();
                else  peer = SendParam.user_id.ToString();
                VKRequest.Dispatch<int>(
            new VKRequestParameters(
                SMessages.messages_markAsRead, "peer_id", peer, "start_message_id", start_message_id.ToString()),
            (res) =>
            {
                Logger(res.ResultCode);

                var q = res.ResultCode;
                if (res.ResultCode == VKResultCode.Succeeded)
                {
                    TaskFinished("dialogs");
                }
                else TaskError("dialogs", res.Error.error_msg);


        });
            }
              
         
        }
        private async void GetMsgById(long id, bool relay=false)
        {

            if (id == 0) return;
            if(relay) await Task.Delay(500);
            VKRequest.Dispatch<VKList<MessageClass>>(
                new VKRequestParameters(
                    SMessages.messages_getById, "message_ids", id.ToString()),
                (res) =>
                {
                    var q = res.ResultCode;
                    Logger(res.ResultCode);
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        var t = res.Data.items.FirstOrDefault();
                        var msg = res.Data.items.FirstOrDefault();
                        if (t._out == 0)
                        {
                            ReadMessages(t.id);
                            Messages.Add(msg);
                        }
                 
                       // Messages.Add(msg);
                        Messenger.Default.Send(msg);
                        if (msg.fwd_messages != null) GetFwdSources();
                        
                    }
                    else
                    {
                        if (res.ResultCode == VKResultCode.TooManyRequestsPerSecond)
                        GetMsgById(id,true);
                        
                        else
                        {
                            var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                            t.ShowAsync();
                        }
                    }

                });
        }
        public void Typing()
        {
            if (Locker.IsLocked && Locker.LockerId == 0) { }
            else
            {
                Locker.Start();
                if (SendParam != null)
                    VKRequest.Dispatch<int>(
                        new VKRequestParameters(
                            SMessages.messages_setActivity, "user_id", SendParam.user_id.ToString(), "type", "typing"),
                        (res) =>
                        {
                            Logger(res.ResultCode);

                            if (res.ResultCode == VKResultCode.Succeeded)
                            {

                                var t = res;
                            }
                            else
                            {
                                var t = new MessageDialog(res.Error.error_msg, "Ошибка");
                                t.ShowAsync();
                            }
                        });
            }
        }

        protected override void AddNewMessageChat(object sender, LongPollMessageChatEventArgs e)
        {
             GetMsgById(e.mid);
        }

        protected override void AddNewMessage(object sender, LongPollMessageEventArgs e)
        {
            if (locker.LockerId == e.from_id && locker.IsLocked) { locker.Stop(); }
            if (is_enabled && e.from_id ==locker.LockerId)
                GetMsgById(e.mid);

        }
        protected override void MessageFlagReset(object sender, LongPollMessageFlagsEventArgs e)
        {
            if (Messages != null)
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

        protected override void MakeOnline(object sender, LongPollUserStatusEventArgs e)
        {
            if (Messages != null)
                foreach (var VARIABLE in Messages.ToList())
                {
                    if (VARIABLE.user_id == e.uid)
                    {

                        VARIABLE.MsgFrom.FromUser.SetApplicationIcon(e.extra, true);
                    }
                }
        }

        protected override void MakeOffline(object sender, LongPollUserStatusEventArgs e)
        {
            if (Messages != null)
                foreach (var VARIABLE in Messages.ToList())
                {
                    if (VARIABLE.user_id == e.uid)
                    {

                        VARIABLE.MsgFrom.FromUser.SetApplicationIcon(0);
                    }
                }
        }

        protected override void WriteMessage(object sender, LongPollUserEventArgs e)
        {
            if (locker.LockerId == e.uid && locker.IsLocked && is_enabled) locker.AddSeconds(3);
            else
            {
                if (e.uid == SendParam.user_id && SendParam.chat_id == null)
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