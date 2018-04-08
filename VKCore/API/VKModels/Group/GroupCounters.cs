using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VKCore.API.VKModels.Group
{
    public class GroupCounters
    {
        public string Name { get; set; }
        public string StringCount { get; set; }
        public int Count { get; set; }
        public ICommand ClickCommand { get; set; }
    }
}
