using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel;
using FinanceiroApp.WPF.ViewModel.Helpers;
using FinanceiroApp.WPF.ViewModel.Categories;
using FinanceiroApp.WPF.Views.Transactions;
using FinanceiroApp.WPF.Views.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinanceiroApp.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public DashboardViewModel ViewModel { get; set; }

        public Dashboard()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as DashboardViewModel ?? new DashboardViewModel();
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            Controls.User.UpdateUserWindow updateUserWindow = new Controls.User.UpdateUserWindow();
            updateUserWindow.ShowDialog();

            ViewModel.UpdateUser();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories categories = new Categories.TransactionCategories();
            categories.ShowDialog();
        }

        private void categoryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Categories.TransactionCategories tc = new Categories.TransactionCategories();
            tc.ShowDialog();
        }

        private void btnNewWallet_Click(object sender, RoutedEventArgs e)
        {
            WalletRegister wr = new WalletRegister(ViewModel.Updated);
            wr.ShowDialog();
        }

        private void btnNewTransaction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ViewModel.User.Wallets.Any())
                    throw new FinanceiroApp.Library.Exceptions.FinAppValidationException("Não é possível criar uma movimentação para um usuário sem carteiras!");

                if (!ViewModel.User.TransactionCategories.Any())
                    throw new FinanceiroApp.Library.Exceptions.FinAppValidationException("Não é possível criar uma movimentação para um usuário sem categorias!");

                TransactionRegister tr = new TransactionRegister(ViewModel.Updated);
                tr.ShowDialog();
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Dashboard", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao carregar a movimentação!", "Dashboard", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cbOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox)?.SelectedValue != null && ViewModel != null)
            {
                string orderType = ((sender as ComboBox)?.SelectedValue as ComboBoxItem).Tag.ToString() ?? "None";

                switch (orderType)
                {
                    case "MinValue":
                        ViewModel.UpdateTransactionFilters(Filter.FilterTypes.Number, Filter.OrderTypes.Ascending);
                        break;
                    case "MaxValue":
                        ViewModel.UpdateTransactionFilters(Filter.FilterTypes.Number, Filter.OrderTypes.Descending);
                        break;


                    case "MinDate":
                        ViewModel.UpdateTransactionFilters(Filter.FilterTypes.DateTime, Filter.OrderTypes.Ascending);
                        break;
                    case "MaxDate":
                        ViewModel.UpdateTransactionFilters(Filter.FilterTypes.DateTime, Filter.OrderTypes.Descending);
                        break;

                    default:
                        ViewModel.UpdateTransactionFilters(Filter.FilterTypes.None, Filter.OrderTypes.Descending);
                        break;
                }
            }
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox)?.SelectedValue != null && ViewModel != null)
                ViewModel.UpdateTransactionFilters(ViewModel.Filter.FilterType, ViewModel.Filter.OrderType, Enum.Parse<TransactionFilter.TransactionTypesFilter>((sender as ComboBox).SelectedValue.ToString() ?? "None"));
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox)?.SelectedValue != null && ViewModel != null)
                ViewModel.UpdateTransactionFilters(ViewModel.Filter.FilterType, ViewModel.Filter.OrderType, ViewModel.Filter.Type, int.Parse((sender as ComboBox).SelectedValue.ToString() ?? "-1"));
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
