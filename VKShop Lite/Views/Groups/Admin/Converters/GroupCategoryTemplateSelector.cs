using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Group;

namespace VKShop_Lite.Views.Groups.Admin.Converters
{
    public class GroupCategoryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EventTemplate { get; set; }
        public DataTemplate PageTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as GroupsClass;
                if (t != null)
                {
                    if (t.type == "group") return GroupTemplate;
                    else if (t.type == "event") return EventTemplate;
                    else return PageTemplate;
                }
            
            }
            return GroupTemplate;
        }
    }
}
