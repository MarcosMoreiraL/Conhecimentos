using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.User
{
    public class UpdateUserViewModel : UserViewModel
    {
        private bool _updateUserInfo = false;
        public bool UpdateUserInfo
        {
            get => _updateUserInfo;

            set
            {
                _updateUserInfo = value;
                OnPropertyChanged(nameof(UpdateUserInfo));
            }
        }
        public string OldPassword { get; set; }
        public BasicFinAppCommand Command { get; set; }
        public EventHandler Updated;

        public UpdateUserViewModel()
        {
            this.OldPassword = string.Empty;
            this.Command = new BasicFinAppCommand(this);
            this.User = App.CloneUser() ?? new Entity.Models.User();
        }

        public void SetLastEmail(string lastEmail)
        {
            FinanceiroApp.WPF.Properties.Settings.Default.lastEmail = lastEmail;
            FinanceiroApp.WPF.Properties.Settings.Default.Save();
        }

        public override void SetUserPassword(string password) => base.SetUserPassword(password);

        public void SetOldPassword(string password) => OldPassword = password;

        public void ResetUser() => this.User = App.CloneUser() ?? new Entity.Models.User();

        public override async Task<bool> IsValid()
        {
            if (string.IsNullOrEmpty(User.Name)) //TODO: BOTÃO DE DESFAZER ALTERAÇÕES
                throw new Library.Exceptions.FinAppValidationException("O nome de usuário é obrigatório.");

            if (UpdateUserInfo)
            {
                if (string.IsNullOrEmpty(User.Email))
                    throw new Library.Exceptions.FinAppValidationException("O email é obrigatório.");

                if (!ValidationHelper.IsValidEmail(User.Email))
                    throw new Library.Exceptions.FinAppValidationException("Email inválido.");

                if (string.IsNullOrEmpty(OldPassword))
                    throw new Library.Exceptions.FinAppValidationException("A senha atual é obrigatória.");

                if (!await UserDataBaseHelper.ValidatePassword(this.User.Id, OldPassword))
                    throw new Library.Exceptions.FinAppValidationException("A senha atual é inválida.");

                if (string.IsNullOrEmpty(this.User.Password))
                    throw new Library.Exceptions.FinAppValidationException("A nova senha é obrigatória.");

                if (!ValidationHelper.HasRequiredLength(this.User.Password, 6))
                    throw new Library.Exceptions.FinAppValidationException("A nova senha deve ter no mínimo 6 dígitos.");

                if (await UserDataBaseHelper.ValidatePassword(this.User.Id, this.User.Password))
                    throw new Library.Exceptions.FinAppValidationException("A nova senha deve ser diferente da atual.");
            }

            return true;
        }

        public override Entity.Models.User GetUserEntity()
        {
            return UpdateUserInfo ?

            new Entity.Models.User()
            {
                Id = this.User.Id,
                Email = this.User.Email,
                Name = this.User.Name,
                Password = PasswordHelper.EncryptPassword(this.User.Password)
            }

            :

            new Entity.Models.User()
            {
                Id = App.User.Id,
                Email = App.User.Email,
                Name = this.User.Name,
                Password = App.User.Password
            };
        }

        public override async void Action()
        {
            try
            {
                await IsValid();
                await UserDataBaseHelper.UpdateAsync(GetUserEntity());
                MessageBox.Show("Usuário salvo com sucesso!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                Updated.Invoke(this, new EventArgs());

                App.User = user;
                SetLastEmail(user.Email);

                Updated.Invoke(this, new EventArgs());
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "UpdateUser", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar as alterações!", "Editar Usuário", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
