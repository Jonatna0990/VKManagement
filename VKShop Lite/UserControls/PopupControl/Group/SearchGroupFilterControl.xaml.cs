using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.User;
using VKCore.API.VKModels.VKList;
using VKCore.Helpers;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Group
{
    public sealed partial class SearchGroupFilterControl : ContentDialog
    {
        private Action<Dictionary<string, string>> callback = null;
        private Dictionary<string, string> paramStrings = null;
        private ObservableCollection<Country> countries = null;
        private ObservableCollection<City> cities = null;
        private Country SelectedCountry = null;
        private City SelectedCity = null;
        public SearchGroupFilterControl(Action<Dictionary<string,string>> callback)
        {
            this.InitializeComponent();
            paramStrings = new Dictionary<string, string>();
            this.callback = callback;
            LoadCountries();
        }

        private void LoadCountries()
        {
            VKRequest.Dispatch<VKCollection<Country>>(
                       new VKRequestParameters(
                         SDatabase.database_get_countries, "need_all" ,"1","count","1000"),
                       (res) =>
                       {
                           var q = res.ResultCode;
                           if (res.ResultCode == VKResultCode.Succeeded)
                           {
                               countries = res.Data.items.ToObservableCollection();
                             
                           }
                       });

        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedCountry != null)
            {
                if (!paramStrings.ContainsKey("country_id"))
                    paramStrings.Add("country_id", SelectedCountry.id.ToString());
                else paramStrings["country_id"] = SelectedCountry.id.ToString();
            }
            if (SelectedCity != null)
            {
                if (!paramStrings.ContainsKey("city_id"))
                    paramStrings.Add("city_id", SelectedCity.id.ToString());
                else paramStrings["city_id"] = SelectedCity.id.ToString();
                
            }


            if (GroupRadio.IsChecked != null && GroupRadio.IsChecked.Value)
            {
                if (!paramStrings.ContainsKey("type"))
                    paramStrings.Add("type", "group");
                else paramStrings["type"] = "group";
            }
            if (EventRadio.IsChecked != null && EventRadio.IsChecked.Value)
            {
                if (!paramStrings.ContainsKey("type"))
                    paramStrings.Add("type", "event");
                else paramStrings["type"] = "event";
                if (FutureEventSwitch.IsOn)
                {
                    if (!paramStrings.ContainsKey("future"))
                        paramStrings.Add("future", "1");
                    else paramStrings["future"] = "1";
                }
                else
                {
                    if (!paramStrings.ContainsKey("future"))
                        paramStrings.Add("future", "0");
                    else paramStrings["future"] = "0";

                }
            }
            if (PageRadio.IsChecked != null && PageRadio.IsChecked.Value)
            {
                if (!paramStrings.ContainsKey("type"))
                    paramStrings.Add("type", "page");
                else paramStrings["type"] = "page";
                
            }

          
            if (GroupsWithMarketSwitch.IsOn)
            {
                if (!paramStrings.ContainsKey("market"))
                    paramStrings.Add("market", "1");
                else paramStrings["market"] = "1";
            }
            else
            {
                if (!paramStrings.ContainsKey("market"))
                    paramStrings.Add("market", "0");
                else paramStrings["market"] = "0";
            }
            callback?.Invoke(paramStrings);
            this.Hide();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
           this.Hide();
        }


        private void CountrySuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var a = args.SelectedItem as Country;
            if (a != null)
            {
                CountrySuggestBox.Text = a.title;
                CitySuggestBox.IsEnabled = true;
                SelectedCountry = a;
            }
        }

        private void CountrySuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (!string.IsNullOrEmpty(sender.Text))
            {
                var enumerable = countries.Where(t => t.title.ToLower().StartsWith(sender.Text.ToLower()));

                this.CountrySuggestBox.ItemsSource = enumerable;
            }
            else
            {
                if (paramStrings.ContainsKey("country_id"))
                    paramStrings.Remove("country_id");
                if (paramStrings.ContainsKey("city_id"))
                    paramStrings.Remove("city_id");
                CitySuggestBox.Text = "";
                CitySuggestBox.IsEnabled = false;
            }
        }

        private void CitySuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var a = args.SelectedItem as City;
            if (a != null)
            {
                CitySuggestBox.Text = a.title;
                SelectedCity = a;
            }
        }

        private void CitySuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (SelectedCountry != null)
            {
                VKRequest.Dispatch<VKCollection<City>>(
                   new VKRequestParameters(
                     SDatabase.database_get_cities, "country_id", SelectedCountry.id.ToString(), "count", "1000", "need_all", "1", "q",sender.Text),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {
                           this.CitySuggestBox.ItemsSource = res.Data.items.ToObservableCollection();
                       }
                   });
            }
           
        

        }

       
    }
}
