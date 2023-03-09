using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroApp.Entity.Models;

namespace FinanceiroApp.Entity
{
    public class FinanceiroAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }

        public FinanceiroAppDbContext(DbContextOptions options) : base(options) { }
    }
}
