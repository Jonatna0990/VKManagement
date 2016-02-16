﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Photo;
using VKCore.API.VKModels.Wall;

namespace VKCore.API.VKModels.Market
{
    public class MarketItem
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Price price { get; set; }
        public Category category { get; set; }
        public int date { get; set; }
        public string thumb_photo { get; set; }
        public int availability { get; set; }
        public int can_comment { get; set; }
        public int can_repost { get; set; }
        public Likes likes { get; set; }
        public int views_count { get; set; }
        public List<PhotoClass> photos { get; set; }

    }
  
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public Section section { get; set; }
    }
    public class Section
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Price
    {
        public string amount { get; set; }
        public Currency currency { get; set; }
        public string text { get; set; }
    }
}
