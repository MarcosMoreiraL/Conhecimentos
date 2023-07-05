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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinanceiroApp.WPF.ViewModel.User;

namespace FinanceiroApp.WPF.Controls.User
{
    /// <summary>
    /// Interaction logic for EditUserControl.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        public UpdateUserViewModel ViewModel { get; set; }

        public UpdateUserWindow()
        {
            InitializeComponent();
            ViewModel = Resources["vm"] as UpdateUserViewModel ?? new UpdateUserViewModel();
            ViewModel.Updated += this.Updated;
        }

        private void txtCurPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetOldPassword((sender as PasswordBox).Password);

        private void txtNewPassword_PasswordChanged(object sender, RoutedEventArgs e) => ViewModel.SetUserPassword((sender as PasswordBox).Password);

        private void Updated(object sender, EventArgs e) => this.Close();

        private void btnUndoChanges_Click(object sender, RoutedEventArgs e)
        {
            txtCurPassword.Password = string.Empty;
            txtNewPassword.Password = string.Empty;
        }
    }
}
