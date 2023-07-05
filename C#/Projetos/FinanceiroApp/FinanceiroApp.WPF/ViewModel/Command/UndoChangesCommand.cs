using FinanceiroApp.WPF.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    public class UndoChangesCommand : ICommand
    {
        public User.UpdateUserViewModel ViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public UndoChangesCommand(UpdateUserViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.ResetUser();
        }
    }
}
