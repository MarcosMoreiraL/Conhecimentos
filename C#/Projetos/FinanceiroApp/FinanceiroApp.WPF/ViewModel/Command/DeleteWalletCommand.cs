using FinanceiroApp.WPF.ViewModel.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command.Wallet
{
    public class DeleteWalletCommand : ICommand
    {
        private WalletItemViewModel ViewModel { get; set; }

        public DeleteWalletCommand(WalletItemViewModel walletItemViewModel)
        {
            ViewModel = walletItemViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.DeleteWallet();
        }
    }
}
