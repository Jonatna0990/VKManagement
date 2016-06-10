using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;

namespace VKShop_Lite.Helpers
{
    public class ResolutionScaleHelper : ViewModelBase
    {
        private double _height;
        private double _width;

        public double Height
        {
            get { return _height; }
            set { _height = value; RaisePropertyChanged("Height"); }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; RaisePropertyChanged("Width"); }
        }
        private double abs_height;
        private double abs_width;

        public double AbsHeight
        {
            get { return abs_height; }
            set { abs_height = value; RaisePropertyChanged("Height"); }
        }

        public double AbsWidth
        {
            get { return abs_width; }
            set { abs_width = value; RaisePropertyChanged("Width"); }
        }

        public ResolutionScaleHelper()
        {
            if (Window.Current != null)
            {
                AbsHeight = Window.Current.Bounds.Height;
                AbsWidth = Window.Current.Bounds.Width;
                Height = Window.Current.Bounds.Height-25;
                Width = Window.Current.Bounds.Width-25;

                Frame scenarioFrame = Window.Current.Content as Frame;
                if (scenarioFrame != null) scenarioFrame.SizeChanged += ScenarioFrame_SizeChanged;
            }
        }

        private void ScenarioFrame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Height = e.NewSize.Height-25;
            Width = e.NewSize.Width-25;
            AbsHeight = e.NewSize.Height;
            AbsWidth = e.NewSize.Width;
        }
    }
}
