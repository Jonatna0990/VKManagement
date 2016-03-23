namespace VKCore.API.VKModels.Market
{
    public class MarketAlbumId
    {
        public int market_album_id { get; set; }
    }
    public class MarketCategories
    {
        public int id { get; set; }
        public  string name { get; set; }
        public MarketCategoriesSection section { get; set; }
    }

    public class MarketCategoriesSection
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
