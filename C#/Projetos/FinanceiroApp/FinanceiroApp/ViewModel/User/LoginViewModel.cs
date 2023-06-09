using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers;
using Mysqlx.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.User
{
    public class LoginViewModel : UserViewModel
    {
        public string ConfirmPassword { get; set; }
        public EventHandler Authenticated;

        public string GetLastEmail() => FinanceiroApp.WPF.Properties.Settings.Default.lastEmail;
        public void SetLastEmail(string lastEmail)
        {
            FinanceiroApp.WPF.Properties.Settings.Default.lastEmail = lastEmail;
            FinanceiroApp.WPF.Properties.Settings.Default.Save();
        }

        public override void SetUserPassword(string password) => User.Password = password;
        public override async Task<bool> IsValid(bool register = false)
        {
            return false;
        }

        public override Entity.Models.User GetUserEntity(bool login = true)
        {
            return new Entity.Models.User
            {
                Id = this.User.Id,
                Email = this.User.Email,
                Name = this.User.Name,
                Password = this.NewPassword
            };
        }

        public override async void Action()
        {
            try
            {
                await IsValid();
                Entity.Models.User user = await UserDataBaseHelper.Login(this.User.Email, this.User.Password);
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
    }
}
