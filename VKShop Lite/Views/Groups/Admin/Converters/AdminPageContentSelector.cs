using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Group;

namespace VKShop_Lite.Views.Groups.Admin.Converters
{
    public class AdminPageContentSelector : DataTemplateSelector
    {
        public DataTemplate AdminTemplate { get; set; }
        public DataTemplate ModeratorAndEditorTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as GroupsClass;
                if (t != null && t.is_admin == 1)
                {
                    switch (t.admin_level)
                    {
                        case 1:
                            return ModeratorAndEditorTemplate;
                        case 2:
                            return ModeratorAndEditorTemplate;
                        case 3:
                            return AdminTemplate;
                        default: return ModeratorAndEditorTemplate;


                    }

                }

                return ModeratorAndEditorTemplate;
            }
            return ModeratorAndEditorTemplate;
        }
    }
}
