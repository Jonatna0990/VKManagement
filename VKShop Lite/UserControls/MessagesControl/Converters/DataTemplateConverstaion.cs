using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class DataTemplateConverstaion : DataTemplateSelector
    {
        public DataTemplate ChatTemplate { get; set; }
        public DataTemplate DialogTemplate { get; set; }
        public DataTemplate DialogGroupTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as MessageRoot;
                if (t != null)
                {
                    if (t.message.chat_id != null)
                        return ChatTemplate;
                    else
                    {
                        if (t.message.user_id < 0) return DialogGroupTemplate;
                        else return DialogTemplate;
                    }
                }


            }
            return null;
        }
    }
}