using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroApp.Entity.Models
{
    public class Transaction : IEntity
    {
        public enum TransactionType
        {
            Income,
            Expense
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

        public DateTime DateTime { get; set; }
        public TransactionType Type { get; set; }
        public User User { get; set; }
        public TransactionCategory Category { get; set; }

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
        }

        public Transaction(int id, int userId, decimal value, string description, int categoryId, DateTime dateTime, TransactionType type, User user, TransactionCategory category) : this(id, userId, value, description, categoryId, dateTime, type)
        {
            User = user;
            Category = category;
        }
    }
}
