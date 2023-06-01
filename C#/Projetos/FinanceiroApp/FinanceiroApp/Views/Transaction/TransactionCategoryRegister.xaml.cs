using FinanceiroApp.WPF.ViewModel;
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
        private ViewModel.TransactionCategoryViewModel ViewModel { get; set; }
        

        public TransactionCategoryRegister()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionCategoryViewModel;
        }
    }
}
