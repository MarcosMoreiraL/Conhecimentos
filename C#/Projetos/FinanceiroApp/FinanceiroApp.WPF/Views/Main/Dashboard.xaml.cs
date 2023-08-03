using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.ViewModel.Categories;
using FinanceiroApp.WPF.Views.Transactions;
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
            wallets.WalletSelected += WalletSelected;
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            Controls.User.UpdateUserWindow updateUserWindow = new Controls.User.UpdateUserWindow();
            updateUserWindow.ShowDialog();
        }

        private void btnViewTransactionCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories categories = new Categories.TransactionCategories();
            categories.ShowDialog();
        }

        private void categoryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories tc = new Categories.TransactionCategories();
            tc.ShowDialog();
        }

        private void WalletSelected(object sender, EventArgs e)
        {
            int walletId = (sender as WalletItem) == null ? -1 : (sender as WalletItem).Id;
            transactions.LoadTransactions(walletId);
        }
    }
}
