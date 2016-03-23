using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Messages;

namespace VKCore.API.VKModels.Group
{
    public class GroupMessagesParam
    {
        public MessageRoot message { get; set; }
        public GroupsClass group { get; set; }
    }
}
