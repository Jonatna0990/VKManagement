using System.Collections.ObjectModel;
using System.Windows.Input;
using VKCore.API.VKModels.Attachment;

namespace VKShop_Lite.UserControls.MessagesControl
{
    public interface IConversatible
    {
          ICommand SendMessageCommand { get; set; }
          ICommand SelectedStickerCommand { get; set; }
          ICommand TypingCommand { get; set; }


          ICommand AddPhotoAttachCommand { get; set; }
          ICommand AddPhotoCameraCommand { get; set; }
          ICommand AddDocAttachCommand { get; set; }
          ICommand AddAudioAttachCommand { get; set; }
          ICommand AddVideoAttachCommand { get; set; }
          ICommand AddMapLocationCommand { get; set; }


          ICommand DeleteAttachCommand { get; set; }
          ICommand DeleteMessageCommand { get; set; }

          ICommand SelectionModeChangeCommand { get; set; }
          ICommand ReplyFwdMessagesCommand { get; set; }
          ICommand CopyMessageCommand { get; set; }

          ICommand LoadMoreCommand { get; set; }



          ICommand PhotosOpenCommand { get; set; }
          ICommand VideoOpenCommand { get; set; }
          ICommand DocOpenCommand { get; set; }
          ICommand AudioOpenCommand { get; set; }
          ICommand MapOpenCommand { get; set; }
          ICommand WallOpenCommand { get; set; }

        string UserWriteText { get; set; }
        string SendingMessageText { get; set; }
        bool AddMapEnabled { get; set; }
        bool AddAttachEnabled { get; set; }
        ObservableCollection<AttachmentsClass> AttachCollection { get; set; }
        

    }
}
