using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKShop_Lite.ViewModels.Groups.Main;

namespace VKShop_Lite.Views.Main
{
    public class SeacrhTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }
        public DataTemplate SearchTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                PageMode t =(PageMode)Enum.Parse(typeof(PageMode), item.ToString());
              
                    if (t == PageMode.Normal) return NormalTemplate;
                    else return SearchTemplate;
                


            }
            return null;
        }

    }
}
