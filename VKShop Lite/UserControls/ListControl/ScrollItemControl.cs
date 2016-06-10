using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight.Messaging;
using VKCore.API.VKModels.Board;
using VKCore.API.VKModels.Messages;

namespace VKShop_Lite.UserControls.ListControl
{
    public enum ScrollControlType
    {
        News,
        Dialogs,
        Messages,
        Comments,
        None

    }
    public class ExtendedListView : ListView
    {
       
        private ScrollViewer _scrollViewer;
        public static readonly DependencyProperty ScrollControlTypeProperty = DependencyProperty.Register("ScrollControlType", typeof(ScrollControlType), typeof(ExtendedListView),
            new PropertyMetadata(ScrollControlType.None, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var t = dependencyPropertyChangedEventArgs;
        }




        public ScrollControlType ScrollControlType
        {
            get
            {
                return (ScrollControlType)base.GetValue(ScrollControlTypeProperty);
            }
            set
            {
                base.SetValue(ScrollControlTypeProperty, value);
            }
        }


        public const string CommandPropertyNameBottom = "LoadMoreCommandBottom";
        public static readonly DependencyProperty CommandPropertyBottom = DependencyProperty.RegisterAttached(
           CommandPropertyNameBottom,
           typeof(ICommand),
           typeof(ExtendedListView),
           new PropertyMetadata(
               null));
        public const string CommandPropertyNameTop = "LoadMoreCommandTop";
        public static readonly DependencyProperty CommandPropertyTop = DependencyProperty.RegisterAttached(
           CommandPropertyNameTop,
           typeof(ICommand),
           typeof(ExtendedListView),
           new PropertyMetadata(
               null));
        public ICommand LoadMoreCommandTop
        {
            get { return (ICommand)GetValue(CommandPropertyTop); }
            set { SetValue(CommandPropertyTop, value); }
        }
        public ICommand LoadMoreCommandBottom
        {
            get { return (ICommand)GetValue(CommandPropertyBottom); }
            set { SetValue(CommandPropertyBottom, value); }
        }


        public ExtendedListView()
        {
           
           this.Loaded += ScrollItemControl_Loaded;
            Messenger.Default.Register<MessageClass>(this, (person) =>
            {
                ScrollToBottom();
            });
            Messenger.Default.Register<BoarsClass>(this,  (person) =>
            {
               
                ScrollToBottom();
            });

        }

        

        private static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }
        private void OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

            ScrollViewer view = (ScrollViewer)sender;
            double progress = view.VerticalOffset / view.ScrollableHeight;
            if (progress <= 0.3 )
            {
                LoadMoreCommandTop?.Execute(sender);
            }

            if (progress > 0.93)
            {
                LoadMoreCommandBottom?.Execute(sender);
            }
        }

       

        private async void ScrollToBottom()
        {
            await Task.Delay(500);
            if (_scrollViewer != null) _scrollViewer.ChangeView(null, _scrollViewer.ScrollableHeight + 5000, null);
        }

        private void ScrollItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ScrollControlType != ScrollControlType.None)
            {
                switch (ScrollControlType)
                {
                    case ScrollControlType.Messages:
                        {
                            ScrollToBottom();
                            _scrollViewer = GetScrollViewer(this);
                            if (_scrollViewer != null)
                            {
                                _scrollViewer.ViewChanged += OnViewChanged;
                                _scrollViewer.SizeChanged += _scrollViewer_SizeChanged;
                                
                            }
                          
                        }; break;
                    case ScrollControlType.Dialogs:
                    case ScrollControlType.News:
                    case ScrollControlType.None:
                        {
                            _scrollViewer = GetScrollViewer(this);
                            if (_scrollViewer != null)
                            {
                                _scrollViewer.ViewChanged += OnViewChanged;
                            }
                        }
                        ; break;
                    case ScrollControlType.Comments:
                    {
                            ScrollToBottom();
                            _scrollViewer = GetScrollViewer(this);
                            if (_scrollViewer != null)
                            {
                                _scrollViewer.ViewChanged += OnViewChanged;
                            }
                            
                        
                    };break;
                 
                     
                }
            }
         

        }

        private void _scrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var obj = sender as ScrollViewer;
            obj.ChangeView(0.0f, double.MaxValue, 1.0f);
            UpdateLayout();
        }
    }
   
}