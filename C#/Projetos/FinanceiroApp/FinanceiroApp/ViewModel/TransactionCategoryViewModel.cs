using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceiroApp.Entity.Models;

namespace FinanceiroApp.WPF.ViewModels
{
    public class TransactionCategoryViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get;set; }
        public string Description { get; set; }
        
        public User user { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public TransactionCategoryViewModel() { }
        public TransactionCategoryViewModel(int id, int userId, string description)
        {
            Id = id;
            UserId = userId;
            Description = description;
        }

        public TransactionCategoryViewModel(TransactionCategory transactionCategory)
        {
            this.Id = transactionCategory.Id;
            this.UserId = transactionCategory.UserId;
            this.Description = transactionCategory.Description;
            this.user = transactionCategory.User;
        }

        private TransactionCategory GetEntity()
        {
            return new TransactionCategory()
            {
                Id = Id,
                UserId = UserId,
                Description = Description
            };
        }

        public List<Transaction> GetTransactions()
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
                return context.Transactions.Where(i => i.CategoryId == Id).ToList();
        }

        public void SaveCategory()
        {
            using (Entity.FinanceiroAppDbContext context = Library.Session.DbContextFactory.Create())
            {
                if (this.Id == 0)
                    context.TransactionCategories.Add(GetEntity());
                else
                {
                    TransactionCategory transactionCategory = context.TransactionCategories.FirstOrDefault(i => i.Id == this.Id);

                    if (transactionCategory != null)
                    {
                        transactionCategory.Description = Description;
                        transactionCategory.UserId = UserId;
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
