using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VKCore.API.Core;
using VKCore.API.VKModels.Group;
using VKCore.API.VKModels.Link;
using VKCore.Helpers;
using VKShop_Lite.Helpers;
using VKShop_Lite.UserControls.PopupControl.Admin;
using VKShop_Lite.ViewModels.Base;

namespace VKShop_Lite.ViewModels.Groups.Admin.GroupControl
{
    public class GroupLinksViewModel : BaseViewModel
    {
        private GroupsClass group = null;
        private ObservableCollection<GroupLink> _links;

        public ObservableCollection<GroupLink> Links
        {
            get { return _links; }
            set { _links = value; RaisePropertyChanged("Links"); }
        }
        public ICommand AddLinkCommand { get; set; }
        public ICommand DeleteLinkCommand { get; set; }
        public ICommand EditLinkCommand { get; set; }
        public GroupLinksViewModel(GroupsClass group)
        {
            this.group = group;
            Links = new ObservableCollection<GroupLink>();
            Load();
            AddLinkCommand = new DelegateCommand(t =>
            {
                AddLink();
            });
            DeleteLinkCommand  = new DelegateCommand(t =>
            {
                PrepeareDeleteLink(t as GroupLink);
            });
            EditLinkCommand = new DelegateCommand(t =>
            {
                EditLink(t as GroupLink);
            });
        }

        private async void AddLink()
        {
            if (group != null)
            {
                var a = new AddLinkControl(t =>
                {
                    Links.Add(t);
                }, group);
                await a.ShowAsync();

            }
        }
       
        private void PrepeareDeleteLink(GroupLink link)
        {
            var commands = new Dictionary<string, Action>();
            commands.Add("Удалить", () =>
            {

                DeleteLink(link);
            });
            commands.Add("Отмена", null);
            MessagesHelper.ShowDialogMessage("Удаление ссылки", "Вы действительно хотите удалить эту ссылку?", commands);

        }
        private void DeleteLink(GroupLink link)
        {
            VKRequest.Dispatch<int>(
                new VKRequestParameters(
                  SGroups.groups_deleteLink, "group_id",@group.id.ToString(),"link_id",link.id.ToString()),
                (res) =>
                {

                    var q = res.ResultCode;
                    if (res.ResultCode == VKResultCode.Succeeded)
                    {

                        MessagesHelper.ShowMessage("Удаление ссылки", "Ссылка успешно удалена");

                    }

                    else {  MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }



                });

        }

        private async void EditLink(GroupLink link)
        {
            if (group != null)
            {
                var a = new EditLinkControl(t =>
                {
                    var enumerable = Links.FirstOrDefault(k => k.id == t.id);
                    if (enumerable != null)
                    {
                        enumerable.desc = t.desc;
                     }
                }, group, link);
                await a.ShowAsync();

            }

        }
        private void Load()
        {
            if (group != null)
            {
                VKRequest.Dispatch<List<GroupsClass>>(new VKRequestParameters(
              SGroups.groups_getById, "group_id", group.id.ToString(), "fields", "links"),
               (res) =>
               {

                   var q = res.ResultCode;
                   if (res.ResultCode == VKResultCode.Succeeded)
                   {
                       var a = res.Data.FirstOrDefault();
                       if (a.links !=null)
                           Links = a.links.ToObservableCollection();

                   }

                   else { MessagesHelper.ShowMessage("Ошибка", res.Error.error_msg); }



               });
            }
        }
    }
}
