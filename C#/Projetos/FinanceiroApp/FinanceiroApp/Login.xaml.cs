﻿using System;
using System.Windows;
using System.Windows.Input;
using FinanceiroApp.Library.Exceptions;

namespace FinanceiroApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void ValidateLoginFields()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
                throw new FinAppValidationException("Preencha o nome de usuário!");

            if (string.IsNullOrEmpty(txtPassword.Password))
                throw new FinAppValidationException("Preencha a senha!");
        }

        private void UserLogin()
        {
            try
            {
                ValidateLoginFields();

                Library.ViewModels.LoginViewModel user = Library.ViewModels.LoginViewModel.GetUser(txtUser.Text, txtPassword.Password);

                if (user != null)
                {
                    Library.Session.User = user;
                    WPF.Views.Main.Dashboard dashBoard = new WPF.Views.Main.Dashboard();
                    dashBoard.Show();
                    this.Close();
                }
            }
            catch (FinAppValidationException rvex)
            {
                txtErrors.Visibility = Visibility.Visible;
                txtErrors.Text = rvex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            WPF.Views.User.Register registerWindow = new WPF.Views.User.Register();
            registerWindow.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) => UserLogin();

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                UserLogin();
        }
    }
}
