using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    public class FilterTransactionsCommand : ICommand
    {
        public DashboardViewModel ViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public FilterTransactionsCommand(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.UpdateTransactions();
        }
    }
}
