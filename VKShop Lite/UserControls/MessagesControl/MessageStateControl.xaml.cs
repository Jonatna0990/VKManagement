using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Messages;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKShop_Lite.UserControls.MessagesControl
{
    public sealed partial class MessageStateControl : UserControl
    {
        public static DependencyProperty ResendCommandProperty =
       DependencyProperty.Register(
           "ResendCommand",
           typeof(ICommand),
           typeof(MessageStateControl),
           new PropertyMetadata(null));
        public ICommand ResendCommand
        {
            get { return (ICommand)GetValue(ResendCommandProperty); }
            set { SetValue(ResendCommandProperty, value); }
        }


        public static DependencyProperty ResendMessageProperty =
    DependencyProperty.Register(
        "ResendMessage",
        typeof(MessageClass),
        typeof(MessageStateControl),
        new PropertyMetadata(null));
        public MessageClass ResendMessage
        {
            get { return (MessageClass)GetValue(ResendMessageProperty); }
            set { SetValue(ResendMessageProperty, value); }
        }
        public MessageStateControl()
        {
            this.InitializeComponent();
        }
    }
}
