using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using VKCore.API.VKModels.Messages;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.Attachment
{
    public sealed partial class AttachFwdMessagesControl : UserControl
    {
        public const string MessageAttachmentPropertyText = "MessageAttachmentProperty";
        public static readonly DependencyProperty MessageAttach = DependencyProperty.RegisterAttached(
           MessageAttachmentPropertyText,
           typeof(ObservableCollection<MessageClass>),
           typeof(AttachFwdMessagesControl),
           new PropertyMetadata(
               null, OnUploadProgressPropertyChanged));

        private static void OnUploadProgressPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as AttachFwdMessagesControl;
            if (obj != null) obj.MessageAttachmentProperty = e.NewValue as ObservableCollection<MessageClass>;
        }

        public ObservableCollection<MessageClass> MessageAttachmentProperty
        {
            get { return GetValue(MessageAttach) as ObservableCollection<MessageClass>; }
            set
            {
                SetValue(MessageAttach, value);
            }
        }
        public const string DeleteCommandPropertyName = "DeleteCommand";
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.RegisterAttached(
           DeleteCommandPropertyName,
           typeof(ICommand),
           typeof(AttachFwdMessagesControl),
           new PropertyMetadata(
               null, OnDeleteCommandPropertyChanged));
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
        private static void OnDeleteCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = d as AttachFwdMessagesControl;
            if (obj != null) obj.DeleteCommand = e.NewValue as ICommand;
        }
        public AttachFwdMessagesControl()
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
