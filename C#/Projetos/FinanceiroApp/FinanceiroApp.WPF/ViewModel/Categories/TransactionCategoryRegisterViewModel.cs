using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;

namespace FinanceiroApp.WPF.ViewModel.Categories
{
    public class TransactionCategoryRegisterViewModel : FinAppViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } =  string.Empty;
        public Entity.Models.User User { get; set; }
        
        public BasicFinAppCommand Command { get; set; }
        public EventHandler Updated;

        public TransactionCategoryRegisterViewModel()
        {
            this.User = App.User;
            Command = new BasicFinAppCommand(this);
        }

        public TransactionCategoryRegisterViewModel(int id, int userId, string description)
        {
            Id = id;
            Description = description;
            this.User = App.User;
            Command = new BasicFinAppCommand(this);
        }

        public TransactionCategoryRegisterViewModel(TransactionCategory transactionCategory)
        {
            Id = transactionCategory.Id;
            Description = transactionCategory.Description;
            User = transactionCategory.User;
            Command = new BasicFinAppCommand(this);
        }

        public void SetCategory(TransactionCategory category)
        {
            this.Id = category.Id;
            this.Description = category.Description;

            OnPropertyChanged(nameof(Description));
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

        public List<Transaction> GetTransactions() //TODO: MOVER ESSE MÉTODO PARA O DATABASE HELPER DAS TRANSACTIONS
        {
            using (Entity.FinanceiroAppDbContext context = App.DbContextFactory.Create())
                return context.Transactions.Where(i => i.CategoryId == Id).ToList();
        }

        public override async void Action()
        {
            try
            {
                if (Id == 0)
                    await TransactionCategoryDatabaseHelper.CreateAsync(GetEntity());
                else
                    await TransactionCategoryDatabaseHelper.UpdateAsync(GetEntity());

                MessageBox.Show("Categoria salva com sucesso!", "Categoria", MessageBoxButton.OK, MessageBoxImage.Information);

                Updated.Invoke(this, new EventArgs());
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
