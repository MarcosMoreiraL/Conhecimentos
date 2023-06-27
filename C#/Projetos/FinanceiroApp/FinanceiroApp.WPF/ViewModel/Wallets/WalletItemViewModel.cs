using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Base;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletItemViewModel : FinAppViewModel
    {
        public Wallet Wallet { get; set; }

        public WalletItemViewModel()
        {
            Wallet = new Wallet();
        }
        public WalletItemViewModel(Wallet wallet)
        {
            Wallet = wallet;
        }
    }
}
