using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.Entity.Models
{
    public class TransactionCategory : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Description { get; set; } = string.Empty;

        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public TransactionCategory Clone()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
            
            if (Transactions != null)
                Transactions.ToList().ForEach(t => { transactions.Add(t.Clone()); });

            return new TransactionCategory()
            {
                Id = Id,
                UserId = UserId,
                Description = Description,
                User = User,
                Transactions = transactions
            };
        }
    }
}
