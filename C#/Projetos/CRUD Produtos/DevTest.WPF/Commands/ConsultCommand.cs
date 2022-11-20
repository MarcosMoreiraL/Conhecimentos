using DevTest.Domain.Models;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DevTest.WPF.Commands
{
    public class ConsultCommand : ICommand
    {
        private GenericDataService<Produto> dataService;
        private ConsultViewModel viewModel;
        private GenericDataService<Produto_Grupo> grupoDataService;

        public event EventHandler CanExecuteChanged;

        public ConsultCommand(ConsultViewModel viewModel, GenericDataService<Produto> dataService)
        {
            this.dataService = dataService;
            this.viewModel = viewModel;
            grupoDataService = new GenericDataService<Produto_Grupo>(new CRUDProdutosDbContextFactory());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Produto produto = dataService.GetByID(viewModel.ReqCod).Result;
            if(produto != null)
            {
                viewModel.Cod = produto.cod;
                viewModel.Descricao = produto.descricao;
                viewModel.PrecoCusto = produto.precoCusto;
                viewModel.PrecoVenda = produto.precoVenda;
                viewModel.Grupo = grupoDataService.GetByID(produto.codGrupo).Result.nome;
            }else
            {
                MessageBox.Show("Produto não encontrado!");
            }
        }
    }
}
