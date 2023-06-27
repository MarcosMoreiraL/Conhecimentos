using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel
{
    public class DashboardViewModel : FinAppViewModel
    {
        public FinanceiroApp.Entity.Models.User User { get; set; }

        public DashboardViewModel()
        {
            this.User = App.User;
            OnPropertyChanged(nameof(User));
        }

        public override void Action()
        {
            base.Action();
        }
    }
}
