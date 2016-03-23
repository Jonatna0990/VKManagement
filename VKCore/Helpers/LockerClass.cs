using System;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;

namespace VKCore.Helpers
{
    public class LockerClass : ViewModelBase
    {
        private bool _isLocked;
        private int _timer;
        public event EventHandler Locked;
        public event EventHandler OnTicked;


        private int Timer
        {
            get { return _timer; }
            set { _timer = value; }
        }

        public long LockerId
        {
            get; set;
        }
        /// <summary>
        /// Указывает, заблокирован ли текущий блокиратор
        /// </summary>
        public bool IsLocked
        {
            get { return _isLocked; }
            set
            {
                _isLocked = value;
                RaisePropertyChanged("IsLocked");
            }
        }

        public void Start()
        {
            if (!IsLocked)
            {
                dispatcherTimer.Start();
                IsLocked = true;
            }
        }

        public void AddSeconds(int seconds)
        {
            Timer = Timer + seconds;
        }


        public void Stop()
        {
            if (IsLocked)
            {
                dispatcherTimer.Stop();
                IsLocked = false;
                temp = 0;
                Timer = 5;
                Locked?.Invoke(this, null);
            }

        }

        private DispatcherTimer dispatcherTimer { get; set; }
        /// <summary>
        /// Создаёт объект-блокиратор, позволяющий блокировать на указанное время выполнение действий
        /// </summary>
        /// <param name="time">Указанное в секцндах значение, на которое создаётся блокиратор</param>
        /// <param name="id">Уникальное значение блокиратора, используется для определения текущего, выполненного и завершенного блокиратора</param>
        public LockerClass(int time, long id)
        {
            Timer = time;
            LockerId = id;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;

        }

        public int temp
        {
            get { return _temp; }
            set { _temp = value; RaisePropertyChanged("temp"); }
        }


        private bool _isEnabledButton;
        private int _temp;

        private void DispatcherTimer_Tick(object sender, object e)
        {
            if (temp == Timer)
            {

                Stop();
            }
            else
            {
                OnTicked?.Invoke(this, null);
                IsLocked = true;
                temp++;
            }

        }
    }
}
