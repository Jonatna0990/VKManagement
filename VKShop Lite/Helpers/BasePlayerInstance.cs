using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.Audio;

namespace VKShop_Lite.Helpers
{
    public class BasePlayerInstance
    {
        public static PlayerBase Base { get { return PlayerBase.Instance; } }
        public BasePlayerInstance()
        {

        }
    }
}
