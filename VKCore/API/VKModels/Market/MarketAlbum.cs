using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VKCore.API.VKModels.Photo;
using VKCore.Converters.DateTimeConverter;

namespace VKCore.API.VKModels.Market
{
    public class MarketAlbum : ViewModelBase
    {
        private int _updatedTime;
        private string _title;
        private PhotoClass _photo;
        public int id { get; set; }
        public int owner_id { get; set; }

        public string title
        {
            get { return _title; }
            set { _title = value;RaisePropertyChanged("title"); }
        }

        public int count { get; set; }

        public int updated_time
        {
            get { return _updatedTime; }
            set { _updatedTime = value; Date = NewsDataTimeConvert.getTimeAgo(value); }
        }

        public string Date { get; set; }

        public PhotoClass photo
        {
            get { return _photo; }
            set { _photo = value; RaisePropertyChanged("photo"); }
        }
    }
}
