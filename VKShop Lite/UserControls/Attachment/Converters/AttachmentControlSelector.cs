using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.VKModels.Attachment;

namespace VKShop_Lite.UserControls.Attachment.Converters
{
    public class AttachmentControlSelector : DataTemplateSelector
    {
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate AudioTemplate { get; set; }
        public DataTemplate VideoTemplate { get; set; }
        public DataTemplate DocTemplate { get; set; }
        public DataTemplate FwdMessagesTemplate { get; set; }
        public DataTemplate WallTemplate { get; set; }
        public DataTemplate MapLocationTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var a = item as AttachmentsClass;
               
                if (a.photo != null) return PhotoTemplate;
                if (a.audio != null) return AudioTemplate;
                if (a.doc != null) return DocTemplate;
                if (a.video != null) return VideoTemplate;
                if (a.wall != null) return WallTemplate;
                if (a.location != null) return MapLocationTemplate;
            }
            return null;
        }
    }
}