using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Entity
{
    public class FinanceiroAppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinanceiroAppDbContext>
    {
        public FinanceiroAppDbContext CreateDbContext(string[] args = null)
        {
            return new FinanceiroAppDbContext(new DbContextOptionsBuilder().UseMySQL("Server=localhost;Port=3306;Database=financeiroApp;Uid=root;Pwd=123456;").Options);
        }
    }
}
