using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VKCore.Annotations;
using VKCore.API.VKModels.Geo;
using VKCore.API.VKModels.Link;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.API.VKModels.Wall;

namespace VKCore.API.VKModels.Group
{
    public class GroupWithWall
    {
        [JsonProperty("group")]
        public GroupsClass group { get; set; }
        [JsonProperty("user_contacts")]
        public ObservableCollection<UserClass> user_contacts { get; set; }
        [JsonProperty("wall")]
        public WallRoot wall { get; set; }
    }

    public class GroupMessages : GroupsClass, INotifyPropertyChanged
    {
        private VKCollection<MessageRoot> _messagesCollection;

        public VKCollection<MessageRoot> MessagesCollection
        {
            get { return _messagesCollection; }
            set { _messagesCollection = value;
                OnPropertyChanged("MessagesCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class GroupMembersRoot
    {
        [JsonProperty("members")]
        public VKCollection<UserClass> members { get; set; }
        [JsonProperty("friends")]
        public VKCollection<UserClass> friends { get; set; }
        [JsonProperty("admin")]
        public VKCollection<AdminRole> admin { get; set; }
    }
   
    public class City
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class AdminRole : UserClass
    {
        [JsonProperty("role")]
        public string role { get; set; }
    }
  
    public class Contact
    {
        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }
    }
    public class GroupsClass
    {

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("screen_name")]
        public string screen_name { get; set; }

        [JsonProperty("is_closed")]
        public int is_closed { get; set; }
        [JsonProperty("can_message")]
        public int can_message { get; set; }

        [JsonProperty("market")]
        public MarketClass market { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("is_admin")]
        public int is_admin { get; set; }

        [JsonProperty("admin_level")]
        public int admin_level { get; set; }

        [JsonProperty("is_member")]
        public int is_member { get; set; }

        [JsonProperty("photo_50")]
        public string photo_50 { get; set; }

        [JsonProperty("photo_100")]
        public string photo_100 { get; set; }

        [JsonProperty("photo_200")]
        public string photo_200 { get; set; }

        [JsonProperty("deactivated")]
        public string deactivated { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("members_count")]
        public int members_count { get; set; }

        [JsonProperty("start_date")]
        public int start_date { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("site")]
        public string site { get; set; }

        [JsonProperty("city")]
        public City city { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("place")]
        public PlaceClass place { get; set; }

        [JsonProperty("wiki_page")]
        public string wiki_page { get; set; }

        [JsonProperty("counters")]
        public Counters counters { get; set; }

        [JsonProperty("finish_date")]
        public long finish_date { get; set; }

        [JsonProperty("can_post")]
        public int can_post { get; set; }

        [JsonProperty("can_see_all_posts")]
        public int can_see_all_posts { get; set; }

        [JsonProperty("can_upload_doc")]
        public int can_upload_doc { get; set; }

        [JsonProperty("can_create_topic")]
        public int can_create_topic { get; set; }

        [JsonProperty("activity")]
        public string activity { get; set; }

        [JsonProperty("contacts")]
        public List<Contact> contacts { get; set; }

        [JsonProperty("links")]
        public List<GroupLink> links { get; set; }

        [JsonProperty("fixed_post")]
        public long fixed_post { get; set; }

        [JsonProperty("verified")]
        public int verified { get; set; }

        public string PhotoMax
        {
            get
            {

                if (!string.IsNullOrEmpty(this.photo_50)) return this.photo_50;
                else if (!string.IsNullOrEmpty(this.photo_100)) return this.photo_100;
                else return this.photo_200;
            }
        }
        public GroupType group_type
        {
            get
            {
                switch (type)
                {

                    case "group": return GroupType.group;
                    case "page": return GroupType.page;
                    case "event": return GroupType._event;
                    default: return GroupType.group;
                }
            }
        }
        public IsClosed closed
        {
            get
            {
                switch (is_closed)
                {

                    case 0: return IsClosed.open;
                    case 1: return IsClosed.close;
                    case 2: return IsClosed.privacy;
                    default: return IsClosed.close;
                }
            }
        }
        public GroupActive active
        {
            get
            {
                if (deactivated != null)
                {
                    if (deactivated == "banned") return GroupActive.banned;
                    else return GroupActive.deleted;
                }
                else return GroupActive.active;
            }
        }

    }

    public class InvitedGroups
    {
        public int member_counters { get; set; }
        public GroupsClass group { get; set; }
        public UserClass invited_by { get; set; }
    }
    public enum GroupType
    {
        group, page, _event


    }

    public enum IsClosed
    {
        open, close, privacy
    }
    public enum GroupActive
    {
        deleted, banned, active
    }
}
