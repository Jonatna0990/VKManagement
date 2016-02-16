﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class MarketMainViewModel : BaseViewModel
    {
        private VKCollection<MarketItem> _marketCollection;

        public VKCollection<MarketAlbum> MarketAlbumCollection { get; set; } 
        public VKCollection<MarketItem> MarketCollection
        {
            get { return _marketCollection; }
            set { _marketCollection = value;RaisePropertyChanged("MarketCollection"); }
        }

        public MarketMainViewModel()
        {
            Messenger.Default.Register<GroupsClass>(
          this,
          message =>
          {
              if (message != null)
                  Load(message.id);
          });
        }
        void Load(int id)
        {
            VKRequest.Dispatch<VKCollection<MarketItem>>(
                       new VKRequestParameters(
                         SMarket.market_get, "owner_id", String.Format("-{0}",id)),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               MarketCollection = res.Data;
                           }
                       });
            VKRequest.Dispatch<VKCollection<MarketAlbum>>(
                     new VKRequestParameters(
                       SMarket.market_getAlbums, "owner_id", String.Format("-{0}", id)),
                     (res) =>
                     {
                         var q = res.ResultCode;
                         if (res.ResultCode == VKResultCode.Succeeded)
                         {
                             MarketAlbumCollection = res.Data;
                         }
                     });


        }

    }
}
