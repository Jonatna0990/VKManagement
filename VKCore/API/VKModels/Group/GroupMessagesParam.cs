using VKCore.API.VKModels.Messages;

namespace VKCore.API.VKModels.Group
{
    public class GroupMessagesParam
    {
        public MessageRoot message { get; set; }
        public GroupsClass group { get; set; }
    }
}
