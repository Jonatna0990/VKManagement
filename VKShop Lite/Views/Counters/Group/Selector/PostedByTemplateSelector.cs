using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Topics;

namespace VKShop_Lite.Views.Counters.Group.Selector
{
    public class PostedByTemplateSelector : DataTemplateSelector
    {
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {

                TopicComment a = item as TopicComment;
                if (a.updated_by > 0)
                {
                    return UserTemplate;
                }
                return GroupTemplate;

            }
            return null;
        }
    }
}
