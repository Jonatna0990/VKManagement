using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.Messages;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;
using VKShop_Lite.Common;
using VKShop_Lite.UserControls.PopupControl.Market;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Counters.Group;
using VKShop_Lite.Views.Groups.Market;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class MarketMainViewModel : BaseViewModel
    {
        private VKCollection<MarketItem> _marketCollection;
        private GroupsClass group = null;
        private Visibility _canAddVisibility = Visibility.Collapsed;
        private int _adminLevel = 0;
        private MarketItem _selectedProduct = null;
        private MarketAlbum _selectedAlbumItem = null;

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

        public MarketAlbum SelectedAlbumItem
        {
            get { return _selectedAlbumItem; }
            set
            {
                _selectedAlbumItem = value;
                if (value != null)
                {
                    NavigateToCurrentPage(value, new Scenario() { ClassType = typeof(SelectedMarketAlbumPage) });
                }
            }
        }

        public GroupsClass Group
        {
            get { return group; }
            set { group = value; RaisePropertyChanged("Group"); }
        }

        public ICommand CreateProductCommand { get; set; }
        public ICommand CreateAlbumCommand { get; set; }

      

        public VKCollection<MarketAlbum> MarketAlbumCollection { get; set; } 
        public VKCollection<MarketItem> MarketCollection
        {
            get { return _marketCollection; }
            set { _marketCollection = value; RaisePropertyChanged("MarketCollection"); }
        }

        public MarketMainViewModel(GroupsClass group)
        {

            this.Group = group;
           
           /* CreateProductCommand = new DelegateCommand(t =>
            {
                MarketProductCreateControl market = new MarketProductCreateControl(Param, arg =>
                {
                    var d = arg;
                    
                });
                market.ShowAsync();
            });
            CreateAlbumCommand = new DelegateCommand(t =>
            {
                MarketAlbumCreateControl market = new MarketAlbumCreateControl(Param, arg =>
                {
                    var tt = arg;
                    
                    Load(Param);
                });
                market.Height = 600;
                market.ShowAsync();
            });*/

            Load();
        }

        void Load()
        {
            if(group !=null)
            {            VKRequest.Dispatch<VKCollection<MarketItem>>(
                       new VKRequestParameters(
                         SMarket.market_get, "owner_id", String.Format("-{0}", Group.id)),
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
                   SMarket.market_getAlbums, "owner_id", String.Format("-{0}", Group.id)),
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
}
