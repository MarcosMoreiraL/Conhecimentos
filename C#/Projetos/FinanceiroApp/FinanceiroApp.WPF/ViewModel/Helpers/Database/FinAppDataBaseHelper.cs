using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Helpers
{
    public class FinAppDataBaseHelper<TEntity> where TEntity : class, IEntity
    {
        public static async Task CreateAsync(TEntity entity)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public static IQueryable<TEntity> GetAllAsync()
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return context.Set<TEntity>().AsNoTracking();
        }

        public static async Task<bool> ExistsIdAsync(int id)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return await context.Set<TEntity>().AnyAsync(i => i.Id == id);
        }

        public static async Task<TEntity> GetByIdAsync(int id)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return await context.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public static async Task UpdateAsync(TEntity entity)
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
