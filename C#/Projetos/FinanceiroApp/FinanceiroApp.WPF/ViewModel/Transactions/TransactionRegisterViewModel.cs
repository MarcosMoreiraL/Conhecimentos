using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Transactions
{
    public class TransactionRegisterViewModel : FinAppViewModel
    {
        public Transaction Transaction { get; set; }
        public Entity.Models.User User { get; set; }
        public BasicFinAppCommand Command { get; set; }

        public EventHandler Updated;

        public TransactionRegisterViewModel()
        {
            Transaction = new Transaction();
            this.Transaction.Type = Transaction.TransactionType.Income;
            User = App.CloneUser();
            Command = new BasicFinAppCommand(this);
        }

        public void SetTransaction(Transaction transaction)
        {
            this.Transaction = transaction.Clone();
            OnPropertyChanged(nameof(Transaction));
        }

        public Transaction GetEntity()
        {
            return new Transaction()
            {
                Id = Transaction.Id,
                UserId = User.Id,
                Value = Transaction.Value,
                Description = Transaction.Description,
                CategoryId = Transaction.CategoryId,
                WalletId = Transaction.WalletId,
                DateTime = Transaction.DateTime,
                Type = Transaction.Type
            };
        }

        public override async  void Action()
        {
            try
            {
                if (Transaction.Id == 0)
                    await TransactionDatabaseHelper.CreateAsync(GetEntity());
                else
                    await TransactionDatabaseHelper.UpdateAsync(GetEntity());

                MessageBox.Show("Movimentação salva com sucesso!", "Nova Movimentação", MessageBoxButton.OK, MessageBoxImage.Information);

                Updated.Invoke(this, new EventArgs());
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Nova Movimentação", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar movimentação!", "Nova Movimentação", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
