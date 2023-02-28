using System.ComponentModel;
using System.Linq;

namespace FinanceiroApp.WPF.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

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

        public Entity.Models.User GetUserEntity()
        {
            return new Entity.Models.User
            {
                Id = this.Id,
                Email = this.Email,
                Name = this.Name,
                Password = this.Password
            };
        }

        public void SaveUser()
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                context.Users.Add(GetUserEntity());
                context.SaveChanges();
            }
        }
    }
}