using System;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Playback;
using Windows.Networking.BackgroundTransfer;
using Newtonsoft.Json;

namespace BackgroundAudio
{
    /// <summary>
    /// Базовый класс управления аудиоплеером приложения
    /// </summary>
    public sealed class BackgroundAudioTask : IBackgroundTask
    {
        private DownloadOperation _activeDownload;
        private BackgroundTaskDeferral _deferral;
        private SystemMediaTransportControls _systemMediaTransportControl;
        private MediaPlayer _mediaPlayer;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (str == "Windows.Mobile")
            {
                _systemMediaTransportControl = SystemMediaTransportControls.GetForCurrentView();
                _systemMediaTransportControl.IsEnabled = true;
                _systemMediaTransportControl.ButtonPressed += MediaTransportControlButtonPressed;
            }
           


            BackgroundMediaPlayer.MessageReceivedFromForeground += MessageReceivedFromForeground;
            BackgroundMediaPlayer.Current.CurrentStateChanged += BackgroundMediaPlayerCurrentStateChanged;
            BackgroundMediaPlayer.Current.MediaEnded += Current_MediaEnded;
            BackgroundMediaPlayer.Current.MediaFailed += Current_MediaFailed;
            taskInstance.Canceled += OnCanceled;
            taskInstance.Task.Completed += Taskcompleted;
            _deferral = taskInstance.GetDeferral();

        }

        private void Current_MediaFailed(MediaPlayer sender, MediaPlayerFailedEventArgs args)
        {
            BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Next" } });

        }

        private void Current_MediaEnded(MediaPlayer sender, object args)
        {
            
                BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Next" } });
            

        }

        /// <summary>
        /// Play
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <param name="artist"></param>
        private void Play(VKAudio track)
        {
            _mediaPlayer = BackgroundMediaPlayer.Current;
            _mediaPlayer.AutoPlay = true;
            _mediaPlayer.SetUriSource(new Uri(track.url));
            BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Play" } });
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (str == "Windows.Mobile")
            {
                _systemMediaTransportControl.IsPauseEnabled = true;
                _systemMediaTransportControl.IsPlayEnabled = true;
                _systemMediaTransportControl.IsPreviousEnabled = true;
                _systemMediaTransportControl.IsNextEnabled = true;
                _systemMediaTransportControl.DisplayUpdater.Type = MediaPlaybackType.Music;
                _systemMediaTransportControl.DisplayUpdater.MusicProperties.Title = track.title;
                _systemMediaTransportControl.DisplayUpdater.MusicProperties.Artist = track.artist;
                _systemMediaTransportControl.DisplayUpdater.Update();
            }
           
            /* if (PlayerBase.GetPlaylists().Count > 1)
            {
                _systemMediaTransportControl.IsPreviousEnabled = true;
                _systemMediaTransportControl.IsNextEnabled = true;
            }
             else
             {
                 _systemMediaTransportControl.IsPreviousEnabled = false;
                 _systemMediaTransportControl.IsNextEnabled = false;
             }*/

        }

        /// <summary>
        /// Pause
        /// </summary>
        public void Pause()
        {
            if (_mediaPlayer == null)
                _mediaPlayer = BackgroundMediaPlayer.Current;

            _mediaPlayer.Pause();
        }

        /// <summary>
        /// Mensajes recibidos desde UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageReceivedFromForeground(object sender, MediaPlayerDataReceivedEventArgs e)
        {

            ValueSet valueSet = e.Data;
            VKAudio track = JsonConvert.DeserializeObject<VKAudio>(valueSet["Track"].ToString());
            Play(track);

        }

        /// <summary>
        ///     Cambios en el estado del MediaPlayer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackgroundMediaPlayerCurrentStateChanged(MediaPlayer sender, object args)
        {
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (str == "Windows.Mobile")
            {
                switch (sender.CurrentState)
                {
                    case MediaPlayerState.Playing:
                        {
                            _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Playing;

                        }
                        break;
                    case MediaPlayerState.Paused:
                        {
                            _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Paused;

                        }
                        break;
                    case MediaPlayerState.Stopped:
                        _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Stopped;
                        break;
                    case MediaPlayerState.Closed:
                        _systemMediaTransportControl.PlaybackStatus = MediaPlaybackStatus.Closed;
                        break;
                }
            }

           
        }

        /// <summary>
        ///     Los controles de transporte del sistema generan el evento ButtonPressed cuando se presiona 
        ///     uno de los botones habilitados. La propiedad Button de SystemMediaTransportControlsButtonPressedEventArgs 
        ///     especifica qué botón se ha presionado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MediaTransportControlButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    {
                        BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Play" } });
                    }
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    {
                        BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Pause" } });
                    }
                    break;
                case SystemMediaTransportControlsButton.Next:
                    {
                        BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State","Next"}});
                    }
                    break;
                case SystemMediaTransportControlsButton.Previous:
                    {
                        BackgroundMediaPlayer.SendMessageToForeground(new ValueSet() { { "State", "Previous" } });
                    }
                    break;
            }
        }

        private void Taskcompleted(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
            BackgroundMediaPlayer.Shutdown();
            _deferral.Complete();
        }

        private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            BackgroundMediaPlayer.Shutdown();
            _deferral.Complete();
        }
    }
}
