using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace VKCore.API.VKModels.Sticker
{
    public class StickerClass : ViewModelBase
    {
        private string _photo64;

        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("product_id")]
        public int product_id { get; set; }

        [JsonProperty("photo_64")]
        public string photo_64
        {
            get { return _photo64; }
            set { _photo64 = value; RaisePropertyChanged("photo_64"); }
        }

        [JsonProperty("photo_128")]
        public string photo_128 { get; set; }
        [JsonProperty("photo_256")]
        public string photo_256 { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
        public StickerClass(int _id, string img)
        {
            id = _id;
            photo_64 = img;
            photo_128 = img;
        }
    }

    public class Stickers : ViewModelBase
    {
        private ObservableCollection<int> _stickerIds;
        private ObservableCollection<StickerClass> _sticker;

        public Stickers()
        {
            Sticker = new ObservableCollection<StickerClass>();
        }

        private void SetStickers()
        {

            foreach (var t in sticker_ids)
            {
                Sticker.Add(new StickerClass(t, String.Format("{0}/{1}/128.png", base_url, t)));
            }
        }
        [JsonProperty("base_url")]
        public string base_url { get; set; }
        [JsonProperty("sticker_ids")]
        public ObservableCollection<int> sticker_ids
        {
            get { return _stickerIds; }
            set
            {
                _stickerIds = value;
                SetStickers();
            }
        }

        public ObservableCollection<StickerClass> Sticker
        {
            get { return _sticker; }
            set { _sticker = value; RaisePropertyChanged("Sticker"); }
        }
    }

    public class Product
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("purchased")]
        public int purchased { get; set; }
        [JsonProperty("active")]
        public int active { get; set; }
        [JsonProperty("purchase_date")]
        public int purchase_date { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("base_url")]
        public string base_url { get; set; }
        [JsonProperty("stickers")]
        public Stickers stickers { get; set; }
    }

    public class StickerItem
    {
        [JsonProperty("product")]
        public Product product { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("author")]
        public string author { get; set; }
        [JsonProperty("can_purchase")]
        public int can_purchase { get; set; }
        [JsonProperty("free")]
        public int free { get; set; }
        [JsonProperty("payment_type")]
        public string payment_type { get; set; }
        [JsonProperty("price")]
        public int price { get; set; }
        [JsonProperty("price_str")]
        public string price_str { get; set; }
        [JsonProperty("merchant_product_id")]
        public string merchant_product_id { get; set; }
        [JsonProperty("photo_35")]
        public string photo_35 { get; set; }
        [JsonProperty("photo_70")]
        public string photo_70 { get; set; }
        [JsonProperty("photo_140")]
        public string photo_140 { get; set; }
        [JsonProperty("photo_296")]
        public string photo_296 { get; set; }
        [JsonProperty("photo_592")]
        public string photo_592 { get; set; }
        [JsonProperty("background")]
        public string background { get; set; }
    }

    public class StickerRootObject
    {
        [JsonProperty("items")]
        public ObservableCollection<StickerItem> items { get; set; }
    }
}
