using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.User
{
    public class UpdateUserViewModel : UserViewModel
    {
        public string OldPassword { get; set; }
        public BasicFinAppCommand Command { get; set; }
        public EventHandler Updated;

        public UpdateUserViewModel()
        {
            this.OldPassword = string.Empty;
            this.Command = new BasicFinAppCommand(this);
            this.User = App.User ?? new Entity.Models.User();
            this.User = App.User ?? new Entity.Models.User();
        }

        public override void SetUserPassword(string password)
        {
            base.SetUserPassword(password);
        }

        public void SetOldPassword(string password)
        {
            OldPassword = password;
        }

        public override async Task<bool> IsValid()
        {
            return false;
        }

        public override Entity.Models.User GetUserEntity()
        {
            return base.GetUserEntity();
        }

        public override void Action()
        {
            base.Action();

            Updated.Invoke(null, new EventArgs());
        }
    }
}
