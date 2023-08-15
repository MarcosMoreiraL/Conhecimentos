using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Command.Wallet;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Transactions
{
    public class TransactionItemViewModel : FinAppViewModel
    {
        public Transaction Transaction { get; set; }

        public DeleteTransactionCommand DeleteCommand { get; set; }
        public EventHandler Updated;

        public TransactionItemViewModel()
        {
            Transaction = new Transaction();
            DeleteCommand = new DeleteTransactionCommand(this);
        }

        public void SetTransaction(Transaction transaction)
        {
            this.Transaction = transaction;
            OnPropertyChanged(nameof(Transaction));
        }

        public async void DeleteTransaction()
        {
            try
            {
                if (MessageBox.Show($"Tem certeza de que deseja exluir a movimentação {Transaction.Description}?", "Excluir Movimentação", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    await TransactionDatabaseHelper.DeleteAsync(Transaction.Id);
                    MessageBox.Show("Movimentação excluída com sucesso!", "Excluir Movimentação", MessageBoxButton.OK, MessageBoxImage.Information);
                    Updated.Invoke(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao excluir movimentação!", "Excluir Movimentação", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
