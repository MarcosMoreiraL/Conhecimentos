using FinanceiroApp.WPF.ViewModel.Categories;
using FinanceiroApp.WPF.ViewModel.Wallets;
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

namespace FinanceiroApp.WPF.Views.Wallet
{
    /// <summary>
    /// Interaction logic for WalletRegister.xaml
    /// </summary>
    public partial class WalletRegister : Window
    {
        private WalletRegisterViewModel ViewModel { get; set; }

        public WalletRegister()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as WalletRegisterViewModel ?? new WalletRegisterViewModel();
        }
    }
}
