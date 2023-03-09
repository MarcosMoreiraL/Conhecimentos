using System;
using System.ComponentModel;
using System.Linq;
using FinanceiroApp.Entity.Models;

namespace FinanceiroApp.Library.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        //TODO: COLOCAR OS OBJETOS DE TRANSACTIONS E CATEGORIES

        public UserViewModel() { }

        public UserViewModel(int id, string email, string name, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
        }

        public UserViewModel(string email, string name, string password)
        {
            Id = 0;
            Email = email;
            Name = name;
            Password = password;
        }

        public UserViewModel(Entity.Models.User user)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.Name;
            Password = user.Password;
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
                string curPassword = context.Users.FirstOrDefault(i => i.Id == this.Id).Password;

                if(password != null)
                {
                    if (!Library.Tools.PasswordSecurity.DecryptPassword(password, curPassword))
                        throw new Library.Exceptions.FinAppValidationException("A senha digitada não confere com a senha atual");
                }
            }
        }

        public bool UserExists(string username)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
                return context.Users.Any(i => i.Name.Equals(username));
        }

        public UserViewModel GetUser(int id)
        {
            using(Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if (context.Users.Any(i => i.Id == id))
                    return new UserViewModel(context.Users.FirstOrDefault(i => i.Id == id));
                else
                    return null;
            }
        }

        public static UserViewModel GetUser(string username, string password)
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if (context.Users.Any(i => i.Name.Equals(username)))
                {
                    Entity.Models.User user = context.Users.FirstOrDefault(i => i.Name.Equals(username));

                    if (Library.Tools.PasswordSecurity.DecryptPassword(password, user.Password))
                        return new UserViewModel(user);
                    else
                        throw new Exception("Senha incorreta!");
                }
                else
                    throw new Exception("Usuário não encontrado!");
            }
        }

        public User GetUserEntity()
        {
            return new User
            {
                Id = this.Id,
                Email = this.Email,
                Name = this.Name,
                Password = this.Password
            };
        }

        public User GetUserRegister()
        {
            return new User
            {
                Id = this.Id,
                Email = this.Email,
                Name = this.Name,
                Password = Library.Tools.PasswordSecurity.EncryptPassword(this.Password)
            };
        }

        public void SaveUser()
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if(this.Id == 0)
                    context.Users.Add(GetUserRegister());
                else
                {
                    User u = context.Users.FirstOrDefault(i => i.Id == this.Id);

                    if(u != null)
                    {
                        u.Email = this.Email;
                        u.Name = this.Name;
                        u.Password = Library.Tools.PasswordSecurity.EncryptPassword(this.Password);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}