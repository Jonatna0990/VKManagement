using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace VKCore.API.VKModels.User
{
    public class UserDeleteClass
    {
        public int success { get; set; }
        public int friend_deleted { get; set; }
        public int out_request_deleted { get; set; }
        public int in_request_deleted { get; set; }
        public int suggestion_deleted { get; set; }
    }
    public class UserClass : ViewModelBase
    {
        private VKAppOnline _onlineApp;
        private string _appPhotoLight;
        private string _appPhotoDark;
        private int _online;
        private int _onlineApp1;
        public void SetApplicationIcon(int app, bool is_online = false, long uid = 0)
        {
            switch (app)
            {
                case 0:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.Offline, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.Offline, false);
                    }
                    break;
                case 1:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.Mobile, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.Mobile, false);
                    }
                    break;
                case 2:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.IPhone, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.IPhone, false);
                    }
                    break;
                case 3:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.IPad, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.IPad, false);
                    }
                    break;

                case 4:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.Android, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.Android, false);
                    }
                    break;
                case 5:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.WP, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.WP, false);
                    }
                    break;
                case 6:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.Windows, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.Windows, false);
                    }
                    break;
                case 7:
                    {
                        AppPhotoLight = SetOnlineApp.GetApp(VKAppOnline.Desktop, true);
                        AppPhotoDark = SetOnlineApp.GetApp(VKAppOnline.Desktop, false);
                    }
                    break;
                default: break;
            }
            Online = is_online ? 1 : 0;
        }
       

     
        public VKAppOnline OnlineApp
        {
            get { return _onlineApp; }
            set { _onlineApp = value; AppPhotoLight = SetOnlineApp.GetApp(value, true); RaisePropertyChanged("OnlineApp"); }
        }

        public string AppPhotoLight
        {
            get { return _appPhotoLight; }
            set { _appPhotoLight = value; RaisePropertyChanged("AppPhotoLight"); }
        }

        public string AppPhotoDark
        {
            get { return _appPhotoDark; }
            set { _appPhotoDark = value; RaisePropertyChanged("AppPhotoDark"); }
        }

        public UserActiveStatus user_status
        {
            get
            {
                if (deactivated != null)
                {
                    if (deactivated == "banned") return UserActiveStatus.Banned;
                    else return UserActiveStatus.Deleted;

                }
                else return UserActiveStatus.Activated;
            }
        }

        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("domain")]
        public string domain { get; set; }

        [JsonProperty("first_name")]
        public string first_name { get; set; }

        [JsonProperty("sex")]
        public int sex { get; set; }

        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonProperty("screen_name")]
        public string screen_name { get; set; }

        [JsonProperty("maiden_name")]
        public string maiden_name { get; set; }

        [JsonProperty("deactivated")]
        public string deactivated { get; set; }

        [JsonProperty("hidden")]
        public int hidden { get; set; }

        [JsonProperty("verified")]
        public int verified { get; set; }

        [JsonProperty("blacklisted")]
        public int blacklisted { get; set; }
        [JsonProperty("blacklisted_by_me")]
        public int blacklisted_by_me { get; set; }
        [JsonProperty("is_friend")]
        public int is_friend { get; set; }
        [JsonProperty("is_favorite")]
        public int is_favorite { get; set; }

        [JsonProperty("friend_status")]
        public int friend_status { get; set; }

        [JsonProperty("bdate")]
        public string bdate { get; set; }

        [JsonProperty("city")]
        public City city { get; set; }

        [JsonProperty("country")]
        public Country country { get; set; }

        [JsonProperty("timezone")]
        public int timezone { get; set; }

        [JsonProperty("photo_50")]
        public string photo_50 { get; set; }

        [JsonProperty("photo_100")]
        public string photo_100 { get; set; }

        [JsonProperty("photo_200")]
        public string photo_200 { get; set; }

        [JsonProperty("photo_200_orig")]
        public string photo_200_orig { get; set; }

        [JsonProperty("photo_400_orig")]
        public string photo_400_orig { get; set; }

        [JsonProperty("photo_max")]
        public string photo_max { get; set; }

        [JsonProperty("photo_max_orig")]
        public string photo_max_orig { get; set; }

        [JsonProperty("online_app")]
        public int online_app
        {
            get { return _onlineApp1; }
            set { _onlineApp1 = value; RaisePropertyChanged("online_app"); }
        }

        [JsonProperty("online_mobile")]
        public int? online_mobile { get; set; }

        [JsonProperty("online")]
        public int Online
        {
            get { return _online; }
            set { _online = value; RaisePropertyChanged("Online"); }
        }

        public string OnlineText { get { return (Online == 1) ? "Online" : ""; } }

        // [JsonProperty("lists")]
        // public List<long> lists { get; set; }

        [JsonProperty("photo_id")]
        public string photo_id { get; set; }

        [JsonProperty("has_mobile")]
        public int has_mobile { get; set; }

        [JsonProperty("can_post")]
        public int can_post { get; set; }

        [JsonProperty("can_see_all_posts")]
        public int can_see_all_posts { get; set; }

        [JsonProperty("can_see_audio")]
        public int can_see_audio { get; set; }

        [JsonProperty("can_write_private_message")]
        public int can_write_private_message { get; set; }
        [JsonProperty("can_send_friend_request")]
        public int can_send_friend_request { get; set; }

        [JsonProperty("mobile_phone")]
        public string mobile_phone { get; set; }

        [JsonProperty("home_town")]
        public string home_town { get; set; }

        [JsonProperty("home_phone")]
        public string home_phone { get; set; }



        [JsonProperty("facebook")]
        public string facebook { get; set; }

        [JsonProperty("facebook_name")]
        public string facebook_name { get; set; }

        [JsonProperty("twitter")]
        public string twitter { get; set; }

        [JsonProperty("site")]
        public string site { get; set; }

        [JsonProperty("livejournal")]
        public string livejournal { get; set; }

        [JsonProperty("instagram")]
        public string instagram { get; set; }



        [JsonProperty("common_count")]
        public int common_count { get; set; }

        //   [JsonProperty("occupation")]
        //   public Occupation occupation { get; set; }



        [JsonProperty("university")]
        public int university { get; set; }

        [JsonProperty("university_name")]
        public string university_name { get; set; }

        [JsonProperty("faculty")]
        public int faculty { get; set; }

        [JsonProperty("faculty_name")]
        public string faculty_name { get; set; }

        [JsonProperty("graduation")]
        public int graduation { get; set; }


        /*  [JsonProperty("universities")]
          public List<University> universities { get; set; }

          [JsonProperty("schools")]
         public List<School> schools { get; set; }*/

        [JsonProperty("status")]
        public string status { get; set; }

        //[JsonProperty("status_audio")]
        // public StatusAudio status_audio { get; set; }

        [JsonProperty("followers_count")]
        public long followers_count { get; set; }


        [JsonProperty("relation")]
        public int relation { get; set; }

        //[JsonProperty("personal")]
        // public UserPersonal personal { get; set; }

        [JsonProperty("interests")]
        public string interests { get; set; }

        [JsonProperty("music")]
        public string music { get; set; }

        /* [JsonProperty("relation_partner")]
         public RelationPartner relation_partner { get; set; }*/

        [JsonProperty("activities")]
        public string activities { get; set; }

        [JsonProperty("movies")]
        public string movies { get; set; }

        [JsonProperty("tv")]
        public string tv { get; set; }

        [JsonProperty("books")]
        public string books { get; set; }

        [JsonProperty("games")]
        public string games { get; set; }

        [JsonProperty("about")]
        public string about { get; set; }

        [JsonProperty("quotes")]
        public string quotes { get; set; }



        public string full_name => first_name + " " + last_name;

        public string full_name_reverse => last_name + " " + first_name;



        public LastSeen last_seen { get; set; }

        [JsonProperty("counters")]
        public Counters counters { get; set; }

        [JsonProperty("nick_name")]
        public string nick_name { get; set; }

        /*   [JsonProperty("relatives")]
           public List<Relative> relatives { get; set; }*/

        [JsonProperty("exports")]
        public UserExports exports { get; set; }

        [JsonProperty("wall_comments")]
        public int wall_comments { get; set; }
    }

    public class RelationPartner : UserClass
    {
    }

    public class UserStatus
    {
        [JsonProperty("time")]
        public long time { get; set; }

        [JsonProperty("platform")]
        public int platform { get; set; }
    }
    public class StatusAudio
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("owner_id")]
        public int owner_id { get; set; }
        [JsonProperty("artist")]
        public string artist { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("duration")]
        public int duration { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("genre_id")]
        public int genre_id { get; set; }

    }
    public class LastSeen
    {
        [JsonProperty("time")]
        public long time { get; set; }

        [JsonProperty("platform")]
        public int platform { get; set; }
    }


    public class Counters 
    {
        [JsonProperty("albums")]
        public int albums { get; set; }

        [JsonProperty("videos")]
        public int videos { get; set; }

        [JsonProperty("audios")]
        public int audios { get; set; }

        [JsonProperty("notes")]
        public int notes { get; set; }

        [JsonProperty("photos")]
        public int photos { get; set; }

        [JsonProperty("groups")]
        public int groups { get; set; }

        [JsonProperty("gifts")]
        public int gifts { get; set; }

        [JsonProperty("friends")]
        public int friends { get; set; }

        [JsonProperty("online_friends")]
        public int online_friends { get; set; }

        [JsonProperty("mutual_friends")]
        public int mutual_friends { get; set; }

        [JsonProperty("user_videos")]
        public int user_videos { get; set; }

        [JsonProperty("user_photos")]
        public int user_photos { get; set; }

        [JsonProperty("followers")]
        public int followers { get; set; }

        [JsonProperty("subscriptions")]
        public int subscriptions { get; set; }

        [JsonProperty("pages")]
        public int pages { get; set; }

        [JsonProperty("topics")]
        public int topics { get; set; }

        [JsonProperty("docs")]
        public int docs { get; set; }
    }
    public class City
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("important")]
        public int important { get; set; }
    }

    public class UserExports
    {
        [JsonProperty("twitter")]
        public int twitter { get; set; }

        [JsonProperty("facebook")]
        public int facebook { get; set; }

        [JsonProperty("livejournal")]
        public int livejournal { get; set; }

        [JsonProperty("instagram")]
        public int instagram { get; set; }
    }

    public class Country
    {
        [JsonProperty("id")]
        public long id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
    }


    public class Occupation
    {

        public static readonly string OCCUPATION_TYPE_WORK = "work";
        public static readonly string OCCUPATION_TYPE_SCHOOL = "school";
        public static readonly string OCCUPATION_TYPE_UNIVERSITY = "university";

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Personal
    {
        [JsonProperty("political")]
        public int political { get; set; }
        [JsonProperty("langs")]
        public List<string> langs { get; set; }
        [JsonProperty("religion")]
        public string religion { get; set; }
        [JsonProperty("people_main")]
        public int people_main { get; set; }
        [JsonProperty("inspired_by")]
        public string inspired_by { get; set; }
        [JsonProperty("life_main")]
        public int life_main { get; set; }
        [JsonProperty("smoking")]
        public int smoking { get; set; }
        [JsonProperty("alcohol")]
        public int alcohol { get; set; }
    }

    public class University
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("country")]
        public long country { get; set; }

        [JsonProperty("city")]
        public long city { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("faculty")]
        public int faculty { get; set; }

        [JsonProperty("faculty_name")]
        public string faculty_name { get; set; }

        [JsonProperty("chair")]
        public int chair { get; set; }

        [JsonProperty("chair_name")]
        public string chair_name { get; set; }

        [JsonProperty("graduation")]
        public string graduation { get; set; }
    }

    public class UserPersonal
    {
        public int political { get; set; }

        public List<string> langs { get; set; }

        public string religion
        {
            get;
            set;
        }


        private string _inspired_by = "";
        public string inspired_by
        {
            get
            {
                return _inspired_by;
            }
            set
            {
                _inspired_by = (value ?? "");
            }
        }

        public int people_main
        {
            get;
            set;
        }

        public int life_main
        {
            get;
            set;
        }

        public int smoking
        {
            get;
            set;
        }

        public int alcohol
        {
            get;
            set;
        }
    }
    public class School
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("country")]
        public long country { get; set; }

        [JsonProperty("city")]
        public long city { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("year_from")]
        public int year_from { get; set; }

        [JsonProperty("year_to")]
        public int year_to { get; set; }

        [JsonProperty("year_graduated")]
        public int year_graduated { get; set; }

        [JsonProperty("class")]
        public string _class { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("type_str")]
        public string type_str { get; set; }

        [JsonProperty("speciality")]
        public string speciality { get; set; }
    }

    public class Relative
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }


    public static class UserData
    {
        public static string UserRelation(int relation, int sex)
        {
            switch (sex)
            {
                //женский пол
                case 1:
                    {
                        switch (relation)
                        {
                            case 1: return "не замужем";
                            case 2: return "есть друг";
                            case 3: return "помолвлена";
                            case 4: return "замужем";
                            case 5: return "всё сложно";
                            case 6: return "в активном поиске";
                            case 7: return "влюблена";
                            default: return "";
                        }
                    };
                //мужской пол
                case 2:
                    {
                        switch (relation)
                        {

                            case 1: return "не женат";
                            case 2: return "есть подруга";
                            case 3: return "помолвлен";
                            case 4: return "женат";
                            case 5: return "всё сложно";
                            case 6: return "в активном поиске";
                            case 7: return "влюблён";
                            default: return "";
                        }
                    };
                //пол не указан
                case 0:
                    {
                        switch (relation)
                        {

                            case 1: return "не женат/не замужем";
                            case 2: return "есть друг/есть подруга";
                            case 3: return "помолвлен/помолвлена";
                            case 4: return "женат/замужем";
                            case 5: return "всё сложно";
                            case 6: return "в активном поиске";
                            case 7: return "влюблён/влюблена";
                            default: return "";
                        }
                    };
                default:
                    return "";
            }


        }

        public static string GetProfilePolitical(int type)
        {
            switch (type)
            {

                case 1: { return "коммунистические"; };
                case 2: { return "социалистические"; };
                case 3: { return "умеренные"; };
                case 4: { return "либеральные"; };
                case 5: { return "консервативные"; };
                case 6: { return "монархические"; };
                case 7: { return "ультраконсервативные"; };
                case 8: { return "индифферентные"; };
                case 9: { return "либертарианские"; };
                default: return "";


            }
        }

        public static string GetProfilePeopleMain(int type)
        {

            switch (type)
            {
                case 1: { return "ум и креативность"; };
                case 2: { return "доброта и честность"; };
                case 3: { return "красота и здоровье"; };
                case 4: { return "власть и богатство"; };
                case 5: { return "смелость и упорство"; };
                case 6: { return "юмор и жизнелюбие"; };
                default: return "";




            }
        }

        public static string GetProfileLifeMain(int type)
        {

            switch (type)
            {
                case 1: { return "семья и дети"; };
                case 2: { return "карьера и деньги"; };
                case 3: { return " развлечения и отдых"; };
                case 4: { return "наука и исследования"; };
                case 5: { return "совершенствование мира"; };
                case 6: { return "саморазвитие"; };
                case 7: { return "красота и искусстсво"; };
                case 8: { return "слава и влияние"; };
                default: return "";



            }
        }

        public static string GetProfileDrinkingAndSmonking(int type)
        {

            switch (type)
            {
                case 1: { return "резко негативное"; };
                case 2: { return "негативное"; };
                case 3: { return "нейтральное"; };
                case 4: { return "компромиссное"; };
                case 5: { return "компромиссное"; };
                default: return "";



            }
        }

    }
    [Flags]
    public enum VKAppOnline
    {
        WP = 5,// 3502561
        IPhone = 2,// 3140623
        IPad = 3,//  3682744
        Android = 4,// 2274003
        Mobile = 1,
        Windows = 6,
        Desktop = 7,
        Offline = 0
    }

    public enum UserActiveStatus
    {
        Activated,
        Deleted,
        Banned
    }

    public enum FriendsList
    {
        All, Online, Mutual
    }
}
