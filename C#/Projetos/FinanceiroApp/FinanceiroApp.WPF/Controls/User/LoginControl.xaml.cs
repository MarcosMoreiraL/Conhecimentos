using FinanceiroApp.WPF.ViewModel.User;
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

namespace FinanceiroApp.WPF.Controls.User
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public EventHandler SwitchToRegister;
        public LoginViewModel ViewModel { get; set; }

        public LoginControl()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as LoginViewModel ?? new LoginViewModel();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
                txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetUserPassword((sender as PasswordBox).Password);

        private void btnRegisterMode_Click(object sender, RoutedEventArgs e) => SwitchToRegister.Invoke(this, new EventArgs());
    }
}
