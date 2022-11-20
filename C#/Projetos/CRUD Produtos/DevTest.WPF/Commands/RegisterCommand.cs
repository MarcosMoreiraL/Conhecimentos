using DevTest.Domain.Models;
using DevTest.Domain.Services;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DevTest.WPF.Commands
{
    public class RegisterCommand : ICommand
    {

        private RegisterViewModel viewModel;
        private GenericDataService<Produto> dataService;
        private GenericDataService<Produto_Grupo> grupoDataService;

        public event EventHandler CanExecuteChanged;
        public RegisterCommand(RegisterViewModel viewModel, GenericDataService<Produto> dataService)
        {
            this.viewModel = viewModel;
            this.dataService = dataService;
            grupoDataService = new GenericDataService<Produto_Grupo>(new CRUDProdutosDbContextFactory());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string text = viewModel.ProdName;
            List<Produto_Grupo> listaGrupos = grupoDataService.GetAll().Result.ToList();
            int _codGrupo = 0;

            for(int i = 0; i < listaGrupos.Count; i++)
            {
                if(listaGrupos[i].nome == viewModel.NomeGrupo)
                {
                    _codGrupo = listaGrupos[i].cod;
                    break;
                }
            }

            Produto novoProduto = new Produto
            {
                descricao = viewModel.ProdName,
                codGrupo = _codGrupo,
                codBarra = viewModel.CodBarra,
                precoCusto = Convert.ToDouble(viewModel.PrecoCusto),
                precoVenda = Convert.ToDouble(viewModel.PrecoVenda),
                dataHoraCadastro = DateTime.Now,
                ativo = Convert.ToInt32(viewModel.Ativo)
            };
            InsertProduct(novoProduto);
        }

        async void InsertProduct(Produto produto)
        {
            if (viewModel.Cod != null)
            {
                int cod = Convert.ToInt32(viewModel.Cod);
                if(cod != 0)
                {
                    await dataService.Update(cod, produto);
                    MessageBox.Show("Produto alterado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Código inválido!");
                }
            }
            else
            {
                await dataService.Create(produto);
                MessageBox.Show("Produto inserido com sucesso!");
            }
        } 
    }
}
