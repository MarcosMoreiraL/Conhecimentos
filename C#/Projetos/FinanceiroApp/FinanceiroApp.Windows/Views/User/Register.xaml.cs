using System;
using System.Windows;
using FinanceiroApp.Library.Exceptions;

namespace FinanceiroApp.WPF.Views.User
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public ViewModels.UserViewModel user = new ViewModels.UserViewModel();
        public Register()
        {
            InitializeComponent();
            this.DataContext = user;
        }

        private void ValidatePassword()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
                throw new RegisterValidationException("Preencha o nome de usuário!");

            if (string.IsNullOrEmpty(txtEmail.Text))
                throw new RegisterValidationException("Preencha o email!");

            if (string.IsNullOrEmpty(txtPassword.Text))
                throw new RegisterValidationException("Preencha a senha!");

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
                throw new RegisterValidationException("Preencha a confirmação de senha!");

            if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
                throw new RegisterValidationException("A senha deve ser igual à confirmação de senha!");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidatePassword();
                user.SaveUser();

                MessageBox.Show("Usuário registrado com sucesso!", "Registro de Usuário", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (RegisterValidationException rvex)
            {
                txtErrors.Text = rvex.Message;
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao registrar o usuário!", "Registro de Usuário", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
