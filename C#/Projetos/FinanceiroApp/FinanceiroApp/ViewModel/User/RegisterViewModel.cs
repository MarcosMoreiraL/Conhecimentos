using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.User
{
    public class RegisterViewModel : UserViewModel
    {
        public string ConfirmPassword { get; set; }
        public EventHandler Updated;

        public void SetLastEmail(string lastEmail)
        {
            FinanceiroApp.WPF.Properties.Settings.Default.lastEmail = lastEmail;
            FinanceiroApp.WPF.Properties.Settings.Default.Save();
        }

        public override void SetUserPassword(string password)
        {
            base.SetUserPassword(password);
        }

        public override Entity.Models.User GetUserEntity(bool login = true)
        {
            return base.GetUserEntity(login);
        }

        public override Task<bool> IsValid(bool register = false)
        {
            return base.IsValid(register);
        }

        public override async void Action()
        {
            try
            {
                await IsValid(true);
                if (User.Id == 0)
                {
                    await UserDataBaseHelper.CreateAsync(GetUserEntity(false));
                    MessageBox.Show("Usuário salvo com sucesso!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    await UserDataBaseHelper.UpdateAsync(GetUserEntity(false));
                    MessageBox.Show("Usuário salvo com sucesso!", "Login", MessageBoxButton.OK, MessageBoxImage.Information); //TODO: unificar a mensagem
                    Updated.Invoke(this, new EventArgs());

                    App.User = User;
                    SetLastEmail(User.Email);
                }
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
