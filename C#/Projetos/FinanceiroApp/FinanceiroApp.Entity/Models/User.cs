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

        public ObservableCollection<Transaction> Transactions { get; set; }
        public ObservableCollection<TransactionCategory> TransactionCategories { get; set; }
        public ObservableCollection<Wallet> Wallets { get; set; }

        public User() { }

        public User(int id, string email, string name, string password)
        {
            Id = id;
            Email = email;
            Name = name;
            Password = password;
            Transactions = new ObservableCollection<Transaction>();
            TransactionCategories = new ObservableCollection<TransactionCategory>();
            Wallets = new ObservableCollection<Wallet>();
        }

        public User(int id, string email, string name, string password, ObservableCollection<Transaction> transactions, ObservableCollection<TransactionCategory> transactionCategories, ObservableCollection<Wallet> wallets) : this(id, email, name, password)
        {
            Transactions = transactions;
            TransactionCategories = transactionCategories;
            Wallets = wallets; 
        }

        public User Clone()
        {
            ObservableCollection<Wallet> wallets = new ObservableCollection<Wallet>();
            ObservableCollection<TransactionCategory> transactionCategories = new ObservableCollection<TransactionCategory>();
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

            Wallets.ToList().ForEach(w => { wallets.Add(w.Clone()); });
            TransactionCategories.ToList().ForEach(tc => { transactionCategories.Add(tc.Clone()); });

            if (Transactions != null)
                Transactions.ToList().ForEach(t => { transactions.Add(t.Clone()); });

            return new User()
            {
                Id = Id,
                Name = Name,
                Email = Email,
                Password = Password,
                Wallets = wallets,
                TransactionCategories = transactionCategories,
                Transactions = transactions
            };
        }
    }
}
