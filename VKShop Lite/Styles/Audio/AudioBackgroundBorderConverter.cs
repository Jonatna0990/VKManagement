using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using VKCore.API.VKModels.Audio;
using VKShop_Lite.Helpers;

namespace VKShop_Lite.Styles.Audio
{
    public class AudioBackgroundBorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {

            if (value != null)
            {
                var a = (MediaPlayerState)value;
                if (a == MediaPlayerState.Paused || a== MediaPlayerState.Playing) return new SolidColorBrush(Colors.LightGray);
                else return new SolidColorBrush(Colors.Transparent);
            }
             return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if (value != null)
            {
                int a = (int)value;
                if (a > 0) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }
    }
}