using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.SDK;
using VKCore.API.VKModels.User;

namespace VKShop_Lite.Views.Profile.Converters
{
    public class ProfileContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProfileTemplate { get; set; }
        public DataTemplate UserTemplate { get; set; }
        public DataTemplate DeactivatedOrDeletedTemplate { get; set; }
        public DataTemplate BlacklistTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                UserClass user = item as UserClass;
                if (user != null)
                {
                    if (user.id.ToString() == VKSDK.GetAccessToken().UserId) return UserTemplate;
                    else if (!string.IsNullOrEmpty(user.deactivated)) return DeactivatedOrDeletedTemplate;
                    else if (user.blacklisted == 1) return BlacklistTemplate;
                    else return ProfileTemplate;
                }
            }
            return null;
        }

    }
}
