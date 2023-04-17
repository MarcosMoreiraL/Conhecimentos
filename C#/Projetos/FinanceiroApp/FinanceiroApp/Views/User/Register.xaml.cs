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
        bool UpdatingUser = false;
        public ViewModels.LoginViewModel loginVM = new ViewModels.LoginViewModel();

        public Register()
        {
            InitializeComponent();
            this.DataContext = loginVM;
            LoadWindow();
        }

        public Register(Entity.Models.User user)
        {
            InitializeComponent();
            this.loginVM = new ViewModels.LoginViewModel(user);
            this.DataContext = this.loginVM;
            UpdatingUser = true;
            LoadWindow();
        }

        public void LoadWindow()
        {
            if (UpdatingUser)
            {
                this.Title = "Editar Perfil";
                txtTitle.Text = "Editar Perfil";
                tbNewPassword.Text = "Nova Senha";

                tbCurPassword.Visibility = Visibility.Visible;
                txtCurPassword.Visibility = Visibility.Visible;
            }
            else
            {
                txtTitle.Text = "Registrar";
                tbNewPassword.Text = "Senha";
            }
        }

        private void ValidateRegister()
        {
            if (string.IsNullOrEmpty(txtUser.Text))
                throw new FinAppValidationException("Preencha o nome de usuário!");

            if (string.IsNullOrEmpty(txtEmail.Text))
                throw new FinAppValidationException("Preencha o email!");

            if (string.IsNullOrEmpty(txtPassword.Password))
                throw new FinAppValidationException("Preencha a senha!");
            
            if (UpdatingUser)
            {
                if (string.IsNullOrEmpty(txtCurPassword.Password))
                    throw new FinAppValidationException("Preencha a senha atual!");

                if (!string.IsNullOrEmpty(txtCurPassword.Password))
                    loginVM.ValidatePassword(txtCurPassword.Password);
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Password))
                throw new FinAppValidationException("Preencha a confirmação de senha!");

            if (!txtPassword.Password.Equals(txtConfirmPassword.Password))
                throw new FinAppValidationException("A senha deve ser igual à confirmação de senha!");
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {              
                ValidateRegister();
                loginVM.User.Password = txtPassword.Password;
                loginVM.SaveUser();

                MessageBox.Show("Usuário salvo com sucesso!", "Registro de Usuário", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
            }
            catch (FinAppValidationException rvex)
            {
                txtErrors.Visibility = Visibility.Visible;
                txtErrors.Text = rvex.Message;
            }catch(Exception ex)
            {
                MessageBox.Show("Erro ao salvar o usuário!", "Registro de Usuário", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
