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
    public class UpdateCommand : ICommand
    {
        private RegisterViewModel viewModel;
        private GenericDataService<Produto> dataService;
        private GenericDataService<Produto_Grupo> grupoDataService;

        public UpdateCommand(RegisterViewModel viewModel, GenericDataService<Produto> dataService)
        {
            this.viewModel = viewModel;
            this.dataService = dataService;
            grupoDataService = new GenericDataService<Produto_Grupo>(new CRUDProdutosDbContextFactory());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*string text = viewModel.ProdName;
            
            List<Produto_Grupo> listaGrupos = grupoDataService.GetAll().Result.ToList();
            int _codGrupo = 0;

            for (int i = 0; i < listaGrupos.Count; i++)
            {
                if (listaGrupos[i].nome == viewModel.NomeGrupo)
                {
                    _codGrupo = listaGrupos[i].cod;
                    break;
                }
            }

            Produto novoProduto = new Produto
            {
                cod = Convert.ToInt32(viewModel.Cod),
                descricao = viewModel.ProdName,
                codGrupo = _codGrupo,
                codBarra = viewModel.CodBarra,
                precoCusto = Convert.ToDouble(viewModel.PrecoCusto),
                precoVenda = Convert.ToDouble(viewModel.PrecoVenda),
                dataHoraCadastro = DateTime.Now,
                ativo = Convert.ToInt32(viewModel.Ativo)
            };
            UpdateProduct(novoProduto);*/

            try
            {
                int reqCod = Convert.ToInt32(viewModel.Cod);

                if(reqCod != 0)
                {
                    Produto produto = dataService.GetByID(reqCod).Result;
                    if (produto != null)
                    {
                        viewModel.Cod = produto.cod.ToString();
                        viewModel.ProdName = produto.descricao;
                        viewModel.PrecoCusto = produto.precoCusto.ToString();
                        viewModel.PrecoVenda = produto.precoVenda.ToString();
                        viewModel.CodBarra = produto.codBarra;
                        viewModel.NomeGrupo = grupoDataService.GetByID(produto.codGrupo).Result.nome;
                        viewModel.Ativo = Convert.ToBoolean(produto.ativo);
                    }else
                    {
                        MessageBox.Show("Código Inválido");
                    }
                }           
            }
            catch (Exception)
            {
                MessageBox.Show("Código Inválido");
            }

        }

        async void UpdateProduct(Produto produto)
        {
            if (produto.cod != 0)
            {
                await dataService.Update(produto.cod, produto);
                MessageBox.Show("Produto Alterado com Sucesso!");
            }
            else
            {
                MessageBox.Show("Código Inválido");
            }
            //TODO: FAZER UM GET DO PRODUTO PARA PREENCHER OS CAMPOS E CRIAR UMA CONDIÇÃO "SE TEM ID, ALTERAR, SENÃO, REGISTRAR UM NOVO PRODUTO"
        }
    }
}
