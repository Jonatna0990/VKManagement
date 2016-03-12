using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKCore.API.VKModels.Ban
{
    public class BanClass
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public BanInfo ban_info { get; set; }
    }

    public class BanInfo
    {
        public long admin_id { get; set; }
        public long date { get; set; }
        public int reason { get; set; }
        public string comment { get; set; }
        public int comment_visible { get; set; }
        public long end_date { get; set; }
    }
}
