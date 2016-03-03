using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.VKModels.Doc;

// Документацию по шаблону элемента диалогового окна содержимого см. в разделе http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.UserControls.PopupControl.Counters
{
    public sealed partial class EditDocControl : ContentDialog
    {
        private DocClass doc = null;
        private Action<DocClass> callbackAction = null;
        public EditDocControl(DocClass doc,Action<DocClass> callback )
        {
            this.InitializeComponent();
            this.doc = doc;
            callbackAction = callback;
        }
        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (doc != null)
            {
                Dictionary<string, string> param = new Dictionary<string, string>();

                if (DocName.Text.Length > 0 && DocName.Text.Length < 127) param.Add("title", DocName.Text);

                    param.Add("owner_id", String.Format("{0}", doc.owner_id));
                    param.Add("doc_id", String.Format("{0}", doc.id));

                    VKRequest.Dispatch<int>(
                      new VKRequestParameters(
                        SDocs.docs_edit, param),
                      (res) =>
                      {
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              var ret = doc;
                              ret.title = DocName.Text;
                              callbackAction?.Invoke(ret);
                          }
                              this.Hide();
                              PopupEx popup =(res.ResultCode == VKResultCode.Succeeded)? 
                              new PopupEx("Редактирование  документа", "Документ успешно отедактирован"):
                              new PopupEx("Редактирование  документа", "При загрузке документа возникла ошибка");
                              popup.ShowAsync();
                         
                            
                          
                      });
                
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
