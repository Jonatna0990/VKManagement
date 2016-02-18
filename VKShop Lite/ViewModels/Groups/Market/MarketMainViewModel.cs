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
using VKShop_Lite.UserControls.PopupControl.Market;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class MarketMainViewModel : BaseViewModel
    {
        private VKCollection<MarketItem> _marketCollection;
        private GroupsClass _group;

        public ICommand CreateProductCommand { get; set; }
        public ICommand CreateAlbumCommand { get; set; }
        public VKCollection<MarketAlbum> MarketAlbumCollection { get; set; } 
        public VKCollection<MarketItem> MarketCollection
        {
            get { return _marketCollection; }
            set { _marketCollection = value; RaisePropertyChanged("MarketCollection"); }
        }

        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value; RaisePropertyChanged("Group"); }
        }

        public MarketMainViewModel()
        {
            CreateProductCommand = new DelegateCommand(t =>
            {
                MarketProductCreateControl market = new MarketProductCreateControl(Group, arg =>
                {
                    var d = arg;
                });
                market.ShowAsync();
            });
            CreateAlbumCommand = new DelegateCommand(t =>
            {
                MarketAlbumCreateControl market = new MarketAlbumCreateControl(Group, arg =>
                {
                    var tt = arg;
                    Load(Group.id);
                });
                market.ShowAsync();
            });
           
            Messenger.Default.Register<GroupsClass>(
          this,
          message =>
          {
              if (message != null)
              {
                  Load(message.id);
                  Group = message;
              }
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
