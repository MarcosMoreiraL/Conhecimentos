using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.EntityFramework
{
    public class CRUDProdutosDbContextFactory : IDesignTimeDbContextFactory<CRUDProdutosDbContext>
    {
        public CRUDProdutosDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<CRUDProdutosDbContext>();

            options.UseMySQL("Server=localhost;User=root;Password=aWx@2325Hkp;Database=testdev;");

            return new CRUDProdutosDbContext(options.Options);
        }
    }
}
