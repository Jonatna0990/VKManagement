namespace VKCore.API.VKModels.Market
{
    public class MarketClass
    {
        public int enabled { get; set; }
        public string price_min { get; set; }
        public string price_max { get; set; }
        public int? main_album_id { get; set; }
        public long contact_id { get; set; }
        public Currency currency { get; set; }
        public Wiki wiki { get; set; }
    }
    public class Wiki
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string title { get; set; }
        public int who_can_view { get; set; }
        public int who_can_edit { get; set; }
        public int edited { get; set; }
        public int created { get; set; }
        public int views { get; set; }
        public string view_url { get; set; }
    }
    public class Currency
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
