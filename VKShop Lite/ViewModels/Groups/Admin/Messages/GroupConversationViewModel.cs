using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.Messages
{
    public class GroupConversationViewModel: BaseViewModel
    {
        public GroupConversationViewModel(int group_id)
        {
            
        }

        private void Load(int group_id)
        {
           /* VKRequest.Dispatch<VKCollection<MessageRoot>>(
                       new VKRequestParameters(
                         SMessages.messages_getHistory, "get_group_messages", t.id.ToString()),
                       (resa) =>
                       {
                          
                       });*/
        }
    }
}
