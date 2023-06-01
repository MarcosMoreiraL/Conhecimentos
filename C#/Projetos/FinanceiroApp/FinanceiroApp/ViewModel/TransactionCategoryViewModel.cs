using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;

namespace FinanceiroApp.WPF.ViewModel
{
    public class TransactionCategoryViewModel : FinAppViewModel, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int UserId { get;set; }
        public string Description { get; set; }
        
        public User user { get; set; }
        public SaveCommand SaveCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        public TransactionCategoryViewModel()
        {
            SaveCommand = new SaveCommand(this);
        }

        public TransactionCategoryViewModel(int id, int userId, string description)
        {
            Id = id;
            UserId = userId;
            Description = description;
            SaveCommand = new SaveCommand(this);
        }

        public TransactionCategoryViewModel(TransactionCategory transactionCategory)
        {
            this.Id = transactionCategory.Id;
            this.UserId = transactionCategory.UserId;
            this.Description = transactionCategory.Description;
            this.user = transactionCategory.User;
            SaveCommand = new SaveCommand(this);
        }

        private TransactionCategory GetEntity()
        {
            return new TransactionCategory()
            {
                Id = Id,
                UserId = App.User.Id,
                Description = Description
            };
        }

        public List<Transaction> GetTransactions() //TODO: MOVER ESSE MÉTODO PARA O VIEWMODEL DAS TRANSACTIONS
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return context.Transactions.Where(i => i.CategoryId == Id).ToList();
        }

        public override void Save()
        {
            base.Save();

            try
            {
                using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                {
                    if (this.Id == 0)
                        context.TransactionCategories.Add(GetEntity());
                    else
                    {
                        TransactionCategory transactionCategory = context.TransactionCategories.FirstOrDefault(i => i.Id == this.Id);

                        if (transactionCategory != null)
                        {
                            transactionCategory.Description = Description;
                            transactionCategory.UserId = App.User.Id;
                        }
                    }

                    context.SaveChanges();
                }

                MessageBox.Show("Categoria salva com sucesso!", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar categoria!", "Categoria", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
