using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Entity.Models
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<TransactionCategory> Categories { get; set; }

        public User() { }

        public User(int id, string email, string name, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
            Transactions = new List<Transaction>();
            Categories = new List<TransactionCategory>();
        }

        public User(int id, string email, string name, string password, List<Transaction> transactions, List<TransactionCategory> categories) : this(id, email, name, password)
        {
            Transactions = transactions;
            Categories = categories;
        }
    }
}
