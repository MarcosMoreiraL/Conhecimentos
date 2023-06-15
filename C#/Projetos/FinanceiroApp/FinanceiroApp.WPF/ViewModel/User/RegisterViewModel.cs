using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
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
        public EventHandler Saved;
        public string ConfirmPassword { get; set; }
        public BasicFinAppCommand Command { get; set; }

        public RegisterViewModel()
        {
            ResetUser();
            Command = new BasicFinAppCommand(this);
        }

        public void ResetUser () => User = new Entity.Models.User();

        public void SetConfirmPassword(string password) => this.ConfirmPassword = password;

        public override Entity.Models.User GetUserEntity()
        {
            return new Entity.Models.User
            {
                Id = this.User.Id,
                Email = this.User.Email,
                Name = this.User.Name,
                Password = PasswordHelper.EncryptPassword(this.User.Password)
            };
        }

        //TODO: DEIXAR A FUNÇÃO DE VALIDAÇÃO MAIS GENÉRICA E REUTILIZÁVEL USANDO O HELPER
        public override async Task<bool> IsValid()
        {
            if (string.IsNullOrEmpty(User.Name))
                throw new Library.Exceptions.FinAppValidationException("O nome de usuário é obrigatório.");

            if (string.IsNullOrEmpty(User.Email))
                throw new Library.Exceptions.FinAppValidationException("O email é obrigatório.");

            if (!ValidationHelper.IsValidEmail(User.Email))
                throw new Library.Exceptions.FinAppValidationException("Email inválido.");

            if (await UserDataBaseHelper.EmailExists(User.Email))
                throw new Library.Exceptions.FinAppValidationException("Email já cadastrado.");

            if (string.IsNullOrEmpty(User.Password))
                throw new Library.Exceptions.FinAppValidationException("A senha é obrigatória.");

            if (!ValidationHelper.HasRequiredLength(User.Password, 6))
                throw new Library.Exceptions.FinAppValidationException("A senha deve ter no mínimo 6 dígitos.");

            if (string.IsNullOrEmpty(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha é obrigatória.");

            if (!User.Password.Equals(ConfirmPassword))
                throw new Library.Exceptions.FinAppValidationException("A confirmação de senha deve ser igual à senha.");

            return true;
        }

        public override async void Action()
        {
            try
            {
                await IsValid();
                await UserDataBaseHelper.CreateAsync(GetUserEntity());
                MessageBox.Show("Usuário salvo com sucesso!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                ResetUser();
                Saved.Invoke(this, new EventArgs());
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
