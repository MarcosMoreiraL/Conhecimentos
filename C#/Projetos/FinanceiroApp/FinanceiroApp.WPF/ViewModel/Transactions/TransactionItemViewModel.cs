using FinanceiroApp.Entity.Models;
using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Transactions
{
    public class TransactionItemViewModel : FinAppViewModel
    {
        private Transaction _transaction;
        public Transaction Transaction
        {
            get => _transaction;

            set
            {
                _transaction = value;
                OnPropertyChanged(nameof(Transaction));
            }
        }

        public TransactionItemViewModel()
        {
            _transaction = new Transaction();
        }
    }
}
