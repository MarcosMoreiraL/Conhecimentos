using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroApp.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroApp.WPF.ViewModel.Helpers.Database
{
    public class UserDatabaseHelper : FinAppDataBaseHelper<Entity.Models.User>
    {
        public static async Task<bool> EmailExists(string email)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return await context.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public static async Task<bool> UsernameExists(string username)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return await context.Users.AnyAsync(u => u.Name.Equals(username));
        }

        public static async Task<bool> ValidatePassword(int userId, string newPassword)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                Entity.Models.User user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if(user != null)
                {
                    string curPassword = user.Password;

                    if (newPassword != null)
                        return PasswordHelper.DecryptPassword(newPassword, curPassword);

                    throw new Library.Exceptions.FinAppValidationException("Senha inválida");
                }

                throw new Exception("Usuário não encontrado");
            }
        }

        public static async Task<Entity.Models.User> Login(string email, string password)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                if (await context.Users.AnyAsync(u => u.Email.Equals(email)))
                {
                    Entity.Models.User user = await context.Users.Include(u => u.Wallets).Include(u => u.TransactionCategories).Include(u => u.Transactions).FirstOrDefaultAsync(i => i.Email.Equals(email));
                    if (user != null)
                    {
                        if(PasswordHelper.DecryptPassword(password, user.Password))
                            return user;
                    }

                    throw new Library.Exceptions.FinAppValidationException("Senha incorreta!");
                }

                throw new Exception("Usuário não encontrado!");
            }
        }

        public static async Task<Entity.Models.User> GetUserAsync(int id)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                if (await context.Users.AnyAsync(u => u.Id == id))
                    return await context.Users.Include(u => u.Wallets).Include(u => u.TransactionCategories).Include(u => u.Transactions).FirstOrDefaultAsync(u => u.Id == id);
            }

            return null;
        }

        public static async Task<ObservableCollection<TransactionCategory>> GetCategoriesAsync(int userId)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                if (await context.Users.AnyAsync(u => u.Id == userId))
                {
                    ObservableCollection<TransactionCategory> categories = new ObservableCollection<TransactionCategory>();

                    foreach (TransactionCategory category in context.TransactionCategories.Where(c => c.UserId == userId))
                        categories.Add(category);

                    return categories;
                }
            }

            return null;
        }

        public static async Task<ObservableCollection<Wallet>> GetWalletsAsync(int userId)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                if (await context.Wallets.AnyAsync(w => w.UserId == userId))
                {
                    ObservableCollection<Wallet> wallets = new ObservableCollection<Wallet>();

                    foreach (Wallet wallet in context.Wallets.Where(w => w.UserId == userId))
                        wallets.Add(wallet);

                    return wallets;
                }
            }

            return null;
        }

        public static async Task<ObservableCollection<Transaction>> GetTransactionsAsync(int userId)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                if (await context.Transactions.AnyAsync(t => t.UserId == userId))
                {
                    ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

                    foreach (Transaction transaction in context.Transactions.Where(t => t.UserId == userId))
                        transactions.Add(transaction);

                    return transactions;
                }
            }

            return null;
        }
    }
}
