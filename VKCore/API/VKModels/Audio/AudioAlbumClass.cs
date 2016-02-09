using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace VKCore.API.VKModels.Audio
{
    public class AudioAlbumClass : ViewModelBase
    {
        private string _count;
        public int id { get; set; }
        public int owner_id { get; set; }
        public string title { get; set; }

        public string count
        {
            get { return _count; }
            set { _count = value; RaisePropertyChanged("count"); }
        }
    }
}
