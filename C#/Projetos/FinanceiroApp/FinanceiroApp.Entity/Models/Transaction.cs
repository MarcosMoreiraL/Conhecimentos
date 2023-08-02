using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroApp.Entity.Models
{
    public class Transaction : IEntity
    {
        public enum TransactionType
        {
            Income = 1,
            Expense = -1
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        [ForeignKey("TransactionCategory")]
        public int CategoryId { get; set; }

        [ForeignKey("Wallet")]
        public int WalletId { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public TransactionType Type { get; set; }
        public User User { get; set; }
        public TransactionCategory Category { get; set; }
        public Wallet Wallet { get; set; }

        public string DateString => DateTime.Now.ToShortDateString();

        public Transaction() { }

        public Transaction(int id, int userId, decimal value, string description, int categoryId, DateTime dateTime, TransactionType type)
        {
            Id = id;
            UserId = userId;
            Value = value;
            Description = description;
            CategoryId = categoryId;
            DateTime = dateTime;
            Type = type;
            User = new User();
            Category = new TransactionCategory();
            Wallet = new Wallet();
        }

        public Transaction(int id, int userId, decimal value, string description, int categoryId, DateTime dateTime, TransactionType type, User user, TransactionCategory category, Wallet wallet) : this(id, userId, value, description, categoryId, dateTime, type)
        {
            User = user;
            Category = category;
            Wallet = wallet;
        }

        public Transaction Clone()
        {
            return new Transaction()
            {
                Id = Id,
                UserId = UserId,
                Value = Value,
                Description = Description,
                CategoryId = CategoryId,
                WalletId = WalletId,
                DateTime = DateTime,
                Type = Type,
                User = User,
                Category = Category,
                Wallet = Wallet
            };
        }
    }
}
