using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.ViewModel.Wallets;
using FinanceiroApp.WPF.Views.Transactions;
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
    /// Interaction logic for Wallets.xaml
    /// </summary>
    public partial class Wallets : UserControl
    {
        public int lastWalletId = 0;
        public WalletsViewModel ViewModel { get; set; }
        public EventHandler WalletSelected;

        public Wallets()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as WalletsViewModel ?? new WalletsViewModel();
        }

        private void btnNewWallet_Click(object sender, RoutedEventArgs e)
        {
            WalletRegister wr = new WalletRegister(ViewModel.Updated);
            wr.ShowDialog();
        }

        private void lvWallets_SelectionChanged(object sender, EventArgs e) => WalletSelected?.Invoke((sender as ListView)?.SelectedItem ?? new WalletItem(), e);
    }
}
