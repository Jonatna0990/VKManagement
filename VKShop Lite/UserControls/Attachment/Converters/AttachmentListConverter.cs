using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.Attachment.Converters
{
    public class AttachmentListConverter : IValueConverter
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
                ObservableCollection<AttachmentsClass> message = value as ObservableCollection<AttachmentsClass>;
                ObservableCollection<AttachmentsClass> temp = new ObservableCollection<AttachmentsClass>();
                if (message != null)
                {
                    int type = Convert.ToInt16(parameter);
                    switch (type)
                    {
                        case 1:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Photo)
                                    temp.Add(t);
                            }
                            break;
                        case 2:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Video)
                                    temp.Add(t);
                            }
                            break;
                        case 3:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Audio)
                                    temp.Add(t);
                            }
                            break;
                        case 4:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Doc)
                                    temp.Add(t);
                            }
                            break;
                        case 5:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Sticker)
                                    temp.Add(t);
                            }
                            ;
                            break;
                        case 6:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Wall)
                                    temp.Add(t);
                            }
                            break;
                        case 7:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Link)
                                    temp.Add(t);
                            }
                            break;
                        case 8:
                            foreach (var t in message)
                            {

                                if (t.attach_type == AttachType.Gift)
                                    temp.Add(t);
                            }
                            break;
                        default:
                            break;
                    }

                    return temp;
                }

                else return temp;
            }
            return null;
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