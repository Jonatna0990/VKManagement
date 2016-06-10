using System;
using System.Collections.ObjectModel;
using VKCore.API.Core;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Market;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class SelectedMarketAlbumViewModel : BaseViewModel
    {

        private MarketAlbum album = null;
        private ObservableCollection<MarketItem> _productsCollection;
        private MarketItem _selectedProduct = null;
        public MarketItem SelectedProductItem
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (value != null)
                {
                    NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(SelectedProductPage) });
                }
            }
        }
        public ObservableCollection<MarketItem> ProductsCollection
        {
            get { return _productsCollection; }
            set { _productsCollection = value;
                if (value!=null) RaisePropertyChanged("ProductsCollection"); }
        }

        public SelectedMarketAlbumViewModel(MarketAlbum album)
        {
            this.album = album;
            Load();

        }

        private void Load()
        {
            if (album != null)
            {
                VKRequest.Dispatch<VKCollection<MarketItem>>(
                      new VKRequestParameters(
                        SMarket.market_get, "owner_id", String.Format("{0}", album.owner_id), "album_id", String.Format("{0}", album.id),"extended","1"),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              ProductsCollection = res.Data.items.ToObservableCollection();
                          }
                      });

            }
        }
    }
}
