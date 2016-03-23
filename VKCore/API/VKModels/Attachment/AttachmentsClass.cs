using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using VKCore.API.VKModels.Audio;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Gift;
using VKCore.API.VKModels.Link;
using VKCore.API.VKModels.Note;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Poll;
using VKCore.API.VKModels.Sticker;
using VKCore.API.VKModels.Video;
using VKCore.API.VKModels.Wall;
using VKCore.Converters.ProfileConverter;

namespace VKCore.API.VKModels.Attachment
{
    public class AttachmentsClass : ViewModelBase
    {
        private DocClass _doc;
        private AudioClass _audio;

        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("photo")]
        public PhotoClass photo { get; set; }
        [JsonProperty("link")]
        public LinkClass link { get; set; }

        [JsonProperty("doc")]
        public DocClass doc
        {
            get { return _doc; }
            set { _doc = value;RaisePropertyChanged("doc"); }
        }

        [JsonProperty("audio")]
        public AudioClass audio
        {
            get { return _audio; }
            set { _audio = value; RaisePropertyChanged("audio"); }
        }

        [JsonProperty("video")]
        public VideoClass video { get; set; }
        [JsonProperty("poll")]
        public PollClass poll { get; set; }
        [JsonProperty("sticker")]
        public StickerClass sticker { get; set; }
        [JsonProperty("wall")]
        public WallClass wall { get; set; }
        [JsonProperty("wall_reply")]
        public WallReplyClass wall_reply { get; set; }
        [JsonProperty("gift")]
        public GiftClass gift { get; set; }
        [JsonProperty("note")]
        public NoteClass note { get; set; }
        //[JsonProperty("page")]
        // public GiftClass group { get; set; }
        
        public GeoClass location { get; set; }

        public AttachType attach_type
        {

            get
            {
                switch (type)
                {
                    case "album": return AttachType.Album;
                    case "app": return AttachType.App;
                    case "audio": return AttachType.Audio;
                    case "doc": return AttachType.Doc;
                    case "sticker": return AttachType.Sticker;
                    case "gift": return AttachType.Gift;
                    case "graffiti": return AttachType.Graffiti;
                    case "link": return AttachType.Link;
                    case "note": return AttachType.Note;
                    case "page": return AttachType.Page;
                    case "photo": return AttachType.Photo;
                    case "photos_list": return AttachType.PhotosList;
                    case "poll": return AttachType.Poll;
                    case "posted_photo": return AttachType.PostedPhoto;
                    case "video": return AttachType.Video;
                    case "wall": return AttachType.Wall;
                    case "wall_reply": return AttachType.WallReply;
                    default: return AttachType.Unknown;
                }

            }
        }
    }
    public static class AttachmentType
    {

        public static string GetAttachmentType(AttachType type, int count)
        {
            switch (type)
            {
                case AttachType.Audio: return (count == 1) ? "Аудиозапись" : UserDataConvert.UserDataCounter(UserDataType.Audios, count, true);
                case AttachType.Video: return (count == 1) ? "Видеозапись" : UserDataConvert.UserDataCounter(UserDataType.Audios, count, true);
                case AttachType.Doc: return (count == 1) ? "Документ" : UserDataConvert.UserDataCounter(UserDataType.Docs, count, true);
                case AttachType.Photo: return (count == 1) ? "Фотография" : UserDataConvert.UserDataCounter(UserDataType.Photos, count, true);
                case AttachType.Sticker: return "Стикер";
                case AttachType.Wall: return "Запись со стены";
                default: return "";

            }

        }

    }
    public enum AttachType
    {
        Photo,
        PostedPhoto,
        Video,
        Audio,
        Doc,
        Graffiti,
        Gift,
        Sticker,
        Link,
        Note,
        App,
        Poll,
        Page,
        Album,
        PhotosList,
        Wall,
        WallReply,
        Unknown
    }
}
