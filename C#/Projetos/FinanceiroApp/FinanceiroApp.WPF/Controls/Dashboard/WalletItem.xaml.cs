using FinanceiroApp.Entity.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceiroApp.WPF.Controls.Dashboard
{
    /// <summary>
    /// Interaction logic for WalletItem.xaml
    /// </summary>
    public partial class WalletItem : UserControl
    {
        public static readonly DependencyProperty ItemProperty =
        DependencyProperty.Register("Wallet", typeof(Wallet), typeof(WalletItem));

        public Wallet Wallet
        {
            get { return (Wallet)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        static WalletItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WalletItem), new FrameworkPropertyMetadata(typeof(WalletItem)));
        }
    }
}
