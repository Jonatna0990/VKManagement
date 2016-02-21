using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.Wall;

namespace VKCore.API.VKModels.Board
{
    public class BoarsClass
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public Likes likes { get; set; }
        public int can_edit { get; set; }
        public List<AttachmentsClass> attachments { get; set; }
        public MessageFrom message_from { get; set; }
    }

    public class BoardRootClass
    {
        public int count { get; set; }
        public List<BoarsClass> items { get; set; }
        public List<UserClass> profiles { get; set; }
        public List<GroupsClass> groups { get; set; }
    }

    public class BoardParamClass
    {
        public long group_id { get; set; }
        public long topic_id { get; set; }

    }
}
