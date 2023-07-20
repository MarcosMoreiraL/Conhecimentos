using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FinanceiroApp.Entity;
using System.Collections.ObjectModel;
using FinanceiroApp.Entity.Models;

namespace FinanceiroApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static FinanceiroAppDbContextFactory _dbcontextFactory;
        public static FinanceiroAppDbContextFactory DbContextFactory => _dbcontextFactory;

        private static Entity.Models.User _user;
        public static Entity.Models.User User
        {
            get => _user;

            private set
            {
                _user = value;
            }
        }

        public static void SetUser(Entity.Models.User user)
        {
            User = user;
        }

        public static Entity.Models.User CloneUser() => _user.Clone();

        public App()
        {
            InitDataBase();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void InitDataBase()
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
