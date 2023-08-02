using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using FinanceiroApp.WPF.Views.Transactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Transactions
{
    public class TransactionsViewModel : FinAppViewModel
    {
        public int CurrentWalletId { get; set; } = 0;
        public Entity.Models.User User { get; set; }
        public ObservableCollection<TransactionItem> Transactions { get; set; }
        public TransactionsViewModel()
        {
            this.User = App.User;
            Transactions = new ObservableCollection<TransactionItem>();
        }

        public async void UpdateUser()
        {
            try
            {
                App.SetUser(await UserDatabaseHelper.GetUserAsync(App.User.Id));
                this.User = App.User;
                OnPropertyChanged(nameof(User));

                UpdateTransactions(CurrentWalletId);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar as informações do usuário!", "TransactionsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public async void UpdateTransactions(int walletId)
        {
            try
            {
                Transactions.Clear();
                IEnumerable<Transaction> transactions = walletId == 0 ? User.Transactions : User.Transactions.Where(t => t.WalletId == walletId);

                foreach (Transaction t in transactions)
                    Transactions.Add(new TransactionItem(t));

                CurrentWalletId = walletId;

                OnPropertyChanged(nameof(Transactions));
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar as movimentações!", "TransactionsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void Action()
        {
            base.Action();
        }
    }
}
