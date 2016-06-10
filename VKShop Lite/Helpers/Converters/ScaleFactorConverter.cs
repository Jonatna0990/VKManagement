using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Data;

namespace VKShop_Lite.Helpers.Converters
{
    public class ScaleFactorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter != null)
            {
                var h = Convert.ToInt16(parameter);
                ResolutionScale resolutionScale = DisplayInformation.GetForCurrentView().ResolutionScale;
                double factor = (double)resolutionScale / 100.0;
                double a = factor * h;
                return a;

            }
            return 0;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var h = Convert.ToInt16(value);
                ResolutionScale resolutionScale = DisplayInformation.GetForCurrentView().ResolutionScale;
                double factor = (double)resolutionScale / 100.0;
                double a = factor * h;
            }
            return 0;
        }
    }
}
