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

namespace FinanceiroApp.WPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for TransactionCategoryRegister.xaml
    /// </summary>
    public partial class TransactionCategoryRegister : Window
    {
        private ViewModels.TransactionCategoryViewModel TransactionCategory { get; set; }

        public TransactionCategoryRegister()
        {
            InitializeComponent();
            this.DataContext = TransactionCategory;
        }

        public TransactionCategoryRegister(ViewModels.TransactionCategoryViewModel transactionCategory)
        {
            InitializeComponent();
            this.TransactionCategory = transactionCategory;
            this.DataContext = TransactionCategory;
        }

        private void btnSaveCategory_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
