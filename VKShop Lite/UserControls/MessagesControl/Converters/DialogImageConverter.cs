using System;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class DialogImageConverter : IValueConverter
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
                        if (!string.IsNullOrEmpty(message.photo_100) || !string.IsNullOrEmpty(message.photo_50) ||
                            !string.IsNullOrEmpty(message.photo_200)) return message.photo_100;
                        if (message.MsgFrom.ChatUsersList != null) return @"ms-appx:///Icons/Dark/Menu/appbar.group.png";
                    }
                    else
                    {
                        if (message.MsgFrom.FromUser != null) return message.MsgFrom.FromUser.photo_100;
                        if (message.MsgFrom.FromGroup != null) return message.MsgFrom.FromGroup.photo_100;
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
                        if (!string.IsNullOrEmpty(message.photo_100) || !string.IsNullOrEmpty(message.photo_50) ||
                            !string.IsNullOrEmpty(message.photo_200)) return message.photo_100;
                        if (message.MsgFrom.ChatUsersList != null) return @"ms-appx:///Icons/Dark/Menu/appbar.group.png";
                    }
                    else
                    {
                        if (message.MsgFrom.FromUser != null) return message.MsgFrom.FromUser.photo_100;
                        if (message.MsgFrom.FromGroup != null) return message.MsgFrom.FromGroup.photo_100;
                    }

                }
                else return "";
            }
            return "";
        }
    }
}
