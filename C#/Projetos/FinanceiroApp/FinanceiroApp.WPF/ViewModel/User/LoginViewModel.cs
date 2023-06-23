using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers;
using Microsoft.Win32;
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
        public EventHandler Authenticated;
        public Command.BasicFinAppCommand Command { get; set; }

        public LoginViewModel()
        {
            User = new Entity.Models.User();
            Command = new BasicFinAppCommand(this);
            User.Email = GetLastEmail();
        }

        public string GetLastEmail() => FinanceiroApp.WPF.Properties.Settings.Default.lastEmail;

        public void SetLastEmail(string lastEmail)
        {
            FinanceiroApp.WPF.Properties.Settings.Default.lastEmail = lastEmail;
            FinanceiroApp.WPF.Properties.Settings.Default.Save();
        }

        public bool Validation()
        {
            if (string.IsNullOrEmpty(User.Email))
                throw new Library.Exceptions.FinAppValidationException("O email é obrigatório.");

            if (!ValidationHelper.IsValidEmail(User.Email))
                throw new Library.Exceptions.FinAppValidationException("Email inválido.");

            if (string.IsNullOrEmpty(this.User.Password))
                throw new Library.Exceptions.FinAppValidationException("A senha é obrigatória.");

            return true;
        }

        public override async void Action()
        {
            try
            {
                Validation();
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
