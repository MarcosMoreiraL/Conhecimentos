using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    public class SaveCommand : ICommand
    {
        public Base.FinAppViewModel ViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public SaveCommand(FinAppViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.Save();
        }
    }
}
