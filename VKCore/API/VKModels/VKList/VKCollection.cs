using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace VKCore.API.VKModels.VKList
{
    public class VKCollection<T> : ViewModelBase
    {
        private ObservableCollection<T> _items;
        private int _count;

        public int count
        {
            get { return _count; }
            set { _count = value;RaisePropertyChanged("count"); }
        }

        public ObservableCollection<T> items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged("items"); }
        }
    }
}
