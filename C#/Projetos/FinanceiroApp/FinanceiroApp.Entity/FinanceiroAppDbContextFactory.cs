using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Entity
{
    public class FinanceiroAppDbContextFactory
    {
        private readonly DbContextOptions _options;

        public FinanceiroAppDbContextFactory(DbContextOptions options)
        {
            this._options = options;
        }

        public FinanceiroAppDbContext Create() => new FinanceiroAppDbContext(_options);
    }
}
