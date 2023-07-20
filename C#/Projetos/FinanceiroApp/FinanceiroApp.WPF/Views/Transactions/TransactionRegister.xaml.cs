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
using System.Windows.Shapes;

namespace FinanceiroApp.WPF.Views.Transactions
{
    /// <summary>
    /// Interaction logic for TransactionRegister.xaml
    /// </summary>
    public partial class TransactionRegister : Window
    {
        TransactionRegisterViewModel ViewModel { get; set; }

        public TransactionRegister()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as TransactionRegisterViewModel ?? new TransactionRegisterViewModel();
            ViewModel.Updated += Updated;
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ViewModel != null && ViewModel.Transaction != null)
            {
                ViewModel.Transaction.Type = Enum.Parse<Entity.Models.Transaction.TransactionType>((sender as ComboBox).SelectedValue.ToString() ?? "Income");
            }
        }

        private void Updated(object sender, EventArgs e) => this.Close();
    }
}
