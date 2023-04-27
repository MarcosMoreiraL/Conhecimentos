using System;
using System.Collections.Generic;
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
    }
}
