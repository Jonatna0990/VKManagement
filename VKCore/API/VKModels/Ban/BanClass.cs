using GalaSoft.MvvmLight;
using VKCore.API.VKModels.User;
using VKCore.Helpers;

namespace VKCore.API.VKModels.Ban
{
    public class BanUserClass : UserClass
    {
        private BanInfo _banInfo;

        public BanInfo ban_info
        {
            get { return _banInfo; }
            set { _banInfo = value;
                value.block_date = DateTimeHelper.GetTimeDifferenceForBlackList(value.date, value.end_date);
            }
        }
    }

    public class BanInfo : ViewModelBase
    {
        private long _date;
        private long _endDate;
        private int _reason;
        private int _blockDate;
        public long admin_id { get; set; }

        public long date
        {
            get { return _date; }
            set { _date = value; BanDate = DateTimeHelper.GetTimeAgoForBlackList(value); }
        }

        public string BanDate { get; set; }

        public int reason
        {
            get { return _reason; }
            set { _reason = value; RaisePropertyChanged("reason");}
        }

        public string comment { get; set; }
        public int comment_visible { get; set; }

        public int block_date
        {
            get { return _blockDate; }
            set { _blockDate = value;RaisePropertyChanged("block_date"); }
        }

        public long end_date
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                EndBanDate = DateTimeHelper.GetTimeAgoForBlackList(value);
          
            }
        }
        public string EndBanDate { get; set; }
    }
}
