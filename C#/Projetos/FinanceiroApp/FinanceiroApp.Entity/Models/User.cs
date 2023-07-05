using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Entity.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório!")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório!")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<TransactionCategory> TransactionCategories { get; set; }
        public ObservableCollection<Wallet> Wallets { get; set; }

        public User() { }

        public User(int id, string email, string name, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
            Transactions = new List<Transaction>();
            TransactionCategories = new List<TransactionCategory>();
            Wallets = new ObservableCollection<Wallet>();
        }

        public User(int id, string email, string name, string password, List<Transaction> transactions, List<TransactionCategory> transactionCategories, ObservableCollection<Wallet> wallets) : this(id, email, name, password)
        {
            Transactions = transactions;
            TransactionCategories = transactionCategories;
            Wallets = wallets; 
        }
    }
}
