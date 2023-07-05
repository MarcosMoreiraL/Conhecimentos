using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Categories;
using FinanceiroApp.WPF.ViewModel.Wallets;
using FinanceiroApp.WPF.Views.Wallet;
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

namespace FinanceiroApp.WPF.Controls.Dashboard
{
    /// <summary>
    /// Interaction logic for WalletItem.xaml
    /// </summary>
    public partial class WalletItem : UserControl
    {
        public static readonly DependencyProperty WalletId = DependencyProperty.Register("Id", typeof(int), typeof(WalletItem));
        public int Id
        {
            get { return (int)GetValue(WalletId); }
            set { SetValue(WalletId, value); }
        }

        public static readonly DependencyProperty WalletDescription = DependencyProperty.Register("Description", typeof(string), typeof(WalletItem));
        public string Description
        {
            get { return (string)GetValue(WalletDescription); }
            set { SetValue(WalletDescription, value); }
        }

        public static readonly DependencyProperty WalletObject = DependencyProperty.Register("Wallet", typeof(Wallet), typeof(WalletItem));
        public Wallet Wallet
        {
            get { return (Wallet)GetValue(WalletObject); }
            set { SetValue(WalletObject, value); }
        }

        public WalletItemViewModel ViewModel { get; set; }
        public EventHandler Updated;

        public WalletItem()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as WalletItemViewModel ?? new WalletItemViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SetWallet(Wallet);
        }

        private void btnEditWallet_Click(object sender, RoutedEventArgs e)
        {
            WalletRegister wr = new WalletRegister(Updated, Wallet);
            wr.ShowDialog();
        }
    }
}