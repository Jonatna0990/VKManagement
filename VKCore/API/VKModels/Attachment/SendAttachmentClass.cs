using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;

namespace VKCore.API.VKModels.Attachment
{
    public class SendAttachmentClass
    {
        public AttachmentsClass attachment { get; set; }
        public MessageRoot user { get; set; }
    }
}
