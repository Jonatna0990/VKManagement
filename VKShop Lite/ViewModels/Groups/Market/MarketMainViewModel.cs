using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Market;
using VKCore.API.VKModels.VKList;
using VKShop_Lite.Common;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl.Market;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Groups.Market;
using ВКонтакте.Models.List;

namespace VKShop_Lite.ViewModels.Groups.Market
{
    public class MarketMainViewModel : BaseViewModel
    {
        private ObservableCollection<MarketItem> _marketCollection;
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

      
        public ICommand DeleteProductCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand EditAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ObservableCollection<MarketAlbum> MarketAlbumCollection { get; set; } 
        public ObservableCollection<MarketItem> MarketCollection
        {
            get { return _marketCollection; }
            set { _marketCollection = value; RaisePropertyChanged("MarketCollection"); }
        }

      
        public MarketMainViewModel(GroupsClass group)
        {
            EditProductCommand = new DelegateCommand(t =>
            {
                
            });
            DeleteProductCommand=new DelegateCommand(t =>
            {
                DeleteProduct(t as MarketItem);
            });

            EditAlbumCommand = new DelegateCommand(t =>
            {
                MarketAlbumEditControl control = new MarketAlbumEditControl(t as MarketAlbum, id =>
                {
                    LoadAlbumByid(id, true);
                });
                control.ShowAsync();
            });
            DeleteAlbumCommand =new DelegateCommand(t =>
            {
                DeleteAlbum(t as MarketAlbum);
            });
           

            this.Group = group;
           
            CreateProductCommand = new DelegateCommand(t =>
            {
                IsOpenAppBar = false;
                try
                {
                    MarketProductCreateControl market = new MarketProductCreateControl(Group.id.ToString(), arg =>
                    {
                        LoadProductById(arg.market_item_id);
                    });
                    market.ShowAsync();
                }
                catch (Exception)
                {
                }
               
              
               
            });
            CreateAlbumCommand = new DelegateCommand(t =>
            {
                IsOpenAppBar = false;
                try
                {
                    MarketAlbumCreateControl market = new MarketAlbumCreateControl(Group.id.ToString(), arg =>
                    {
                        var tt = arg;
                        LoadAlbumByid(arg.market_album_id);
                    });
                    market.ShowAsync();
                }
                catch (Exception)
                {
                    
                }
             
            });

            Load();
        }
        private  void DeleteProduct(MarketItem product)
        {
            if (product != null)
            {

                var commands = new Dictionary<string, Action>();
                commands.Add("Удалить", () =>
                {

                    Dictionary<string, string> param = new Dictionary<string, string>();

                    if (group != null) param.Add("owner_id", String.Format("{0}", product.owner_id));
                    param.Add("item_id", String.Format("{0}", product.id));

                    VKRequest.Dispatch<int>(
                      new VKRequestParameters(
                        SMarket.market_delete, param),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              MarketCollection.Remove(product);
                          }
                      });
                });
                commands.Add("Отмена", null);
                MessagesHelper.ShowDialogMessage("Удаление товара", "Вы действительно хотите удалить этот товар?", commands);
                

            }


        }
        private  void DeleteAlbum(MarketAlbum album)
        {
            if (album != null)
            {
                var commands = new Dictionary<string, Action>();
                commands.Add("Удалить", () =>
                {

                    Dictionary<string, string> param = new Dictionary<string, string>();

                    if (group != null) param.Add("owner_id", String.Format("{0}", album.owner_id));
                    param.Add("album_id", String.Format("{0}", album.id));

                    VKRequest.Dispatch<int>(
                      new VKRequestParameters(
                        SMarket.market_deleteAlbum, param),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              MarketAlbumCollection.Remove(album);
                          }
                      });
                });
                commands.Add("Отмена", null);
                MessagesHelper.ShowDialogMessage("Удаление подборки", "Вы действительно хотите удалить эту подборку?", commands);
             

            }


        }


        private void LoadProductById(long id, bool refresh=false)
        {
            VKRequest.Dispatch<VKList<MarketItem>>(
                  new VKRequestParameters(
                    SMarket.market_getById, "item_ids", String.Format("-{0}_{1}", Group.id, id), "extended", "1"),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {

                        MarketCollection.Insert(0,res.Data.items.FirstOrDefault());
                      }
                  });

        }
        private void LoadAlbumByid(long id, bool refresh = false)
        {
            if (MarketAlbumCollection != null && group !=null)
            {
                VKRequest.Dispatch<VKCollection<MarketAlbum>>(
                   new VKRequestParameters(
                     SMarket.market_getAlbumById, "owner_id", String.Format("-{0}", Group.id), "album_ids",id.ToString()),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {
                           var item = res.Data.items.FirstOrDefault();
                           if (refresh)
                           {
                             
                               var enumerable = MarketAlbumCollection.FirstOrDefault(t => t.id == item.id);
                               if (enumerable != null)
                               {
                                   enumerable.title = item.title;
                                   enumerable.photo = item.photo;
                               }
                           }
                           else MarketAlbumCollection.Insert(0, res.Data.items.FirstOrDefault());

                         
                       }
                   });
            }
        }
        private void Load()
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
                               MarketCollection = res.Data.items;
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
                         MarketAlbumCollection = res.Data.items;
                     }
                 });
            }
        


        }

    }
}
