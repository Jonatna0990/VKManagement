using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.MessagesControl.Converters
{
    public class AttachmentTextConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                MessageClass message = value as MessageClass;
                if (message != null)
                {
                    if (message.attachments != null) return AttachmentType.GetAttachmentType(message.attachments.FirstOrDefault().attach_type, 1);
                    else if (message.geo != null) return "Местоположение";

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
                if (message != null && message.attachments != null) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
    public class AttachmentTextVisibillityConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                MessageClass message = value as MessageClass;
                if (message != null && message.attachments != null) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                MessageClass message = value as MessageClass;
                if (message != null && message.attachments != null) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}