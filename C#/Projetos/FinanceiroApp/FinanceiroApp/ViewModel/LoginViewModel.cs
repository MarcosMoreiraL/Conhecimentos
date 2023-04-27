using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers;

namespace FinanceiroApp.WPF.ViewModel
{
    public class LoginViewModel : ViewModel.Base.FinAppViewModel
    {
        #region Props
        private User user;
        public User User 
        {
            get => user;

            set
            {
                if(value is User)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool ShowingLogin { get; set; }

        private bool login;
        public bool Login
        {
            get => login;

            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private bool register;
        public bool Register
        {
            get => register;

            set
            {
                register = value;
                OnPropertyChanged(nameof(Register));
            }
        }
        public SwitchLoginViewCommand SwitchViewCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }

        public EventHandler Authenticated;
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            User = new User();
            SetViewProps();
        }

        public LoginViewModel(int id, string email, string name, string password)
        {
            User.Id = id;
            User.Email = email;
            User.Name = name;
            User.Password = password;

            SetViewProps();
        }

        public LoginViewModel(string email, string name, string password)
        {
            User.Id = 0;
            User.Email = email;
            User.Name = name;
            User.Password = password;

            SetViewProps();
        }

        public LoginViewModel(User user)
        {
            User.Id = user.Id;
            User.Email = user.Email;
            User.Name = user.Name;
            User.Password = user.Password;

            SetViewProps();
        }
        #endregion

        #region View Methods
        public void SetViewProps()
        {
            ShowingLogin = true;
            Login = true;
            Register = false;
            SwitchViewCommand = new SwitchLoginViewCommand(this);
            LoginCommand = new LoginCommand(this);
            SaveCommand = new SaveCommand(this);
        }

        public void SwitchViews()
        {
            ShowingLogin = !ShowingLogin;

            if (ShowingLogin)
            {
                this.Login = true; 
                this.Register = false;
            }
            else
            {
                this.Login = false;
                this.Register = true;
            }
        }

        #endregion

        #region UserMethods

        public string GetLastEmail() => FinanceiroApp.WPF.Properties.Settings.Default.lastEmail;
        public void SetLastEmail(string lastEmail)
        {
            FinanceiroApp.WPF.Properties.Settings.Default.lastEmail = lastEmail;
            FinanceiroApp.WPF.Properties.Settings.Default.Save();
        }

        //TODO: Usar um Validation Helper?? SEPARAR OS 3 CASOS DE VALIDAÇÃO - LOGIN, CADASTRO E EDIÇÃO
        public async Task<bool> IsValid(bool register = false)
        {
            if (string.IsNullOrEmpty(User.Name))
                throw new Library.Exceptions.FinAppValidationException("O nome de usuário é obrigatório.");

            if (string.IsNullOrEmpty(User.Email))
                throw new Library.Exceptions.FinAppValidationException("O email é obrigatório.");

            if (!ValidationHelper.IsValidEmail(User.Email))
                throw new Library.Exceptions.FinAppValidationException("Email inválido.");

            if (string.IsNullOrEmpty(NewPassword))
                throw new Library.Exceptions.FinAppValidationException("A senha é obrigatória.");

            if (ValidationHelper.HasRequiredLength(NewPassword, 6))
                throw new Library.Exceptions.FinAppValidationException("A senha deve ter no mínimo 6 dígitos.");

            if (string.IsNullOrEmpty(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha é obrigatória.");

            if(!NewPassword.Equals(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha deve ser igual à senha.");

            if (!register)
            {
                //TODO: FAZER O CASO DE EDIÇÃO DO USUÁRIO
                if(!await UserDataBaseHelper.ValidatePassword(this.User.Id, NewPassword))
                    throw new Library.Exceptions.FinAppValidationException("A senha atual é inválida.");
            }

            return true;
        }

        public void SetUserPassword(string password) => User.Password = password;

        public User GetUserEntity(bool login = true)
        {
            return new User
            {
                Id = this.User.Id,
                Email = this.User.Email,
                Name = this.User.Name,
                Password = login ? this.NewPassword : PasswordHelper.EncryptPassword(this.NewPassword)
            };
        }

        public override async void Save()
        {
            try
            {
                base.Save();

                await IsValid(true);

                await UserDataBaseHelper.CreateAsync(GetUserEntity(false));

                MessageBox.Show("Usuário salvo com sucesso!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);

                SwitchViews();
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao fazer login!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        public async void UserLogin()
        {
            try
            {
                //await IsValid();
                User user = await UserDataBaseHelper.Login(this.User.Email, this.User.Password);
                App.User = user;

                SetLastEmail(user.Email);
                Authenticated.Invoke(this, new EventArgs());
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao fazer login!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}