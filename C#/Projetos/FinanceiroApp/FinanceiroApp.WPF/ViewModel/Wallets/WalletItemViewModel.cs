using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command.Wallet;
using System;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletItemViewModel : FinAppViewModel
    {
        public int WalletId { get; set; }
        public string WalletDescription { get; set; }
        public DeleteWalletCommand DeleteCommand { get; set; }

        public Wallet Wallet { get; set; }

        public WalletItemViewModel()
        {
            Wallet = new Wallet();
            DeleteCommand = new DeleteWalletCommand(this);
        }
        public WalletItemViewModel(Wallet wallet)
        {
            Wallet = wallet;
        }

        public void SetWallet(Wallet wallet)
        {
            this.Wallet = wallet;
            OnPropertyChanged(nameof(Wallet));
        }

        public void DeleteWallet()
        {
            MessageBox.Show("Carteira apagada com sucesso!", "Excluir Carteira", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
