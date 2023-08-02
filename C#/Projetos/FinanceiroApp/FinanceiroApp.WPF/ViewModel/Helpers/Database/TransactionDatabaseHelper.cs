using FinanceiroApp.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Helpers.Database
{
    public class TransactionDatabaseHelper : FinAppDataBaseHelper<Entity.Models.Transaction>
    {
        public static async Task<IEnumerable<Transaction>> GetByWalletIdAsync(int userId, int walletId)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return context.Transactions.Include(t => t.User).Include(t => t.Category).Where(t => t.WalletId == walletId && t.UserId == userId).ToList();
        }

        public static async Task<IEnumerable<Transaction>> GetByUserAsync(int userId)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return context.Transactions.Include(t => t.User).Include(t => t.Category).Where(t => t.UserId == userId).ToList();
        }
    }
}