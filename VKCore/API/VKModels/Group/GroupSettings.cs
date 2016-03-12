using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Geo;

namespace VKCore.API.VKModels.Group
{
  
    public class GroupSettings
    {
        public string title { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }
        public int wall { get; set; }
        public int photos { get; set; }
        public int video { get; set; }
        public int audio { get; set; }
        public int docs { get; set; }
        public int topics { get; set; }
        public int wiki { get; set; }
        public int links { get; set; }
        public int events { get; set; }
        public int places { get; set; }
        public PlaceClass place { get; set; }
        public int contacts { get; set; }
        public int messages { get; set; }
        public int age_limit { get; set; }
        public int market { get; set; }
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
        public long event_start_date { get; set; }
        public long event_finish_date { get; set; }
        public long event_group_id { get; set; }
        public int public_category { get; set; }
        public int public_subcategory { get; set; }
        public string public_date { get; set; }
        public int subject { get; set; }
        public List<SubjectList> subject_list { get; set; }
        public string website { get; set; }
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
