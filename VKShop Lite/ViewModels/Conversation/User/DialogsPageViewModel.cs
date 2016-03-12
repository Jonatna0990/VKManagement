using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;
using VKShop_Lite.Views.Counters.User;

namespace VKShop_Lite.ViewModels.Conversation.User
{
    public class DialogsPageViewModel : BaseViewModel
    {
        public MessageRoot SelectedDialog
        {
            get { return _selectedDialog; }
            set
            {
                _selectedDialog = value;
                RaisePropertyChanged("SelectedDialog");
                if (value != null)
                {
                    if(value.message.chat_id ==null)
                    NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(DialogConversationPage) } );
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


        public DialogsPageViewModel()
        {
            is_enabled = false;
            Dialogs = new DialogsCollection();
        }


    }
}
