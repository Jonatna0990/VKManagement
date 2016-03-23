using System.Collections.ObjectModel;

namespace VKCore.API.VKModels.Photo
{
    public class PhotoSendParamClass
    {
        public ObservableCollection<PhotoClass> photos { get; set; }
        public PhotoClass selected_photo { get; set; }
    } 
}
