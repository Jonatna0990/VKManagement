using System;
using System.Windows.Input;
using Windows.UI.Popups;
using VKCore.API.SDK;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Auth;
using VKShop_Lite.Views.Main;

namespace VKShop_Lite.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand ExitCommand { get; set; }

        public SettingsViewModel()
        {
            ExitCommand = new DelegateCommand(t =>
            {Logout();
           
            });
        }

        private async void Logout()
        {
            var dialog = new MessageDialog(
                "Вы действительно хотите выйти?",
                "Выход из учетной записи");

            dialog.Commands.Add(new UICommand("Да") { Id = 0 });
            dialog.Commands.Add(new UICommand("Отмена") { Id = 1 });

            var result = await dialog.ShowAsync();
            if (result.Id.ToString() == "0")
            {
                VKSDK.Logout();
                UserMainPage.Current.Frame.Navigate(typeof (AuthPage));
             

            }

        }
    }
}
