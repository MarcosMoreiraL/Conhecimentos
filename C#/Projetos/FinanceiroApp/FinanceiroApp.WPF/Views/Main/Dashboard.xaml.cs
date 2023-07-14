using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.ViewModel.Categories;
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
using System.Windows.Shapes;

namespace FinanceiroApp.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public DashboardViewModel ViewModel { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as DashboardViewModel ?? new DashboardViewModel();
            lvWallets.ItemsSource = ViewModel.Wallets;
        }

        public void UpdateTransactions(object sender, EventArgs e) => ViewModel.UpdateUser();

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            Controls.User.UpdateUserWindow updateUserWindow = new Controls.User.UpdateUserWindow();
            updateUserWindow.ShowDialog();
        }

        private void btnNewTransaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewTransactionCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories categories = new Categories.TransactionCategories();
            categories.Show();
        }

        private void btnNewWallet_Click(object sender, RoutedEventArgs e)
        {
            Wallet.WalletRegister wr = new Wallet.WalletRegister(ViewModel.Updated);
            wr.ShowDialog();
        }

        private void categoryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories tc = new Categories.TransactionCategories();
            tc.ShowDialog();
        }
    }
}
