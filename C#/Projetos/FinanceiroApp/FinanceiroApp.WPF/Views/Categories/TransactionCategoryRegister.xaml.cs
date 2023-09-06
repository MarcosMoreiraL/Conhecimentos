using FinanceiroApp.Entity.Models;
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

namespace FinanceiroApp.WPF.Views.Categories
{
    /// <summary>
    /// Interaction logic for TransactionCategoryRegister.xaml
    /// </summary>
    public partial class TransactionCategoryRegister : Window
    {
        private TransactionCategoryRegisterViewModel ViewModel { get; set; }

        public TransactionCategoryRegister()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionCategoryRegisterViewModel;
            ViewModel.Updated += Updated;
        }

        public TransactionCategoryRegister(TransactionCategory category)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionCategoryRegisterViewModel;
            ViewModel.Updated += Updated;

            ViewModel.SetCategory(category);
        }

        public void Updated(object sender, EventArgs e) => this.Close();
        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
