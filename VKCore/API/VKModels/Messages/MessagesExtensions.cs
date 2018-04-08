using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Link;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.Video;

namespace VKCore.API.VKModels.Messages
{
    public class MessagesExtensions
    {
        public static void AddImage(Action<PhotoClass> photo)
        {

        }
        public static void AddDoc(Action<DocClass> doc)
        {

        }
        public static void AddMapLocation(Action<GeoClass> location)
        {
            
        }

        public static void AddAudio(Action<List<AudioClass>> audio)
        {
            
        }

        public static void AddVideo(Action<VideoClass> video)
        {
            
        }

        public static void AddSticker(Action<StickerClass> sticker)
        {
        }

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
        private static  void GetMsgById()
        {
            
        }
       
        public static void DeleteMessage()
        {

        }

        public static void OpenLink(LinkClass link)
        {
            OpenUri(link.url);
        }

        public static void OpenImage()
        {
            
        }

        public static void OpenVideo()
        {
            
        }

        public static void OpenAudio()
        {
            
        }

        public static void OpenDoc(DocClass link)
        {
            OpenUri(link.url);
        }




        private static void OpenUri(string link)
        {
            Launcher.LaunchUriAsync(new Uri(link));
        }
        private static void PrepeareSendMessage()
        {

        }
    }
}
