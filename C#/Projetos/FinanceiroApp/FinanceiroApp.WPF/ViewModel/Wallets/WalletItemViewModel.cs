using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Base;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletItemViewModel : FinAppViewModel
    {
        public int WalletId { get; set; }
        public string WalletDescription { get; set; }

        public Wallet Wallet { get; set; }

        public WalletItemViewModel()
        {
            Wallet = new Wallet();
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
    }
}
