using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Group;

namespace VKCore.API.VKModels.Ban
{
    public class BanParamClass
    {
        public GroupsClass group { get; set; }
        public BanUserClass ban { get; set; }
    }
}
