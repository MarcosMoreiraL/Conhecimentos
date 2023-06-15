using FinanceiroApp.WPF.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Base
{
    //SENHA DO ADMIN = admin@
    public class UserViewModel : FinAppViewModel
    {
        #region Props
        protected Entity.Models.User user;
        public Entity.Models.User User
        {
            get => user;

            set
            {
                if (value is Entity.Models.User)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        protected Helpers.UserControlType type;
        public Helpers.UserControlType Type { get => type; set => type = value; } //TODO: SETAR O TIPO DE CADA UM NO CONSTRUTOR
        #endregion

        public virtual void SetUserPassword(string password) => User.Password = password;
        public virtual async Task<bool> IsValid() => throw new NotImplementedException();
        public virtual Entity.Models.User GetUserEntity() => throw new NotImplementedException();
    }
}
