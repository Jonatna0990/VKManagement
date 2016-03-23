using System.Collections.Generic;
using GalaSoft.MvvmLight;
using VKCore.API.VKModels.Geo;

namespace VKCore.API.VKModels.Group
{

    public class GroupSettings : ViewModelBase
    {
        private int _messages;
        private int _market;
        private int _docs;
        private int _topics;
        private int _audio;
        private int _video;
        private int _photos;
        private int _wall;
        private int _wiki;
        public string title { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }

        public int wall
        {
            get { return _wall; }
            set { _wall = value; RaisePropertyChanged("wall"); }
        }

        public int photos
        {
            get { return _photos; }
            set { _photos = value; RaisePropertyChanged("photos"); }
        }

        public int video
        {
            get { return _video; }
            set { _video = value; RaisePropertyChanged("video"); }
        }

        public int audio
        {
            get { return _audio; }
            set { _audio = value; RaisePropertyChanged("audio"); }
        }

        public int docs
        {
            get { return _docs; }
            set { _docs = value; RaisePropertyChanged("docs"); }
        }

        public int topics
        {
            get { return _topics; }
            set { _topics = value; RaisePropertyChanged("topics"); }
        }

        public int wiki
        {
            get { return _wiki; }
            set { _wiki = value; RaisePropertyChanged("wiki"); }
        }

        public int links { get; set; }
        public int events { get; set; }
        public int places { get; set; }
        public PlaceClass place { get; set; }
        public int contacts { get; set; }

        public int messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("messages");}
        }

        public int age_limit { get; set; }

        public int market
        {
            get { return _market; }
            set { _market = value; RaisePropertyChanged("market"); }
        }

        public int market_comments { get; set; }
        public int market_country { get; set; }
        public int market_city { get; set; }
        public int market_currency { get; set; }
        public int market_contact { get; set; }
        public int market_wiki { get; set; }
        public int obscene_filter { get; set; }
        public int obscene_stopwords { get; set; }
        public int obscene_words { get; set; }
        public int access { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int start_date { get; set; }
        public int finish_date { get; set; }
        public long event_start_date { get; set; }
        public long event_finish_date { get; set; }
        public long event_group_id { get; set; }
        public int public_category { get; set; }
        public int public_subcategory { get; set; }
        public string public_date { get; set; }
        public int subject { get; set; }
        public List<SubjectList> subject_list { get; set; }
        public string website { get; set; }
        public string public_date_label { get; set; }
        public List<PublicCategoryList> public_category_list { get; set; }
    }
    public class SubtypesList
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class PublicCategoryList
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SubtypesList> subtypes_list { get; set; }
    }
    public class SubjectList
    {
        
        public int id { get; set; }
        public string name { get; set; }
    }

    public enum GroupAccessSetting
    {
        Open,
        Closed,
        Private
    }

    public enum GroupWallAndCountersAccessSetting
    {
        Off,
        Open,
        Limited,
        Closed
    }

    public enum GroupOnOffSetting
    {
        On,
        Off
    }

    public enum GroupMarketCurrencySetting
    {
        RUB = 643,
        UAH = 980,
        KZT = 398,
        EUR = 978,
        USD = 840
    }

   
}
