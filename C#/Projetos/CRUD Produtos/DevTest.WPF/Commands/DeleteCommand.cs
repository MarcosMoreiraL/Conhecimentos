using DevTest.Domain.Models;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DevTest.WPF.Commands
{
    public class DeleteCommand : ICommand
    {
        private GenericDataService<Produto> dataService;
        private GenericDataService<Venda_Produto> vendaDataService;
        private ConsultViewModel viewModel;

        public event EventHandler CanExecuteChanged;

        public DeleteCommand(ConsultViewModel viewModel, GenericDataService<Produto> dataService)
        {
            this.dataService = dataService;
            this.viewModel = viewModel;
            vendaDataService = new GenericDataService<Venda_Produto>(new CRUDProdutosDbContextFactory());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<Venda_Produto> listaVendas = vendaDataService.GetAll().Result.ToList();

            bool CanDelete = false;

            for (int i = 0; i < listaVendas.Count; i++)
            {
                if (listaVendas[i].codProduto == viewModel.Cod)
                {
                    CanDelete = true;
                    break;
                }
            }

            if(!CanDelete)
            {
                try
                {
                    bool deleted = dataService.Delete(viewModel.ReqCod).Result;
                    viewModel.Cod = 0;
                    viewModel.Descricao = "";
                    viewModel.PrecoCusto = 0;
                    viewModel.PrecoVenda = 0;
                    viewModel.Grupo = "";
                    MessageBox.Show("Produto excluído com sucesso!");
                }
                catch (Exception)
                {

                    MessageBox.Show("Código inválido!");
                }
            }
            else
            {
                MessageBox.Show("Produto utilizado em vendas, não pode ser excluído!");
            }
        }
    }
}
