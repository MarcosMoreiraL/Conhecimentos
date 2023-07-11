using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.Controls.Dashboard;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Categories
{
    public class TransactionCategoriesViewModel : FinAppViewModel, INotifyPropertyChanged
    {
        public Entity.Models.User User { get; set; }
        public ObservableCollection<TransactionCategory> Categories { get; set; } = new ObservableCollection<TransactionCategory>();

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public TransactionCategoriesViewModel()
        {
            User = App.User;
            Categories = User.TransactionCategories;
        }

        public async void UpdateUser()
        {
            App.SetUser(await UserDatabaseHelper.GetUserAsync(App.User.Id));
            this.User = App.User;
            OnPropertyChanged(nameof(User));

            UpdateCategories();
        }

        public void UpdateCategories()
        {
            Categories.Clear();

            foreach (var category in User.TransactionCategories)
            {
                Categories.Add(new TransactionCategory()
                {
                    Id = category.Id,
                    Description = category.Description,
                    UserId = category.UserId
                });
            }

            OnPropertyChanged(nameof(Categories));
        }

        public async void DeleteCategory(int id)
        {
            try
            {
                //TODO: FAZER O CASO DE TER TRANSAÇÕES NA CATEGORIA
                await TransactionCategoryDatabaseHelper.DeleteAsync(id);
                MessageBox.Show("Categoria apagada com sucesso!", "Categorias", MessageBoxButton.OK, MessageBoxImage.Information);

                UpdateUser();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao apagar a categoria!", "Categorias", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
