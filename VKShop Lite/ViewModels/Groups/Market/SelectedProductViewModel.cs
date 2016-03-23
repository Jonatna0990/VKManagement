using System;
using System.Linq;
using VKCore.API.Core;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Wall;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class SelectedProductViewModel : BaseViewModel
    {
        private MarketItem product = null;
        private MarketItem _product;
        private int _commentsCount;

        public int CommentsCount
        {
            get { return _commentsCount; }
            set { _commentsCount = value; RaisePropertyChanged("CommentsCount"); }
        }

        public MarketItem Product
        {
            get { return _product; }
            set { _product = value; RaisePropertyChanged("Product");}
        }

        public SelectedProductViewModel(MarketItem item)
        {
            product = item;
            Load();
        }

        private void Load()
        {
            if (product != null)
            {
                VKRequest.Dispatch<VKList<MarketItem>>(
                 new VKRequestParameters(
                   SMarket.market_getById, "item_ids", String.Format("{0}_{1}", product.owner_id,product.id),"extended","1"),
                 (res) =>
                 {
                     var q = res.ResultCode;
                     if (res.ResultCode == VKResultCode.Succeeded)
                     {
                         Product = res.Data.items.FirstOrDefault();
                     }
                 });
                VKRequest.Dispatch<VKList<Comments>>(
                new VKRequestParameters(
                  SMarket.market_getComments, "owner_id", String.Format("{0}", product.owner_id), "item_id", String.Format("{0}", product.id)),
                (res) =>
                {
                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {
                        CommentsCount = res.Data.count;
                    }
                });


            }
           
        }
    }
    
}
