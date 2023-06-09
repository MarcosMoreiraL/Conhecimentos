using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.Views.Main;

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
            //txtEmail.Focus();

            //ViewModel = Resources["vm"] as LoginViewModel;

            //ViewModel.Authenticated += this.Authenticated;

            //if (!string.IsNullOrEmpty(ViewModel.GetLastEmail()))
            //    txtEmail.Text = ViewModel.GetLastEmail();
        }

        public Login(Entity.Models.User user)
        {
            InitializeComponent();
            //txtEmail.Focus();

            //ViewModel = Resources["vm"] as LoginViewModel;
            //ViewModel.UpdateUser(user); //PRECISO PARA INICIALIZAR O USER DO VM, CASO CONTRÁRIO VEM EM BRANCO

            //ViewModel.Updated += this.Updated;
            //ViewModel.SwitchViews();

            //tbNewPassword.Text = "Senha Atual";
            //tbConfirmPassword.Text = "Nova Senha";

            //btnRegister.Content = "Salvar";
        }

        //#region Window Events
        //private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter || e.Key == Key.Tab)
        //        txtPassword.Focus();
        //}
        //#endregion

        //private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetUserPassword((sender as PasswordBox).Password);
        //private void txtNewPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.NewPassword = txtNewPassword.Password;
        //private void txtConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.ConfirmPassword = txtConfirmPassword.Password;

        //private void Authenticated(object sender, EventArgs e)
        //{
        //    Dashboard dashboard = new Dashboard();
        //    dashboard.Show();

        //    this.Close();
        //}

        //private void Updated(object sender, EventArgs e) => this.Close();
    }
}
