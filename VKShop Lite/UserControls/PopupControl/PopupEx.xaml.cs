using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl
{
    public sealed partial class PopupEx : ContentDialog
    {
     
        private DispatcherTimer timer;
        public PopupEx(string tit, string mess)
        {
            this.InitializeComponent();
            Title = tit;
            Message.Text = mess;
            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,2);
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
           this.Hide();
        }
    }
}
