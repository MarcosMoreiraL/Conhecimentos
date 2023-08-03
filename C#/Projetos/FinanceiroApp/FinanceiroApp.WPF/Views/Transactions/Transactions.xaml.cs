using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.ViewModel.Transactions;
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

namespace FinanceiroApp.WPF.Views.Transactions
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : UserControl
    {
        public TransactionsViewModel ViewModel { get; set; }

        public Transactions()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionsViewModel ?? new TransactionsViewModel();
        }

        public void LoadTransactions(int walletId) => ViewModel.UpdateTransactions(walletId);

        private void btnNewTransaction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ViewModel.User.Wallets.Any())
                    throw new FinanceiroApp.Library.Exceptions.FinAppValidationException("Não é possível criar uma movimentação para um usuário sem carteiras!");

                if (!ViewModel.User.TransactionCategories.Any())
                    throw new FinanceiroApp.Library.Exceptions.FinAppValidationException("Não é possível criar uma movimentação para um usuário sem categorias!");

                TransactionRegister tr = new TransactionRegister(Updated);
                tr.ShowDialog();
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Movimentações", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar a movimentação!", "Movimentações", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Updated(object? sender, EventArgs e) => ViewModel.UpdateUser();
    }
}
