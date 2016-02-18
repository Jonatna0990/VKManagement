using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Group;

namespace VKShop_Lite.Views.Groups.Main
{
    public class AdminTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AdminTemplate { get; set; }
        public DataTemplate NotAdminemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as GroupsClass;
                if (t != null)
                {
                    if (t.is_admin == 0)
                        return NotAdminemplate;
                    else

                        return AdminTemplate;

                }


            }
            return null;
        }
    }
}
