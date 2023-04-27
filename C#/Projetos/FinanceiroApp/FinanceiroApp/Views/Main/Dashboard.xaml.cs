﻿using System;
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
        public Dashboard()
        {
            InitializeComponent();
            txtTitle.Text = "Bem-vindo " + App.User.Name;
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewTransaction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewTransactionCategory_Click(object sender, RoutedEventArgs e)
        {
            Transaction.TransactionCategoryRegister categoryRegister = new Transaction.TransactionCategoryRegister();
            categoryRegister.Show();
        }
    }
}
