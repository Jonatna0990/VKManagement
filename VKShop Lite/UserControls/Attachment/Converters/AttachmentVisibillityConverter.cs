using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.Attachment.Converters
{
    public class AttachmentVisibillityConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует входной список в тип, определенный параметром paramrter
        /// </summary>
        /// <param name="value">список вложений</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">тип вложения</param>
        /// <param name="language"></param>
        /// <returns></returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                ObservableCollection<MessageClass> a = value as ObservableCollection<MessageClass>;

                if (a != null && a.Count > 0) return Visibility.Visible;

                ObservableCollection<AttachmentsClass> b = value as ObservableCollection<AttachmentsClass>;
                if (b != null && b.Count > 0) return Visibility.Visible;
                

                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                int a = (int) value;
                if (a > 0) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}