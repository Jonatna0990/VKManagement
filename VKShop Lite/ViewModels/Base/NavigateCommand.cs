using System;
using System.Windows.Input;
using VKShop_Lite.Common;

namespace VKShop_Lite.ViewModels.Base
{
    public class NavigateCommand<T> : BaseViewModel, ICommand where T : class
    {

        public event EventHandler CanExecuteChanged;

        private Scenario scenario { get; set; }


        public NavigateCommand(Scenario scen)
        {

            scenario = scen;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            return false;
        }


        public void Execute(object parameter)
        {
            NavigateToPage<T>(parameter, scenario);
        }
    }
}
