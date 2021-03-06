﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class TopConversationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ChatTemplate { get; set; }
        public DataTemplate DialogTemplate { get; set; }
        public DataTemplate GroupTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as MessageClass;
                if (t != null)
                {
                    if(t.chat_id !=null) return ChatTemplate;
                    if (t.user_id > 0 ) return DialogTemplate;
                    if (t.user_id < 0) return GroupTemplate;
                   
                }


            }
            return null;
        }
    }
}