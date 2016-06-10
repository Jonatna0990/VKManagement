using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LastFmLib;
using Newtonsoft.Json;
using VKCore.API.Core;
using VKCore.Converters.DurationConverter;
using VKCore.Helpers;

namespace VKCore.API.VKModels.Audio
{
    public class PlayStateChangedMessage
    {
        public MediaPlayerState NewState { get; set; }
    }
    public class PlayerPositionChangedMessage
    {
        public TimeSpan NewPosition { get; set; }
    }
    public class CurrentAudioChangedMessage
    {
        public AudioClass OldAudio { get; set; }

        public AudioClass NewAudio { get; set; }


    }
    public class PlayerBase : ViewModelBase
    {
        #region Команды
        /// <summary>
        /// Команда переключения на следующую песню
        /// </summary>
        public ICommand NextCommand { get; private set; }
        /// <summary>
        /// Команда переключения на предыдущцю песню
        /// </summary>
        public ICommand PrevCommand { get; private set; }
        /// <summary>
        /// Команда пауза/играть
        /// </summary>
        public RelayCommand PlayPauseCommand { get; private set; }

        public ICommand ShowTexCommand { get; set; }
        #endregion
        #region Приватные свойста
        private LastFm lastFm;
        private MediaPlayer _player;
        private TimeSpan _position;
        private AudioClass _currentTrack;
        private ObservableCollection<AudioClass> _playlist;
        private ObservableCollection<AudioClass> _originalPlayList;
        private long _currentTrackId;
        private int _currentTrackNumber;
        private double _bufferingProgress;
        private bool _isShuffle;
        private bool _repeat;
        private readonly DispatcherTimer playTimer;
        private TimeSpan _duration;
        private CoreDispatcher dispatcher;
        private MediaPlayerState _state;
        private double _currentPosition;
        private string _trackPosition;
        private string _trackImage;
        private string _musicText;
        private bool _isShuffleEnabled;
        private bool _isRepeatEnabled;
        private bool _isStatusAudioEnabled;
        #endregion
        #region Свойства плеера
        /// <summary>
        /// Текущее значение ползунка в double
        /// </summary>
        public double CurrentPosition
        {
            get { return _currentPosition; }
            private set { Set(ref _currentPosition, value); }
        }

        private static PlayerBase instance;
        /// <summary>
        /// Базовый плеер, имеющий одну точку входа для всего приложения
        /// </summary>
        public static PlayerBase Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerBase();
                return instance;
            }
        }
        /// <summary>
        /// Играет ли сейчас трек
        /// </summary>
        public bool IsPlaying
        {
            get { return State == MediaPlayerState.Playing; }
            set { RaisePropertyChanged("IsPlaying"); }
        }

        /// <summary>
        /// Возвращает изображение текущего трека
        /// </summary>
        public string TrackImage
        {
            get { return _trackImage; }
            private set { Set(ref _trackImage, value); }
        }
        /// <summary>
        /// Возвращает номер текущего трека в плейлисте
        /// </summary>
        public int CurrentTrackNumber
        {
            get { return _currentTrackNumber; }
            set { Set(ref _currentTrackNumber, value); }
        }

        /// <summary>
        /// Получает текущее значение ползунка в виде 00:00
        /// </summary>
        public string TrackPosition
        {
            get { return _trackPosition; }
            private set { Set(ref _trackPosition, value); }
        }
        /// <summary>
        /// Получает текущее значение текущего трека
        /// </summary>
        public AudioClass CurrentTrack
        {
            get { return _currentTrack; }
            set { Set(ref _currentTrack, value); }
        }
        /// <summary>
        /// Получает текущее значение текущего плейлиста
        /// </summary>
        public ObservableCollection<AudioClass> Playlist
        {
            get { return _playlist; }
            set
            {
                if (IsShuffleEnabled)
                {
                    _originalPlayList = value;
                    _playlist = value;
                    _playlist.Shuffle();
                }
                else
                {
                    _originalPlayList = value;
                    _playlist = value;
                }

            }
        }
        /// <summary>
        /// Возвращает текст текущей песни 
        /// </summary>
        public string MusicText
        {
            get { return _musicText; }
            set { Set(ref _musicText, value); }
        }
        /// <summary>
        /// Указывает состояние плеера
        /// </summary>
        private MediaPlayerState State
        {
            get { return _state; }
            set
            {
                if (_state == value)
                    return;

                _state = value;

                if (_state == MediaPlayerState.Playing)
                    playTimer.Start();
                else
                    playTimer.Stop();
                RaisePropertyChanged("State");
                Messenger.Default.Send(new PlayStateChangedMessage() { NewState = value });
            }
        }

        public bool IsShuffleEnabled
        {
            get { return _isShuffleEnabled; }
            set { _isShuffleEnabled = value; RaisePropertyChanged("IsShuffleEnabled"); SetSetting("IsShuffleEnabled", value.ToString()); }
        }
        public bool IsRepeatEnabled
        {
            get { return _isRepeatEnabled; }
            set { _isRepeatEnabled = value; RaisePropertyChanged("IsRepeatEnabled"); SetSetting("IsRepeatEnabled", value.ToString()); }
        }
        public bool IsStatusAudioEnabled
        {
            get { return _isStatusAudioEnabled; }
            set
            {
                _isStatusAudioEnabled = value;
                RaisePropertyChanged("IsStatusAudioEnabled");
                SetSetting("IsStatusAudioEnabled", value.ToString());
                if (value == false)
                {
                    DisableStatusAudio();
                }
                else
                {
                    if (CurrentTrack != null)
                    {
                        SendStatusAudio(CurrentTrack);
                    }
                }
            }
        }
        #endregion
        #region Конструктор
        private PlayerBase()
        {
            IsShuffleEnabled = Convert.ToBoolean(GetSetting("IsShuffleEnabled"));
            IsRepeatEnabled = Convert.ToBoolean(GetSetting("IsRepeatEnabled"));
            IsStatusAudioEnabled = Convert.ToBoolean(GetSetting("IsStatusAudioEnabled"));
            lastFm = new LastFm("cc9d5f2e9798f78d5189351242545b15", "f506943bf1331b04f32b31d546e04d78");
            dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
            _player = BackgroundMediaPlayer.Current;
            BackgroundMediaPlayer.MessageReceivedFromBackground += BackgroundMediaPlayer_MessageReceivedFromBackground;
            playTimer = new DispatcherTimer();
            playTimer.Interval = TimeSpan.FromMilliseconds(200);
            playTimer.Tick += PlayTimer_Tick;
            if (_player.CurrentState == MediaPlayerState.Playing) playTimer.Start();
            NextCommand = new PlayCommand(t => { PlayNextTrack(); });
            PrevCommand = new PlayCommand(t => { PlayPreviousTrack(); });
            PlayPauseCommand = new RelayCommand(() =>
            {
                if (IsPlaying)
                    Pause();
                else
                    PlayTrack();
            });
            ShowTexCommand = new RelayCommand(() =>
            {
                 ContentDialog p = new ContentDialog();
                if (PlayerBase.Instance.CurrentTrack != null)
                {
                    p = new ContentDialog() { Title = PlayerBase.Instance.CurrentTrack.title + " - " + PlayerBase.Instance.CurrentTrack.artist, Background = new SolidColorBrush(Colors.Gray), FullSizeDesired = true };
                }

                var s = new Grid();
                var t = new ScrollViewer() { Height = 450 };
                t.Content = new TextBlock() { Text = PlayerBase.Instance.MusicText, TextWrapping = TextWrapping.Wrap };

                s.Children.Add(t);
                p.Content = s;
                p.ShowAsync();
            });
        }
        #endregion
        #region Методы плеера
        /// <summary>
        /// Метод, выполняющий действие в текущем потоке
        /// </summary>
        /// <param name="tAction"></param>
        void ExecuteUIThread(Action tAction)
        {
            dispatcher.RunAsync(CoreDispatcherPriority.Normal,
              () =>
              {
                  tAction.Invoke();
              });

        }

        public void Pause()
        {
            BackgroundMediaPlayer.Current.Pause();
            if (CurrentTrack != null) CurrentTrack.IsPlaying = false;
            State = MediaPlayerState.Paused;
        }

        private void PlayTimer_Tick(object sender, object e)
        {
            try
            {
                CurrentPosition = _player.Position.TotalSeconds;
                TrackPosition = DurationConvert.GetDuration(_player.Position.TotalSeconds);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Воспроизводит трек
        /// </summary>
        public void PlayTrack(AudioClass track = null, ObservableCollection<AudioClass> playlist = null)
        {
            if (track != null)
            {

                if (CurrentTrack != null && track.id == CurrentTrack.id) return;
                if (playlist != null) this.Playlist = playlist;
                ExecuteUIThread(() =>
                {
                    GetTrackNumber(track);
                    CurrentTrack = track;

                    State = MediaPlayerState.Playing;
                    Messenger.Default.Send<AudioClass>(track);
                    GetTrackImage(track);
                    GetTrackText(track);
                    if (IsStatusAudioEnabled) SendStatusAudio(track);
                });
                SendMessageToPlayer(track);

            }

            BackgroundMediaPlayer.Current.Play();
            if (CurrentTrack != null) CurrentTrack.IsPlaying = true;
            State = MediaPlayerState.Playing;
        }
        /// <summary>
        /// Задаёт значение номера трека в плейлисте
        /// </summary>
        void GetTrackNumber(AudioClass track)
        {
            CurrentTrackNumber = Playlist.IndexOf(track);
        }
        /// <summary>
        /// Метод, получающий фотографию текущего трека
        /// </summary>
        private async void GetTrackImage(AudioClass track)
        {
            if (track == null) return;

            var info = await lastFm.Track.GetInfo(track.title, track.artist);

            if (!string.IsNullOrEmpty(info?.ImageExtraLarge))
            {

                TrackImage = info.ImageExtraLarge;
            }
            else
            {
                var temp = await lastFm.Artist.GetInfo(null, track.artist);
                if (temp != null)
                {

                    TrackImage = temp.ImageExtraLarge;
                }
            }

        }
        /// <summary>
        /// Метод, получающий текст текущего трека
        /// </summary>
        /// <param name="track"></param>
        private void GetTrackText(AudioClass track)
        {
            if (track == null && track.lyrics_id == 0) return;
            VKRequest.Dispatch<LyricsClass>(
                   new VKRequestParameters(
                       SAudios.audio_getLyrics, "lyrics_id", track.lyrics_id.ToString()),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {
                           MusicText = res.Data.text;
                       }
                   });
        }
        public void PlayNextTrack()
        {
            if (CurrentTrackNumber < Playlist.Count - 1)
            {
                CurrentTrackNumber++;
                PlayTrack(Playlist[CurrentTrackNumber]);
            }
            else
            {
                CurrentTrackNumber = 0;
                PlayTrack(Playlist[CurrentTrackNumber]);
            }
        }

        public void PlayPreviousTrack()
        {
            if (CurrentPosition > 3)
            {
                BackgroundMediaPlayer.Current.Position = TimeSpan.Zero;
                return;
            }

            if (CurrentTrackNumber == 0)
            {
                CurrentTrackNumber = Playlist.Count - 1; PlayTrack(Playlist[CurrentTrackNumber]);
            }
            else
            {
                CurrentTrackNumber--; PlayTrack(Playlist[CurrentTrackNumber]);
            }


        }

        private void SendMessageToPlayer(AudioClass track)
        {
            try
            {
                BackgroundMediaPlayer.SendMessageToBackground(new ValueSet { { "Track", JsonConvert.SerializeObject(track) } });
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error: " + ex.Message);
            }

        }

        private void BackgroundMediaPlayer_MessageReceivedFromBackground(object sender, MediaPlayerDataReceivedEventArgs e)
        {
            ValueSet valueSet = e.Data;
            string value = valueSet["State"].ToString();
            if (value == "Next")
            {
                ExecuteUIThread(() =>
                {
                    CurrentPosition = 0;
                    PlayNextTrack();
                });

            }
            if (value == "Previous")
            {
                ExecuteUIThread(() =>
                {
                    CurrentPosition = 0;
                    PlayPreviousTrack();
                });
            }
            if (value == "Play")
            {
                ExecuteUIThread(() =>
                {
                    playTimer.Start();
                    PlayTrack();
                });
            }
            if (value == "Pause")
            {
                ExecuteUIThread(Pause);
            }
            //throw new NotImplementedException();
        }

        private void SendStatusAudio(AudioClass track)
        {
            if (track == null) return;
            VKRequest.Dispatch<List<int>>(
                   new VKRequestParameters(
                       SAudios.audio_setBroadcast, "audio", string.Format("{0}_{1}", track.owner_id, track.id)),
                   (res) =>
                   {
                       var q = res.ResultCode;
                       if (res.ResultCode == VKResultCode.Succeeded)
                       {
                       }
                   });
        }

        private void DisableStatusAudio()
        {
            VKRequest.Dispatch<int>(
                  new VKRequestParameters(
                      SStatus.status_set, "status", ""),
                  (res) =>
                  {
                      var q = res.ResultCode;
                      if (res.ResultCode == VKResultCode.Succeeded)
                      {
                      }
                  });
        }


        public void SetSetting(string key, string value)
        {

            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(key))
            {
                localSettings.Values[key] = value;
            }
            else
            {
                localSettings.Values.Add(key, value);
            }
        }

        public string GetSetting(string key)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(key))
            {
                return localSettings.Values[key].ToString();
            }

            return "false";
        }
        #endregion
    }
}
