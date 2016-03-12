using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using VKShop_Lite.Helpers;
using WinRTXamlToolkit.Controls.Extensions;

namespace VKShop_Lite.UserControls.ListControl
{
    public class ScrollItemControl : ListView
    {
        private ScrollViewer _scrollViewer;
        public readonly static DependencyProperty AutoScrollProperty = DependencyProperty.Register("IsChecked", typeof(object), typeof(ScrollItemControl),
            new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var t = dependencyPropertyChangedEventArgs;
        }

        public object IsAutoScroll
        {
            get
            {
                return (object)base.GetValue(AutoScrollProperty);
            }
            set
            {
                //  if(value != null)SetScroll(value);
                base.SetValue(AutoScrollProperty, value);
            }
        }


        public const string CommandPropertyNameBottom = "LoadMoreCommandBottom";
        public static readonly DependencyProperty CommandPropertyBottom = DependencyProperty.RegisterAttached(
           CommandPropertyNameBottom,
           typeof(ICommand),
           typeof(ScrollItemControl),
           new PropertyMetadata(
               null));
        public const string CommandPropertyNameTop = "LoadMoreCommandTop";
        public static readonly DependencyProperty CommandPropertyTop = DependencyProperty.RegisterAttached(
           CommandPropertyNameTop,
           typeof(ICommand),
           typeof(ScrollItemControl),
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


        public ScrollItemControl()
        {
           this.Loaded += ScrollItemControl_Loaded;
          
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
            if (view.VerticalOffset == 0)
            {
                if (LoadMoreCommandTop != null)
                    LoadMoreCommandTop.Execute("top");

            }

            if ((view.VerticalOffset > 0.8 * view.ScrollableHeight))
            {
                if (LoadMoreCommandBottom != null)
                    LoadMoreCommandBottom.Execute("bottom");

            }




        }
        public void SetScroll(object items)
        {
            ObservableCollection<object> temp = items as ObservableCollection<object>;
            ScrollIntoView(Items.Last());
            if (temp != null) temp.CollectionChanged += Temp_CollectionChanged;
        }

        protected override void OnItemsChanged(object e)
        {
            base.OnItemsChanged(e);
            if (Items != null && Items.LastOrDefault() != null) ScrollIntoView(Items.LastOrDefault());
        }

        private void Temp_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Items != null && Items.LastOrDefault() != null) ScrollIntoView(Items.LastOrDefault());
        }
        private void ScrollItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            _scrollViewer = GetScrollViewer(this);
            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged += OnViewChanged;
            }

        }
   
    }
   
}