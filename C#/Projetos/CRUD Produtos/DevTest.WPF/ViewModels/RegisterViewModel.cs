using DevTest.Domain.Models;
using DevTest.Domain.Services;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using DevTest.WPF.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System;

namespace DevTest.WPF.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _cod;
        private string _prodName, _codBarra;
        private string _nomeGrupo;
        private string _precoCusto, _precoVenda;
        private bool _ativo;
        private IEnumerable<Produto_Grupo> _listaGrupos;

        public RegisterViewModel()
        {
            GetProdNameCommand = new RegisterCommand(this, new GenericDataService<Produto>(new CRUDProdutosDbContextFactory()));
            UpdateCommand = new UpdateCommand(this, new GenericDataService<Produto>(new CRUDProdutosDbContextFactory()));
            ClearCommand = new ClearCommand(this);
            GetGroups();
        }

        public string Cod
        {
            get
            {
                return _cod;
            }
            set
            {
                _cod = value;
                OnPropertyChanged(nameof(Cod));
            }
        }

        public string ProdName
        {
            get
            {
                return _prodName;
            }
            set
            {
                _prodName = value;
                OnPropertyChanged(nameof(ProdName));
            }
        }

        public string CodBarra
        {
            get
            {
                return _codBarra;
            }
            set
            {
                _codBarra = value;
                OnPropertyChanged(nameof(CodBarra));
            }
        }

        public string NomeGrupo
        {
            get
            {
                return _nomeGrupo;
            }
            set
            {
                _nomeGrupo = value;
                OnPropertyChanged(nameof(NomeGrupo));
            }
        }

        public string PrecoCusto
        {
            get
            {
                return _precoCusto;
            }
            set
            {
                _precoCusto = value;
                OnPropertyChanged(nameof(PrecoCusto));
            }
        }

        public string PrecoVenda
        {
            get
            {
                return _precoVenda;
            }
            set
            {
                _precoVenda = value;
                OnPropertyChanged(nameof(PrecoVenda));
            }
        }

        public bool Ativo
        {
            get
            {
                return _ativo;
            }
            set
            {
                _ativo = value;
                OnPropertyChanged(nameof(Ativo));
            }
        }

        public IEnumerable<Produto_Grupo> ListaGrupos
        {
            get
            {
                return _listaGrupos;
            }
            set
            {
                _listaGrupos = value;
                OnPropertyChanged(nameof(ListaGrupos));
            }
        }

        public ICommand GetProdNameCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void GetGroups()
        {
            IDataService<Produto_Grupo> productGroupService = new GenericDataService<Produto_Grupo>(new CRUDProdutosDbContextFactory());
            _listaGrupos = productGroupService.GetAll().Result.ToList();
        }
    }
}
