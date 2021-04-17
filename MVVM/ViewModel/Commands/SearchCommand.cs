using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        WeatherVM _vm;

        public SearchCommand(WeatherVM vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(parameter as string);
        }

        public void Execute(object parameter)
        {
            _vm.GetCities();
        }
    }
}
