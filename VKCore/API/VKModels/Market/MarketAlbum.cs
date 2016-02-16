using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Photo;

namespace VKCore.API.VKModels.Market
{
    public class MarketAlbum
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }
        public int count { get; set; }
        public int updated_time { get; set; }
        public PhotoClass photo { get; set; }
    }
}
