using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.Controls.Dashboard;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel
{
    public class DashboardViewModel : FinAppViewModel
    {
        public FinanceiroApp.Entity.Models.User User { get; set; }
        public ObservableCollection<WalletItem> Wallets { get; set; } = new ObservableCollection<WalletItem>();
        public EventHandler Updated;

        public DashboardViewModel()
        {
            this.User = App.User;
            Updated += UpdateView;
            UpdateWallets();
        }

        public void UpdateWallets()
        {
            Wallets.Clear();

            foreach (var wallet in User.Wallets)
            {
                Wallets.Add(new WalletItem()
                {
                    Id = wallet.Id,
                    Wallet = wallet,
                    Description = wallet.Description,
                    Updated = Updated
                });
            }

            OnPropertyChanged(nameof(Wallets));
        }

        public void UpdateView(object sender, EventArgs e) => UpdateUser();

        public async void UpdateUser()
        {
            try
            {
                App.SetUser(await UserDatabaseHelper.GetUserAsync(App.User.Id));
                this.User = App.User;
                OnPropertyChanged(nameof(User));

                UpdateWallets();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar categoria!", "DashboardViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void Action()
        {
            base.Action();
        }
    }
}
