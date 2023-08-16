using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using FinanceiroApp.WPF.Views.Transactions;
using FinanceiroApp.WPF.Views.Wallets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel
{
    public class DashboardViewModel : FinAppViewModel
    {
        public int CurrentWalletId { get; set; } = 0;
        public decimal DisplayedTotal { get; set; } = 0m;
        public decimal OverallTotal { get; set; } = 0m;

        public TransactionFilter Filter { get; set; }

        public FinanceiroApp.Entity.Models.User User { get; set; }
        public ObservableCollection<WalletItem> Wallets { get; set; }
        public ObservableCollection<TransactionItem> Transactions { get; set; }

        public FilterTransactionsCommand FilterTransactionsCommand { get; set; }
        public EventHandler Updated;
        public EventHandler WalletSelected;

        public DashboardViewModel()
        {
            this.User = App.User;
            this.Filter = new TransactionFilter();
            this.Wallets = new ObservableCollection<WalletItem>();
            this.Transactions = new ObservableCollection<TransactionItem>();
            FilterTransactionsCommand = new FilterTransactionsCommand(this);

            WalletSelected += UpdateTransactionsControl;
            Updated += UpdateWalletsControl;
            UpdateWallets();
        }

        public async void UpdateUser()
        {
            try
            {
                this.User = await App.UpdateUser();
                OnPropertyChanged(nameof(User));

                UpdateWallets();
                UpdateTransactions();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar carteira!", "WalletsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateFilters(Filter.FilterTypes type, Filter.OrderTypes order)
        {
            this.Filter.FilterType = type;
            this.Filter.OrderType = order;
        }

        #region Wallets

        public void UpdateWalletsControl(object? sender, EventArgs e) => UpdateUser();
        private void UpdateTransactionsControl(object? sender, EventArgs e)
        {
            int walletId = (sender as WalletItem) == null ? -1 : (sender as WalletItem).ViewModel.Wallet.Id;
            UpdateTransactions(walletId);
        }
        public void UpdateWallets()
        {
            Wallets.Clear();

            Wallets.Add(new WalletItem(new Entity.Models.Wallet()
            {
                Id = 0,
                Description = "Todas"
            }, Updated, WalletSelected));

            foreach (Wallet wallet in User.Wallets)
                Wallets.Add(new WalletItem(wallet, Updated, WalletSelected));

            OnPropertyChanged(nameof(Wallets));
        }

        #endregion

        #region Transactions

        public void UpdateTransactions(int walletId = -1)
        {
            try
            {
                walletId = walletId == -1 ? CurrentWalletId : walletId;

                Transactions.Clear();
                IEnumerable<Transaction> transactions = walletId == 0 ? User.Transactions.Where(t => t.DateTime >= Filter.Begin && t.DateTime <= Filter.End) 
                    : User.Transactions.Where(t => t.WalletId == walletId && (t.DateTime >= Filter.Begin && t.DateTime <= Filter.End));

                if (Filter.FilterType == Helpers.Filter.FilterTypes.DateTime)
                    transactions = Filter.OrderType == Helpers.Filter.OrderTypes.Ascending ? transactions.OrderBy(t => t.DateTime) : transactions.OrderByDescending(t => t.DateTime);
                else if (Filter.FilterType == Helpers.Filter.FilterTypes.Number)
                    transactions = Filter.OrderType == Helpers.Filter.OrderTypes.Ascending ? transactions.OrderBy(t => t.Value) : transactions.OrderByDescending(t => t.Value);

                foreach (Transaction t in transactions)
                    Transactions.Add(new TransactionItem(t)
                    {
                        Updated = Updated
                    });

                CurrentWalletId = walletId;

                DisplayedTotal = transactions.Sum(t => t.RealValue);
                OverallTotal = User.Transactions.Sum(t => t.RealValue);

                OnPropertyChanged(nameof(Transactions));
                OnPropertyChanged(nameof(DisplayedTotal));
                OnPropertyChanged(nameof(OverallTotal));
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar as movimentações!", "TransactionsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        public override void Action()
        {
            base.Action();
        }
    }
}