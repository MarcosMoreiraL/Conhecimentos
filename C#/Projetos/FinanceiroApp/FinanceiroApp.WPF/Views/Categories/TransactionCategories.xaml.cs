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

namespace FinanceiroApp.WPF.Views.Categories
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class TransactionCategories : Window
    {
        public TransactionCategories()
        {
            InitializeComponent();
        }

        private void btnNewTransactionCategory_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategoryRegister categoryRegister = new Categories.TransactionCategoryRegister();
            categoryRegister.Show();
        }
    }
}
