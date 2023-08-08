using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
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
        public FinanceiroApp.Entity.Models.User User { get; set; }
        public ObservableCollection<WalletItem> Wallets { get; set; }
        public ObservableCollection<TransactionItem> Transactions { get; set; }

        public EventHandler Updated;
        public EventHandler WalletSelected;

        public DashboardViewModel()
        {
            this.User = App.User;
            this.Wallets = new ObservableCollection<WalletItem>();
            Updated += UpdateWalletsControl;
            UpdateWallets();
        }

        #region Wallets

        public void UpdateWalletsControl(object sender, EventArgs e) => UpdateUser();

        public async void UpdateUser()
        {
            try
            {
                this.User = await App.UpdateUser();
                OnPropertyChanged(nameof(User));

                UpdateWallets();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar carteira!", "WalletsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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



        #endregion

        public override void Action()
        {
            base.Action();
        }
    }
}