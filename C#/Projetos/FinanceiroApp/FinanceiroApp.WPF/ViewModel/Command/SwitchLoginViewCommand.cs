﻿using FinanceiroApp.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    public class SwitchLoginViewCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public SwitchLoginViewCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            LoginViewModel.SwitchViews();
        }
    }
}