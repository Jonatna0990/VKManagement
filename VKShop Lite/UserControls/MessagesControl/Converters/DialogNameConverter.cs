using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class DialogNameConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                MessageClass message = value as MessageClass;
                if (message != null)
                {
                    if (message.chat_id != null)
                    {
                        return message.title;
                    }
                    else
                    {
                        if (message.MsgFrom.FromUser != null) return message.MsgFrom.FromUser.full_name;
                        if (message.MsgFrom.FromGroup != null) return message.MsgFrom.FromGroup.name;
                    }

                }
                else return "";
            }
            return "";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                MessageClass message = value as MessageClass;
                if (message != null)
                {
                    if (message.chat_id != null)
                    {
                        return message.title;
                    }
                    else
                    {
                        if (message.MsgFrom.FromUser != null) return message.MsgFrom.FromUser.full_name;
                        if (message.MsgFrom.FromGroup != null) return message.MsgFrom.FromGroup.name;
                    }

                }
                else return "";
            }
            return "";
        }
    }
}
