using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Board;

namespace VKShop_Lite.Views.Counters.Group.Selector
{
    public class GroupOrUserTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {

                BoarsClass a = item as BoarsClass;
                if (a.from_id > 0)
                {
                    return UserTemplate ;
                }
                return GroupTemplate;

            }
            return null;
        }
    }
}
