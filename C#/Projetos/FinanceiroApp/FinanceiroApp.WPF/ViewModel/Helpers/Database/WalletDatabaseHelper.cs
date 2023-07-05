using FinanceiroApp.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Helpers.Database
{
    public class WalletDatabaseHelper : FinAppDataBaseHelper<Wallet>
    {
        public static async Task<ObservableCollection<Wallet>> GeUsertWalletsAsync(int userId)
        {
            ObservableCollection<Wallet> wallets = new ObservableCollection<Wallet>();

            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                foreach (Wallet wallet in context.Wallets.Where(w => w.UserId == userId))
                    wallets.Add(wallet);
            }

            return wallets;
        }
    }
}
