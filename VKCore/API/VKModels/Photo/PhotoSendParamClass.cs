using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKCore.API.VKModels.Photo
{
    public class PhotoSendParamClass
    {
        public ObservableCollection<PhotoClass> photos { get; set; }
        public PhotoClass selected_photo { get; set; }
    } 
}
