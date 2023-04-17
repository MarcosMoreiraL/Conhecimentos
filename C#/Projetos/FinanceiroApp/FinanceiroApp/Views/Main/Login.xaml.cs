using System;
using System.Windows;
using System.Windows.Input;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModels;

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

        private void ValidateLoginFields()
        {
            //TODO: passar tudo pra binding

            if (string.IsNullOrEmpty(txtUser.Text))
                throw new FinAppValidationException("Preencha o nome de usuário!");

            if (string.IsNullOrEmpty(txtPassword.Password))
                throw new FinAppValidationException("Preencha a senha!");
        }

        //TODO: Colocar esse método no ViewModel
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
    }
}
