using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinanceiroApp.WPF.ViewModel.Command
{
    /// <summary>
    /// Basic Command for simple ViewModels
    /// </summary>
    public class BasicFinAppCommand : ICommand
    {
        //TODO: CRIAR UMA PASTA PARA COMMANDS BASICOS, ESSE BASIC E COMMANDS GENERICOS DE CRUD
        public FinAppViewModel ViewModel { get; set; }
        public event EventHandler? CanExecuteChanged;

        public BasicFinAppCommand(FinAppViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.Action();
        }
    }
}
