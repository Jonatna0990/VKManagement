using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;

namespace VKShop_Lite.Helpers
{
    public class DialogOpenCommand : BaseViewModel, ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            MessageClass main = parameter as MessageClass;
            return main != null;
        }

        public void Execute(object parameter)
        {
            NavigateToCurrentPage(parameter, new Scenario() { ClassType = typeof(DialogConversationPage) });
        }
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
