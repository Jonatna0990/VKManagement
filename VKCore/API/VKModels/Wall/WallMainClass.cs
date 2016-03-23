using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.User;
using VKCore.Converters.DateTimeConverter;

namespace VKCore.API.VKModels.Wall
{
    public class WallWithGroup
    {
        public List<GroupsClass> group { get; set; }
        public WallRoot wall { get; set; }
         public WallRoot suggests { get; set; }
        public WallRoot postponed { get; set; }
    }
    public class WallRoot
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("items")]
        public ObservableCollection<WallMainClass> items { get; set; }
        [JsonProperty("profiles")]
        public ObservableCollection<UserClass> profiles { get; set; }
        [JsonProperty("groups")]
        public ObservableCollection<GroupsClass> groups { get; set; }
        [JsonProperty("next_from")]
        public string next_from { get; set; }

        public WallRoot()
        {
            items = new ObservableCollection<WallMainClass>();
            profiles = new ObservableCollection<UserClass>();
            groups = new ObservableCollection<GroupsClass>();
        }
    }
    public class WallMainClass : ViewModelBase
    {
        private PostedBy _postedby;
        private long _date;

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("from_id")]
        public int from_id { get; set; }

        [JsonProperty("owner_id")]
        public int owner_id { get; set; }

        [JsonProperty("can_delete")]
        public int can_delete { get; set; }

        [JsonProperty("can_pin")]
        public int can_pin { get; set; }

        [JsonProperty("is_pinned")]
        public int is_pinned { get; set; }

        [JsonProperty("reply_owner_id")]
        public long reply_owner_id { get; set; }

        [JsonProperty("reply_post_id")]
        public long reply_post_id { get; set; }

        [JsonProperty("friends_only")]
        public int friends_only { get; set; }

        [JsonProperty("created_by")]
        public int created_by { get; set; }


        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("source_id")]
        public int source_id { get; set; }

        [JsonProperty("date")]
        public long date
        {
            get { return _date; }
            set
            {
                _date = value;
                NowDate = NewsDataTimeConvert.getTimeAgo(value);
            }
        }

        public string NowDate { get; set; }

        [JsonProperty("post_id")]
        public int post_id { get; set; }

        [JsonProperty("post_type")]
        public string post_type { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("geo")]
        public GeoClass geo { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentsClass> attachments { get; set; }

        [JsonProperty("post_source")]
        public PostSource post_source { get; set; }

        [JsonProperty("comments")]
        public Comments comments { get; set; }

        [JsonProperty("likes")]
        public Likes likes { get; set; }

        [JsonProperty("reposts")]
        public Reposts reposts { get; set; }

        public bool IsSigner
        {
            get
            {
                if (signer_id != null) return true;
                return false;
            }
        }
        public UserClass SignerUser { get; set; }

        public bool IsRepost
        {
            get
            {
                if (copy_history != null) return true;
                return false;
            }
        }
        [JsonProperty("copy_history")]
        public List<CopyHistory> copy_history { get; set; }


        [JsonProperty("signer_id")]
        public int? signer_id { get; set; }


        [JsonProperty("photos")]
        public Photos photos { get; set; }

        public NewsPostedBy NewsPostedBy
        {
            get
            {
                if (source_id < 0) return NewsPostedBy.Group;
                if (owner_id < 0) return NewsPostedBy.Group;
                return NewsPostedBy.User;
            }
        }

        public PostedBy Postedby
        {
            get { return _postedby; }
            set { _postedby = value; RaisePropertyChanged("Postedby"); }
        }

        public PostedBy Repostedby { get; set; }
        public NewsType news_type
        {
            get
            {
                switch (type)
                {

                    case "post": return NewsType.Post;
                    case "photo": return NewsType.Photo;
                    default: return NewsType.Post;
                }

            }
        }



    }

    public class PostedBy : ViewModelBase
    {

        private UserClass _postedByUser;
        private GroupsClass _postedByGroup;
        public UserClass PostedByUser
        {
            get { return _postedByUser; }
            set { _postedByUser = value; RaisePropertyChanged("PostedByUser"); }
        }

        public GroupsClass PostedByGroup
        {
            get { return _postedByGroup; }
            set { _postedByGroup = value; RaisePropertyChanged("PostedByGroup"); }
        }
    }
    public class PostSource
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("platform")]
        public string platform { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }
    }
    public class Comments
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("can_post")]
        public int can_post { get; set; }
    }
    public class Likes
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("user_likes")]
        public int user_likes { get; set; }

        [JsonProperty("can_like")]
        public int can_like { get; set; }

        [JsonProperty("can_publish")]
        public int can_publish { get; set; }
    }
    public class Reposts
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("user_reposted")]
        public int user_reposted { get; set; }
    }
    public class CopyHistory : WallMainClass
    {

    }
    public class Photos
    {
        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("items")]
        public List<PhotoClass> items { get; set; }
    }

    public enum NewsPostedBy { User, Group, None }
    public enum NewsType { Post, Photo }
    public enum WallType { Wall, News }
    public enum NewsSource
    {
        friends,
        groups,
        pages,
        following,
        recommended,
        all

    }
    public enum PostSourcePlatform
    {
        android,
        iphone,
        wphone
    }
    public enum WallFilter { All, Owner }

}
