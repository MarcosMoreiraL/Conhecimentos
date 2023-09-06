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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loginControl.ViewModel.Authenticated += Authenticated;
            loginControl.SwitchToRegister += SwitchToRegister;

            registerControl.ViewModel.Saved += Saved;
            registerControl.SwitchToLogin += SwitchToLogin;
        }

        private void Authenticated(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

            this.Close();
        }

        private void SwitchToRegister(object sender, EventArgs e)
        {
            loginControl.Visibility = Visibility.Collapsed;
            registerControl.Visibility = Visibility.Visible;
        }

        private void SwitchToLogin(object sender, EventArgs e)
        {
            registerControl.Visibility = Visibility.Collapsed;
            loginControl.Visibility = Visibility.Visible;
        }

        private void Saved(object sender, EventArgs e) => SwitchToLogin(sender, e);

        private void btnClose_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
