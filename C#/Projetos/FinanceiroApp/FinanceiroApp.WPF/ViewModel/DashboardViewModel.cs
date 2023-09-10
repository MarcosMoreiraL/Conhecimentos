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
        public int CurrentCategoryId { get; set; } = 0;
        public decimal DisplayedTotal { get; set; } = 0m;
        public decimal WalletTotal { get; set; } = 0m;
        public decimal OverallTotal { get; set; } = 0m;

        public TransactionFilter Filter { get; set; }

        public FinanceiroApp.Entity.Models.User User { get; set; }
        public ObservableCollection<WalletItem> Wallets { get; set; }
        public ObservableCollection<TransactionItem> Transactions { get; set; }
        public ObservableCollection<TransactionCategory> Categories { get; set; }

        public FilterTransactionsCommand FilterTransactionsCommand { get; set; }
        public EventHandler Updated;
        public EventHandler WalletSelected;

        public DashboardViewModel()
        {
            this.User = App.User;
            this.Filter = new TransactionFilter();
            this.Wallets = new ObservableCollection<WalletItem>();
            this.Transactions = new ObservableCollection<TransactionItem>();
            this.Categories = new ObservableCollection<TransactionCategory>();
            FilterTransactionsCommand = new FilterTransactionsCommand(this);

            WalletSelected += UpdateTransactionsControl;
            Updated += UpdateWalletsControl;
            CurrentWalletId = -1;
            CurrentCategoryId = -1;

            UpdateWallets();
            UpdateCategories();
        }

        public async void UpdateUser()
        {
            try
            {
                this.User = await App.UpdateUser();
                OnPropertyChanged(nameof(User));

                UpdateWallets();
                UpdateTransactions();
                UpdateCategories();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar as informações do usuário!", "DashboardViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //TODO: REFACTOR DA CHAMADA DESSA FUNÇÃO
        public void UpdateTransactionFilters(Filter.FilterTypes filterType, Filter.OrderTypes order, TransactionFilter.TransactionTypesFilter transactionType = TransactionFilter.TransactionTypesFilter.None, int categoryId = -1)
        {
            this.Filter.FilterType = filterType;
            this.Filter.OrderType = order;
            this.Filter.Type = transactionType;
            this.Filter.CategoryId = categoryId;
        }

        public void UpdateCategories()
        {
            Categories.Clear();
            Categories.Add(new TransactionCategory()
            {
                Id = -1,
                Description = "Todas",
                UserId = User.Id
            });

            foreach (TransactionCategory category in User.TransactionCategories.OrderBy(c => c.Description))
                Categories.Add(category);

            OnPropertyChanged(nameof(Categories));
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
                Id = -1,
                Description = "Todas"
            }, Updated, WalletSelected));

            foreach (Wallet wallet in User.Wallets)
                Wallets.Add(new WalletItem(wallet, Updated, WalletSelected));
            
            OnPropertyChanged(nameof(Wallets));
        }

        #endregion

        #region Transactions

        public void UpdateTransactions(int walletId = 0)
        {
            try
            {
                walletId = walletId == 0 ? CurrentWalletId : walletId;

                Transactions.Clear();
                IEnumerable<Transaction> transactions = User.Transactions.Where(t => (walletId == -1 || t.WalletId == walletId) && (Filter.CategoryId == -1 || t.CategoryId == Filter.CategoryId) 
                && (t.DateTime >= Filter.Begin && t.DateTime <= Filter.End) && (Filter.Type.ToString().Equals("None") || t.Type.ToString().Equals(Filter.Type.ToString())));

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
                WalletTotal = walletId == -1 ? DisplayedTotal : User.Transactions.Where(t => t.WalletId == CurrentWalletId).Sum(t => t.RealValue);
                OverallTotal = User.Transactions.Sum(t => t.RealValue);

                OnPropertyChanged(nameof(Transactions));
                OnPropertyChanged(nameof(DisplayedTotal));
                OnPropertyChanged(nameof(WalletTotal));
                OnPropertyChanged(nameof(OverallTotal));
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar as movimentações!", "DashboardViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        public override void Action()
        {
            base.Action();
        }
    }
}