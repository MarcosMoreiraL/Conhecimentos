using FinanceiroApp.Entity.Models;
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

namespace FinanceiroApp.WPF.Views.Categories
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class TransactionCategories : Window
    {
        TransactionCategoriesViewModel ViewModel { get; set; }
        EventHandler Updated;

        public TransactionCategories()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionCategoriesViewModel ?? new TransactionCategoriesViewModel();
        }

        public TransactionCategories(EventHandler e)
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionCategoriesViewModel ?? new TransactionCategoriesViewModel();
            Updated = e;
        }

        private void btnNewTransactionCategory_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategoryRegister categoryRegister = new Categories.TransactionCategoryRegister();
            categoryRegister.ShowDialog();

            ViewModel.UpdateUser();
        }

        private void EditCategory(TransactionCategory category)
        {
            TransactionCategoryRegister categoryRegister = new TransactionCategoryRegister(category);
            categoryRegister.ShowDialog();

            ViewModel.UpdateUser();
        }

        private void dgCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataGridRow).DataContext != null && (sender as DataGridRow).DataContext is TransactionCategory)
                EditCategory(((sender as DataGridRow).DataContext as TransactionCategory));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext != null && (sender as Button).DataContext is TransactionCategory)
                EditCategory(((sender as Button).DataContext as TransactionCategory));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext != null && (sender as Button).DataContext is TransactionCategory)
                ViewModel.DeleteCategory(((sender as Button).DataContext as TransactionCategory).Id);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}