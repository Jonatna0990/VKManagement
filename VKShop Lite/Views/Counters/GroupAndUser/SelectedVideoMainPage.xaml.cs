using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.API.VKModels.Video;
using VKShop_Lite.ViewModels.Counters.GroupAndUser;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Counters.GroupAndUser
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SelectedVideoMainPage : Page
    {
        public SelectedVideoMainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new SelectedVideoViewModel(e.Parameter as VideoParamClass);
            if (BackgroundMediaPlayer.Current.CurrentState == MediaPlayerState.Playing) BackgroundMediaPlayer.Current.Pause();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            WebPlayer.Refresh();
            WebPlayer.Stop();
            if (BackgroundMediaPlayer.Current.CurrentState == MediaPlayerState.Paused) BackgroundMediaPlayer.Current.Play();
        }
    }
}
