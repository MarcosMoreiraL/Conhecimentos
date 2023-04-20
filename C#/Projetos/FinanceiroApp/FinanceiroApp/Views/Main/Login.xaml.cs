using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel;

namespace FinanceiroApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public LoginViewModel ViewModel { get; set; }

        public Login()
        {
            InitializeComponent();
            txtUser.Focus();

            ViewModel = Resources["vm"] != null ? Resources["vm"] as LoginViewModel : new LoginViewModel();
        }

        #region Window Events
        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO: Login com o Enter
        }
        #endregion

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.NewPassword = (sender as PasswordBox).Password;

        private void txtConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.ConfirmPassword = txtConfirmPassword.Password;
    }
}
