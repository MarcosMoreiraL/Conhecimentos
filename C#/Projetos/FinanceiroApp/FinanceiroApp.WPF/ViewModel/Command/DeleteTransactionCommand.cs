using FinanceiroApp.WPF.ViewModel.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    public class DeleteTransactionCommand : ICommand
    {
        public TransactionItemViewModel ViewModel { get; set; }
        public DeleteTransactionCommand(TransactionItemViewModel transactionItemViewModel)
        {
            ViewModel = transactionItemViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.DeleteTransaction();
        }
    }
}
