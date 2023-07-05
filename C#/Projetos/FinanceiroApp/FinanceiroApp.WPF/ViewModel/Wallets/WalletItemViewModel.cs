using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command.Wallet;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using System;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletItemViewModel : FinAppViewModel
    {
        //public int WalletId { get; set; }
        //public string WalletDescription { get; set; }
        public DeleteWalletCommand DeleteCommand { get; set; }
        public EventHandler Updated;

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

        public async void DeleteWallet()
        {
            try
            {
                if(MessageBox.Show($"Tem certeza de que deseja exluir a carteira {Wallet.Description}?", "Excluir Carteira", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    await WalletDatabaseHelper.DeleteAsync(Wallet.Id);
                    MessageBox.Show("Carteira excluída com sucesso!", "Excluir Carteira", MessageBoxButton.OK, MessageBoxImage.Information);
                    Updated.Invoke(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao excluir carteira!", "Excluir Carteira", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
