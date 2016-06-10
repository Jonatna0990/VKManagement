using VKCore.API.VKModels.Messages;

namespace VKCore.API.VKModels.Attachment
{
    public class SendAttachmentClass
    {
        public AttachmentsClass attachment { get; set; }
        public MessageRoot user { get; set; }
    }
}
