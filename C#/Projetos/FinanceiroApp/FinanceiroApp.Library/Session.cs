using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroApp.Library
{
    public static class Session
    {
        private static FinanceiroAppDbContextFactory _dbcontextFactory;
        public static FinanceiroAppDbContextFactory DbContextFactory => _dbcontextFactory;
        public static Entity.Models.User User { get; set; } = null;
        public static void InitSession()
        {
            string connectionString = "Server=localhost;Port=3306;Database=financeiroApp;Uid=root;Pwd=123456;";
            _dbcontextFactory = new FinanceiroAppDbContextFactory(new DbContextOptionsBuilder().UseMySQL(connectionString).Options);

            using (FinanceiroAppDbContext context = _dbcontextFactory.Create())
            {
                context.Database.Migrate();
            }
        }
    }
}
