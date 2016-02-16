using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class MarketMainViewModel : BaseViewModel
    {
        public MarketMainViewModel()
        {
            Messenger.Default.Register<GroupMessages>(
          this,
          message =>
          {
              if (message != null)
                  Load(message.id);
          });
        }
        void Load(int id)
        {
            VKRequest.Dispatch<DialogsClass>(
                       new VKRequestParameters(
                         SMessages.messages_getdialogs, "get_group_messages", id.ToString()),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                             
                           }
                       });

        }

    }
}
