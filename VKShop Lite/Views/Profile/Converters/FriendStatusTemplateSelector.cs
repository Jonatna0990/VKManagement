using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.User;

namespace VKShop_Lite.Views.Profile.Converters
{
    public class FriendStatusTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IsFriendTemplate { get; set; }
        public DataTemplate SendFriendRequestTemplate { get; set; }
        public DataTemplate HasFriendRequsetTemplate { get; set; }
        public DataTemplate IsNotFriendTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                UserClass user = item as UserClass;
                if (user != null)
                {
                    switch (user.friend_status)
                    {
                        case 0:
                            return IsNotFriendTemplate;
                        case 1:
                            return SendFriendRequestTemplate;
                        case 2:
                            return HasFriendRequsetTemplate;
                        case 3:
                            return IsFriendTemplate;

                    }
                }


            }
            return IsNotFriendTemplate;
        }

    }
}
