using DevTest.Domain.Models;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using DevTest.WPF.Commands;
using System;
using System.Windows.Input;

namespace DevTest.WPF.ViewModels
{
    public class ConsultViewModel : BaseViewModel
    {
        private int _cod, _reqCod;
        private string _descricao;
        private string _grupo;
        private double _precoCusto;
        private double _precoVenda;

        public ConsultViewModel()
        {
            ConsultCommand = new ConsultCommand(this, new GenericDataService<Produto>(new CRUDProdutosDbContextFactory()));
            DeleteCommand = new DeleteCommand(this, new GenericDataService<Produto>(new CRUDProdutosDbContextFactory()));
        }

        public int ReqCod
        {
            get
            {
                return _reqCod;
            }
            set
            {
                _reqCod = Convert.ToInt32(value);
                OnPropertyChanged(nameof(ReqCod));
            }
        }

        public int Cod
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

        public string Descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                _descricao = value;
                OnPropertyChanged(nameof(Descricao));
            }
        }

        public string Grupo
        {
            get
            {
                return _grupo;
            }
            set
            {
                _grupo = value;
                OnPropertyChanged(nameof(Grupo));
            }
        }

        public double PrecoCusto
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

        public double PrecoVenda
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

        public ICommand ConsultCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
    }
}
