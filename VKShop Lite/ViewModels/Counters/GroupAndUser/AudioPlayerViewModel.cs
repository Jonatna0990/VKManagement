using System.Windows.Input;
using VKCore.API.VKModels.Attachment;
using VKCore.API.VKModels.Audio;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Conversation.User;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class AudioPlayerViewModel : BaseViewModel
    {
        public ICommand SendAudioToFriendCommand { get; set; }
        public ICommand AddAudioCommand { get; set; }
        public ICommand DeleteAudioCommand { get; set; }

        public AudioPlayerViewModel()
        {
            SendAudioToFriendCommand = new DelegateCommand(t =>
            {
                
                NavigateToCurrentPage( new AttachmentsClass() { audio = t as AudioClass} , new Scenario() { ClassType = typeof(UserDialogsPage) });
            });
        }
    }
}
