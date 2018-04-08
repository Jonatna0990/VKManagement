using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System;
using Newtonsoft.Json.Linq;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Link;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Video;
using VKCore.Helpers.Files;
using VKCore.Util;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.Audio;
using VKShop_Lite.UserControls.Map;
using VKShop_Lite.UserControls.PopupControl;
using VKShop_Lite.UserControls.Video;
using VKShop_Lite.Views.Counters.GroupAndUser;

namespace VKShop_Lite.ViewModels.Conversation.Helper
{
    public class MessagesExtensions
    {

#region Attachments

        public static async void AddImage(Action<AttachmentsClass> photo)
        {
            var a = await FilesHelper.GetImageFiles();
            if (a != null)
            {
                var ph = new PhotoClass() { Image = await FilesHelper.LoadImage(a) };
                var attach = new AttachmentsClass() { photo = ph, type = "photo" };
                photo?.Invoke(attach);
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
        public static async void AddDoc(Action<DocClass> doc)
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
                    if (c.Data != null)
                    {
                        var _doc = c.Data;
                        _doc.is_loaded = false;
                        doc?.Invoke(_doc);
                    }


                    if (c.ResultCode != VKResultCode.Succeeded)
                    {
                        PopupEx popup = new PopupEx("Загрузка документа", "При загрузке документа возникла ошибка " + c.Error.error_msg);
                        popup.ShowAsync();
                    }

                });
            }
        }
        public static void AddMapLocation(Action<GeoClass> location)
        {
            UserControlFlyout flyout = new UserControlFlyout();
            var a = new AddMapLocationControl(
               t =>
               {
                   if (t != null)
                   {
                       location?.Invoke(t);

                   }

               });

            flyout.ShowFlyout(a);
        }
        public static void AddAudio(Action<List<AudioClass>> audio)
        {
            UserControlFlyout flyout = new UserControlFlyout();
            var a = new AddAudioControl(new UserClass() { id = Convert.ToInt64(VKSDK.GetAccessToken().UserId) }, t =>
            {
                if (t != null || t.Count == 0)
                {
                    audio?.Invoke(t.ToList());
                }

            });
            flyout.ShowFlyout(a);
        }
        public static void AddVideo(Action<VideoClass> video)
        {
            UserControlFlyout flyout = new UserControlFlyout();
            var a = new AddVideoControl(new UserClass() { id = Convert.ToInt64(VKSDK.GetAccessToken().UserId) }, t =>
            {
                if (t != null)
                {
                    video?.Invoke(t);
                }
            });
            flyout.ShowFlyout(a);
        }
       
        public static void OpenLink(LinkClass link)
        {
            OpenUri(link.url);
        }

        public static void OpenImage()
        {

        }

        public static void OpenVideo(AttachmentsClass video)
        {
           
            if (video != null)
            {
                VideoParamClass video_param = new VideoParamClass()
                {
                    owner_id = video.video.owner_id,
                    video_id = video.video.id,
                };

              //  NavigateToCurrentPage(video_param, new Scenario() { ClassType = typeof(SelectedVideoMainPage) });
            }
        }

        public static void OpenAudio(ObservableCollection<AttachmentsClass> list, AttachmentsClass selected_audio )
        {
            if (list != null)
            {
                
                ObservableCollection<AudioClass> ph = new ObservableCollection<AudioClass>();
                foreach (var p in list)
                    {
                        if (p.audio != null) ph.Add(p.audio);
                    }
                if (selected_audio != null)
                {
                    if (selected_audio.audio != null)
                    {
                        AudioClass audio_param = selected_audio.audio;
                        BasePlayerInstance.Base.Playlist = ph;
                        BasePlayerInstance.Base.PlayTrack(audio_param);
                    }
                }
               
                
            }
        }

        public static void OpenDoc(DocClass link)
        {
            OpenUri(link.url);
        }




        private static void OpenUri(string link)
        {
            Launcher.LaunchUriAsync(new Uri(link));
        }
#endregion


#region Messages

        public static void LoadMessages()
        {
            
        }
        public static void SendMessages()
        {

        }
        public static void ReadMessages()
        {

        }

        public static void Typing()
        {
            
        }
        public static  void GetMsgById()
        {
            
        }
        public static void  DeleteMessage(MessageClass message, Action action)
        {
            if (message != null)
            {
                var commands = new Dictionary<string, Action>();
                commands.Add("Удалить", () => { PrepeareDeleteMessage(message, action); });
                commands.Add("Отмена", null);
                MessagesHelper.ShowDialogMessage("Удаление сообщения", "Вы действительно хотите удалить это сообщение?", commands);

            }
        }
        private static void PrepeareDeleteMessage(MessageClass message, Action action)
        {
            VKRequest.Dispatch<JObject>(
                      new VKRequestParameters(
                          SMessages.messages_delete, "message_ids", message.id.ToString()),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              action?.Invoke();
                          }
                      });
        }
        private static void PrepeareSendMessage()
        {

        }
        public static void CopyMessage(MessageClass message)
        {
            string imgSrc = "ms-appx-web:///assets/windows-sdk.png";
            if (message != null && !string.IsNullOrEmpty(message.body))
            {
                string htmlFormat = HtmlFormatHelper.CreateHtmlFormat(message.body);
                var dataPackage = new DataPackage();
                dataPackage.SetHtmlFormat(htmlFormat);
                var imgUri = new Uri(imgSrc);
                var imgRef = RandomAccessStreamReference.CreateFromUri(imgUri);
                dataPackage.ResourceMap[imgSrc] = imgRef;
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);

            }


        }
        #endregion


    }
}
