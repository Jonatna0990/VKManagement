using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Messages;
using VKShop_Lite.Helpers;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class MessageSendStateSelector : DataTemplateSelector
    {
        public DataTemplate SendingTemplate { get; set; }
        public DataTemplate SentTemplate { get; set; }
        public DataTemplate ErrorTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var a = EnumParser.ParseEnum<MessageSendState>(item.ToString());
                if (a == MessageSendState.Sent) return SentTemplate;
                else if (a == MessageSendState.Sending) return SendingTemplate;
                else return ErrorTemplate;
            }
            return SentTemplate;
        }
    }
}