using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DevTest.WPF.Commands
{
    public class ClearCommand : ICommand
    {
        private RegisterViewModel viewModel;

        public ClearCommand(RegisterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Cod = null;
            viewModel.ProdName = null;
            viewModel.CodBarra = null;
            viewModel.PrecoCusto = null;
            viewModel.PrecoVenda = null;
            viewModel.Ativo = false;
            viewModel.NomeGrupo = null;
        }
    }
}
