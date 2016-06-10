using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using VKCore.API.VKModels.Geo;
using System.Windows.Input;
using VKCore.API.VKModels.Attachment;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Attachment
{
    public sealed partial class AttachMapLocationControl : UserControl
    {
        public const string MessageAttachmentPropertyText = "MessageAttachmentProperty";
        public static readonly DependencyProperty MessageAttach = DependencyProperty.RegisterAttached(
           MessageAttachmentPropertyText,
           typeof(GeoClass),
           typeof(AttachMapLocationControl),
           new PropertyMetadata(
               null, OnUploadProgressPropertyChanged));

        private static void OnUploadProgressPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as AttachMapLocationControl;
            if (obj != null) obj.MessageAttachmentProperty = e.NewValue as AttachmentsClass;
        }

        public AttachmentsClass MessageAttachmentProperty
        {
            get { return GetValue(MessageAttach) as AttachmentsClass; }
            set
            {
                SetValue(MessageAttach, value);
            }
        }
        public const string DeleteCommandPropertyName = "DeleteCommand";
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.RegisterAttached(
           DeleteCommandPropertyName,
           typeof(ICommand),
           typeof(AttachMapLocationControl),
           new PropertyMetadata(
               null, OnDeleteCommandPropertyChanged));
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        private static void OnDeleteCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as AttachMapLocationControl;
            if (obj != null) obj.DeleteCommand = e.NewValue as ICommand;
        }
        public AttachMapLocationControl()
        {
            this.InitializeComponent();
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (DeleteCommand != null)
                DeleteCommand.Execute(this.MessageAttachmentProperty);

        }
    }
}
