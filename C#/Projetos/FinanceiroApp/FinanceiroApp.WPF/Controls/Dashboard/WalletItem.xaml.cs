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
        public static readonly DependencyProperty WalletId = DependencyProperty.Register("Id", typeof(int), typeof(WalletItem));
        public int Id
        {
            get { return (int)GetValue(WalletId); }
            set { SetValue(WalletId, value); }
        }

        public static readonly DependencyProperty WalletDescription = DependencyProperty.Register("Description", typeof(string), typeof(WalletItem));
        public string Description
        {
            get { return (string)GetValue(WalletDescription); }
            set { SetValue(WalletDescription, value); }
        }

        public static readonly DependencyProperty WalletObject = DependencyProperty.Register("Wallet", typeof(Wallet), typeof(WalletItem));
        public Wallet Wallet
        {
            get { return (Wallet)GetValue(WalletObject); }
            set { SetValue(WalletObject, value); }
        }

        public WalletItemViewModel ViewModel { get; set; }

        public WalletItem()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as WalletItemViewModel ?? new WalletItemViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.SetWallet(Wallet);
        }

        /* TODO: AULA DE BACON
         EMPIRISTA
        CONHECIMENTO EH PODER
        PRECARIEDADE DO INTELECTO
        METODO INDUTIVO
        FATOS PARTICULARES
        LUTA CONTRA IDOLATRIA(VIES)
        TABELAS DE HISTORIA NATURAL(COLETA)
        PROGRESSO

        DOUTRINA DOS IDOLOS

        1 - TRIBO -> DEFICIENCIAS UNIVERSAIS
        2 - CAVERNA
        3 - FORO/MERCADO -> LINGUAGEM
        4 - TEATRO -> "FABULAS DOS SISTEMAS"

        HATER DA MATEMATICA E DO PITAGORAS
         */
    }
}
