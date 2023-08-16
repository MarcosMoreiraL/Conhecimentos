using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Categories;
using FinanceiroApp.WPF.ViewModel.Wallets;
using FinanceiroApp.WPF.Views.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceiroApp.WPF.Views.Wallets
{
    /// <summary>
    /// Interaction logic for WalletItem.xaml
    /// </summary>
    public partial class WalletItem : UserControl
    {
        public WalletItemViewModel ViewModel { get; set; }
        public EventHandler WalletSelected;

        public WalletItem()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as WalletItemViewModel ?? new WalletItemViewModel();
        }

        public WalletItem(Wallet wallet, EventHandler updated, EventHandler walletSelected)
        {
            InitializeComponent();

            WalletSelected = walletSelected;

            ViewModel = Resources["vm"] as WalletItemViewModel ?? new WalletItemViewModel();
            ViewModel.SetWallet(wallet);
            ViewModel.Updated = updated;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            btnEditWallet.Visibility = btnDeleteWallet.Visibility = ViewModel.Wallet.Id == 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        public void SetWallet(Wallet wallet) => ViewModel.SetWallet(wallet);
        private void RadioButton_Checked(object sender, RoutedEventArgs e) => WalletSelected?.Invoke(this, e);

        private void btnEditWallet_Click(object sender, RoutedEventArgs e)
        {
            WalletRegister wr = new WalletRegister(ViewModel.Wallet);
            wr.ShowDialog();

            if(wr.DialogResult ?? false)
                ViewModel.Updated.Invoke(this, new EventArgs());
        }
    }
}