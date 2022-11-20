using DevTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.EntityFramework
{
    public class CRUDProdutosDbContext : DbContext
    {
        public DbSet<Produto> produto { get; set; }
        public DbSet<Produto_Grupo> produto_grupo { get; set; }
        public DbSet<Venda> venda { get; set; }
        public DbSet<Venda_Produto> venda_produto { get; set; }

        public CRUDProdutosDbContext(DbContextOptions options) : base(options) { }
    }
}
