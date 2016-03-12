﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class DataTemplateSelectorDialog : DataTemplateSelector
    {

        public DataTemplate OutTemplate { get; set; }
        public DataTemplate InTemplate { get; set; }
        public DataTemplate ActionTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var t = item as MessageClass;
                if (t != null)
                {
                    if (t.chat_id != null)
                    {
                        if (!string.IsNullOrEmpty(t.action)) return ActionTemplate;
                    }
                    if (t._out == 0)
                        return InTemplate;


                }

                return OutTemplate;
            }
            return null;
        }
    }
}
