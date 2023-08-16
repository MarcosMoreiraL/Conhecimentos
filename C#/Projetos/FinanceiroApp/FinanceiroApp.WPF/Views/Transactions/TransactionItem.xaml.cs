using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
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
    /// Interaction logic for TransactionItem.xaml
    /// </summary>
    public partial class TransactionItem : UserControl
    {
        public TransactionItemViewModel ViewModel { get; set; }
        public EventHandler Updated;

        public TransactionItem()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionItemViewModel ?? new TransactionItemViewModel();
        }

        public TransactionItem(Transaction t)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionItemViewModel ?? new TransactionItemViewModel();
            ViewModel.SetTransaction(t);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Updated = Updated;
        }

        private void btnEditTransaction_Click(object sender, RoutedEventArgs e)
        {
            TransactionRegister tr = new TransactionRegister(ViewModel.Transaction, ViewModel.Updated);
            tr.ShowDialog();
        }
    }
}
