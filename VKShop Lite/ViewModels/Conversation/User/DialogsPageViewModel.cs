using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class DialogsPageViewModel : BaseViewModel
    {
        private object param = null;
        public MessageRoot SelectedDialog
        {
            get { return _selectedDialog; }
            set
            {
                _selectedDialog = value;
                RaisePropertyChanged("SelectedDialog");
                if (value != null)
                {
                    if (value.message.chat_id == null)
                    {
                        if (param is AttachmentsClass)
                            NavigateToCurrentPage(new SendAttachmentClass()
                            { attachment = param as AttachmentsClass, user = value}, new Scenario() { ClassType = typeof(DialogConversationPage) });
                        else NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(DialogConversationPage) } );
                    }
                    else NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(ChatConversationPage) });

                }
            }
        }

        public DialogsCollection Dialogs
        {
            get { return _dialogs; }
            set { _dialogs = value; RaisePropertyChanged("Dialogs"); }
        }


        private DialogsCollection _dialogs;
        private MessageRoot _selectedDialog;


        public DialogsPageViewModel(object attachment)
        {
           
           
            is_enabled = false;
            param = attachment;
            Dialogs = attachment != null ? new DialogsCollection(attachment as AttachmentsClass) : new DialogsCollection();
        }
    }
}
