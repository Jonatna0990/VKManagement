using System;
using System.Diagnostics;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Doc;
using VKCore.Helpers.Files;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Counters
{
    public sealed partial class CreateDocControl : ContentDialog
    {
        private Action<DocClass> action = null;
        private long group_id = 0;
        public CreateDocControl(Action<DocClass> action,long group_id =0 )
        {
            this.InitializeComponent();
            this.action = action;
            this.group_id = group_id;
        }

     

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var a = await FilesHelper.GetDocFiles();
            if (a != null)
            {
                BasicProperties file_size = await a.GetBasicPropertiesAsync();
                
                Debug.WriteLine(FilesHelper.GetFileSize(file_size));
                ProgressGrid.Visibility = Visibility.Visible;
                VKUploadRequest.DocProfileUploadRequest(group_id).Dispatch(a, i => { }, x =>
                {

                }, c =>
                {
                  
                      

                    
                    ProgressGrid.Visibility = Visibility.Collapsed;
                    action?.Invoke(c.Data);
                    this.Hide();

                    this.Hide();
                    PopupEx popup = (c.ResultCode == VKResultCode.Succeeded) ?
                    new PopupEx("Загрузка документа", "Документ успешно загружен") :
                    new PopupEx("Загрузка документа","При загрузке документа возникла ошибка " + c.Error.error_msg);
                    popup.ShowAsync();
                   
                 

                });
            }
        }
    }
}
