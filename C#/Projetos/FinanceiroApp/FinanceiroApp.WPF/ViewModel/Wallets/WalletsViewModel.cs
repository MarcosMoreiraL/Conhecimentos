using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using FinanceiroApp.WPF.Views.Wallets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletsViewModel : FinAppViewModel
    {
        public FinanceiroApp.Entity.Models.User User { get; set; }
        public ObservableCollection<WalletItem> Wallets { get; set; } = new ObservableCollection<WalletItem>();

        public EventHandler Updated;
        public EventHandler WalletSelected;

        public WalletsViewModel()
        {
            Wallets = new ObservableCollection<WalletItem>();
            User = App.User;
            Updated += UpdateView;
            UpdateWallets();
        }

        public async void UpdateUser()
        {
            try
            {
                this.User = await App.UpdateUser();
                OnPropertyChanged(nameof(User));

                UpdateWallets();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar carteira!", "WalletsViewModel", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateWallets()
        {
            //Wallets.Clear();

            //Wallets.Add(new WalletItem()
            //{
            //    Id = 0,
            //    Description = "Todas",
            //    Wallet = new Entity.Models.Wallet()
            //    {
            //        Id = 0,
            //        Description = "Todas"
            //    },
            //    WalletSelected = WalletSelected
            //});

            //foreach (Wallet wallet in User.Wallets)
            //{
            //    Wallets.Add(new WalletItem()
            //    {
            //        Id = wallet.Id,
            //        Wallet = wallet,
            //        Description = wallet.Description,
            //        Updated = Updated,
            //        WalletSelected = WalletSelected
            //    });
            //}

            //OnPropertyChanged(nameof(Wallets));
        }

        public void UpdateView(object sender, EventArgs e) => UpdateUser();

        public override void Action()
        {
            base.Action();
        }
    }
}
