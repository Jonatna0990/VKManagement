using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Group;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class AdminMainViewModel : BaseViewModel
    {
        private GroupsClass _group;

        public GroupsClass Group
        {
            get { return _group; }
            set { _group = value;RaisePropertyChanged("Group"); }
        }

        public AdminMainViewModel(GroupsClass group)
        {
            Group = group;
        }
    }
}
