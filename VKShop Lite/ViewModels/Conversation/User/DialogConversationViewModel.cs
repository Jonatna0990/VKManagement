using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VKCore.API.Core;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.User;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class DialogConversationViewModel : BaseViewModel
    {
        
        private MessagesCollection _messages;
        public MessagesCollection Messages
        {
            get { return _messages; }
            set { _messages = value; RaisePropertyChanged("Messages"); }
        }
        private MessageRoot message = null;
        public DialogConversationViewModel(object param)
        {
            is_enabled = true;
            if (param != null)
            {
                if (param is MessageRoot)
                {
                    MessageRoot message = (MessageRoot)param;
                    Messages = new MessagesCollection(message.message);
                }
                else if (param is UserClass)
                {
                    UserClass user = (UserClass) param;
                    Messages = new MessagesCollection(new MessageClass() { user_id = user.id });
                }
                else if (param is GroupsClass)
                {
                    GroupsClass group = (GroupsClass)param;
                    Messages = new MessagesCollection(new MessageClass() { user_id = -group.id });
                }
                else if(param is MarketItem)
                {
                    MarketItem product = (MarketItem)param;
                    VKRequest.Dispatch<List<GroupsClass>>(
                       new VKRequestParameters(
                                   SGroups.groups_getById, "group_id", Math.Abs(product.owner_id).ToString(), "fields", "market"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               var a = res.Data.FirstOrDefault();
                               if(a.market.contact_id != 0)
                               Messages = new MessagesCollection(new MessageClass() { user_id = a.market.contact_id }, product);
                           }
                       });
                 
                   
                }
                else if (param is SendAttachmentClass)
                {
                    SendAttachmentClass message = (SendAttachmentClass)param;
                    Messages = new MessagesCollection(message.user.message);
                    Messages.AttachCollection = new ObservableCollection<AttachmentsClass>();
                    Messages.AttachCollection.Add(message.attachment);
                }
            }
        }
    }
}
