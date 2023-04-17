using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.Library.Helpers;
using FinanceiroApp.WPF.Converter;
using FinanceiroApp.WPF.ViewModel.Commands;

namespace FinanceiroApp.WPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
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
        //TODO: Colocar bool para diferenciar edição de usuário novo

        public SwitchLoginViewCommand SwitchViewCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            //TODO: agrupar num método a inicialização das props da tela
            ShowingLogin = true;
            Login = true;
            Register = false;
            SwitchViewCommand = new SwitchLoginViewCommand(this);
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }

        public LoginViewModel(int id, string email, string name, string password)
        {
            User.Id = id;
            User.Email = email;
            User.Name = name;
            User.Password = password;

            ShowingLogin = true;
            Login = true;
            Register = false;
            SwitchViewCommand = new SwitchLoginViewCommand(this);
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }

        public LoginViewModel(string email, string name, string password)
        {
            User.Id = 0;
            User.Email = email;
            User.Name = name;
            User.Password = password;

            ShowingLogin = true;
            Login = true;
            Register = false;
            SwitchViewCommand = new SwitchLoginViewCommand(this);
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }

        public LoginViewModel(Entity.Models.User user)
        {
            User.Id = user.Id;
            User.Email = user.Email;
            User.Name = user.Name;
            User.Password = user.Password;

            ShowingLogin = true;
            Login = true;
            Register = false;
            SwitchViewCommand = new SwitchLoginViewCommand(this);
            LoginCommand = new LoginCommand(this);
            RegisterCommand = new RegisterCommand(this);
        }
        #endregion
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region View Methods
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
        public bool IsValid(bool register = false)
        {
            if (string.IsNullOrEmpty(User.Name))
                throw new Library.Exceptions.FinAppValidationException("O nome de usuário é obrigatório.");

            if (string.IsNullOrEmpty(User.Email))
                throw new Library.Exceptions.FinAppValidationException("O email é obrigatório.");

            if (!ValidationHelper.IsValidEmail(User.Email))
                throw new Library.Exceptions.FinAppValidationException("Email inválido.");

            if (string.IsNullOrEmpty(User.Password))
                throw new Library.Exceptions.FinAppValidationException("A senha é obrigatória.");

            if (ValidationHelper.HasRequiredLength(User.Password, 6))
                throw new Library.Exceptions.FinAppValidationException("A senha deve ter no mínimo 6 dígitos.");

            if (string.IsNullOrEmpty(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha é obrigatória.");

            if(!User.Password.Equals(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha deve ser igual à senha.");

            return true;
        }

        public bool UserExists(int userId)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
                return context.Users.Any(i => i.Id == userId);
        }

        public void ValidatePassword(string password)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                string curPassword = context.Users.FirstOrDefault(i => i.Id == this.User.Id).Password;

                if(password != null)
                {
                    if (!PasswordHelper.DecryptPassword(password, curPassword))
                        throw new Library.Exceptions.FinAppValidationException("A senha digitada não confere com a senha atual");
                }
            }
        }

        public bool UserExists(string username)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
                return context.Users.Any(i => i.Name.Equals(username));
        }

        public LoginViewModel GetUser(int id)
        {
            using(Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if (context.Users.Any(i => i.Id == id))
                    return new LoginViewModel(context.Users.FirstOrDefault(i => i.Id == id));
                
                return null;
            }
        }

        public static LoginViewModel GetUser(string username, string password)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if (context.Users.Any(i => i.Name.Equals(username)))
                {
                    Entity.Models.User user = context.Users.FirstOrDefault(i => i.Name.Equals(username));

                    if (PasswordHelper.DecryptPassword(password, user.Password))
                        return new LoginViewModel(user);
                    
                    throw new Exception("Senha incorreta!");
                }
                
                throw new Exception("Usuário não encontrado!");
            }
        }

        public User GetUserRegister()
        {
            return new User
            {
                Id = this.User.Id,
                Email = this.User.Email,
                Name = this.User.Name,
                Password = PasswordHelper.EncryptPassword(this.User.Password)
            };
        }

        public void SaveUser()
        {
            IsValid();

            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if(this.User.Id == 0)
                    context.Users.Add(GetUserRegister()); //AQUI EU USO O MÉTODO POR CAUSA DA SENHA CRIPTOGRAFADA, PARA NÃO TER QUE GERAR NO this.User O TEMPO TODO
                else
                {
                    User u = context.Users.FirstOrDefault(i => i.Id == this.User.Id);

                    if(u != null)
                    {
                        u.Email = this.User.Email;
                        u.Name = this.User.Name;
                        u.Password = PasswordHelper.EncryptPassword(this.User.Password);
                    }
                }

                context.SaveChanges();
            }
        }

        public void UserLogin()
        {
            try
            {
                IsValid();

                
            }
            catch (FinAppValidationException rvex)
            {

            }
            catch (Exception ex)
            {
                //TODO: Incluir o log
                MessageBox.Show("Erro ao fazer login!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}