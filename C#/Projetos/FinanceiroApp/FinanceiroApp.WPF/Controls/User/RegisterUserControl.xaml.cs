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
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {
        public RegisterViewModel ViewModel { get; set; }
        public EventHandler SwitchToLogin;

        public RegisterUserControl()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as RegisterViewModel ?? new RegisterViewModel();
        }

        private void txtNewPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetUserPassword((sender as PasswordBox).Password);

        private void txtConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetConfirmPassword((sender as PasswordBox).Password);

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ResetUser();
            SwitchToLogin.Invoke(sender, new EventArgs());
        }
    }
}
