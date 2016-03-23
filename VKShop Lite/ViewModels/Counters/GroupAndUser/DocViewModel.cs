using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.API.VKModels.Doc;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.User;
using VKCore.Helpers;
using VKCore.Helpers.Files;
using VKShop_Lite.Helpers;
using VKShop_Lite.ViewModels.Base;
using ВКонтакте.Models.List;
using CreateDocControl = VKShop_Lite.UserControls.PopupControl.Counters.CreateDocControl;
using EditDocControl = VKShop_Lite.UserControls.PopupControl.Counters.EditDocControl;

namespace VKShop_Lite.ViewModels.Counters.GroupAndUser
{
    public class DocViewModel : BaseViewModel
    {
        private GroupsClass group = null;
        private UserClass user = null;
        private ObservableCollection<DocClass> _docsCollection;
        private bool _canAddVisibility = false;
        public ICommand AddDocCommand { get; set; }
        public ICommand DeleteDocCommand { get; set; }
        public ICommand EditDocCommand { get; set; }
        public ICommand DownloadDocCommand { get; set; }
        public bool IsCanEdit
        {
            get { return _canAddVisibility; }
            set { _canAddVisibility = value; }
        }

        public ObservableCollection<DocClass> DocsCollection
        {
            get { return _docsCollection; }
            set { _docsCollection = value; RaisePropertyChanged("DocsCollection"); }
        }

        public DocViewModel(GroupsClass group, UserClass user = null)
        {
            DownloadDocCommand= new DelegateCommand(t =>
            {
                if (t != null)
                {
                    DocClass temp = t as DocClass;
                    FilesHelper.DownloadDocFile(temp.url);
                }
            });
            EditDocCommand = new DelegateCommand(t =>
            {
                if (t != null)
                {
                    EditDocControl edit = new EditDocControl(t as DocClass, res =>
                    {
                        foreach (var docs in DocsCollection)
                        {
                            if (docs.id == res.id) docs.title = res.title;
                        }
                    });
                    edit.ShowAsync();


                }
                
            });
            DeleteDocCommand = new DelegateCommand(t =>
            {
                DeleteDoc(t as DocClass);
            });
            if (group != null)
            {
                this.group = group;
                if (group.admin_level > 1) IsCanEdit = true;
                 AddDocCommand = new DelegateCommand(t =>
                {
                    var a = new CreateDocControl(doc =>
                    {
                        if (doc != null)
                        {
                            DocsCollection.Insert(0, doc);
                        }
                    }, group.id);
                    a.ShowAsync();
                });

               
                Load();
            }
            else
            {

                if (user != null)
                {
                    this.user = user;
                    if(user.id.ToString() == VKSDK.GetAccessToken().UserId) IsCanEdit = true;
                }

                    AddDocCommand = new DelegateCommand(t =>
                    {
                        var a = new CreateDocControl(doc =>
                        {
                            if (doc != null)
                            {

                            }
                        });
                        a.ShowAsync();
                    });

                    Load();
                
            }
            RegisterTasks("docs");
            TaskStarted("docs");
            ReloadCommand = new DelegateCommand(t =>
            {
                Load();
            });
           
        }

        private void DeleteDoc(DocClass doc)
        {
            if (doc != null)
            {
                var commands = new Dictionary<string, Action>();
                commands.Add("Удалить", () =>
                {

                    Dictionary<string, string> param = new Dictionary<string, string>();

                    if (group != null) param.Add("owner_id", String.Format("{0}", doc.owner_id));
                    param.Add("doc_id", String.Format("{0}", doc.id));

                    VKRequest.Dispatch<int>(
                      new VKRequestParameters(
                        SDocs.docs_delete, param),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              DocsCollection.Remove(doc);
                          }
                      });
                });
                commands.Add("Отмена", null);
                MessagesHelper.ShowDialogMessage("Удаление документа", "Вы действительно хотите удалить этот документ?", commands);
                
            }
          

        }
        private void Load()
        {
            Dictionary<string, string> param = new Dictionary<string, string>();

            if (group != null) param.Add("owner_id",String.Format("-{0}",group.id));
            else if(user !=null) param.Add("owner_id", String.Format("{0}", user.id));

            VKRequest.Dispatch<VKList<DocClass>>(
              new VKRequestParameters(
                SDocs.docs_get, param),
              (res) =>
              {
                  var q = res.ResultCode;
                  if (res.ResultCode == VKResultCode.Succeeded)
                  {
                      DocsCollection = res.Data.items.ToObservableCollection();
                      TaskFinished("docs");
                  }
                  else
                      TaskError("docs", "ошибка загрузки");
              });
          

        }
    }
}
