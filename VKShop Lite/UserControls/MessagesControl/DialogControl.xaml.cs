using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.MessagesControl
{
    public sealed partial class DialogControl : UserControl
    {
        public DialogControl()
        {
            this.InitializeComponent();
        }
        public static DependencyProperty SelectDialogProperty =
        DependencyProperty.Register(
          "SelectDialogCommand",
          typeof(ICommand),
          typeof(DialogControl),
          new PropertyMetadata(null));
        public ICommand SelectDialogCommand
        {
            get { return (ICommand)GetValue(SelectDialogProperty); }
            set { SetValue(SelectDialogProperty, value); }
        }

    }
}
