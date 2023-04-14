using System;
using System.ComponentModel;
using System.Linq;
using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Helpers;

namespace FinanceiroApp.Library.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Props
        private User user;
        public User User { get { return user; } }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructors
        public LoginViewModel() { }

        public LoginViewModel(int id, string email, string name, string password)
        {
            User.Id = id;
            User.Email = email;
            User.Name = name;
            User.Password = password;
        }

        public LoginViewModel(string email, string name, string password)
        {
            User.Id = 0;
            User.Email = email;
            User.Name = name;
            User.Password = password;
        }

        public LoginViewModel(Entity.Models.User user)
        {
            User.Id = user.Id;
            User.Email = user.Email;
            User.Name = user.Name;
            User.Password = user.Password;
        }
        #endregion
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsValid()
        {
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
                else
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
                    else
                        throw new Exception("Senha incorreta!");
                }
                else
                    throw new Exception("Usuário não encontrado!");
            }
        }

        public User GetUserRegister()
        {
            return new User
            {
                Id = this.User.Id,
                Email = this.Email,
                Name = this.Name,
                Password = PasswordHelper.EncryptPassword(this.Password)
            };
        }

        public void SaveUser()
        {
            //TODO: Validar o usuário antes de salvar

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
    }
}