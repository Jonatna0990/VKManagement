using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Board;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Counters.Group
{
    public  class SelectedTopicViewModel : BaseViewModel
    {
        private BoardRootClass board;
        public ObservableCollection<BoarsClass> messages { get; set; }


        
    }
}
