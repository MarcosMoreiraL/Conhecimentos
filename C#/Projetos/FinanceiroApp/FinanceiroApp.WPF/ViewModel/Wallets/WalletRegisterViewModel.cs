﻿using FinanceiroApp.Entity.Models;
using FinanceiroApp.Library.Exceptions;
using FinanceiroApp.WPF.ViewModel.Base;
using FinanceiroApp.WPF.ViewModel.Command;
using FinanceiroApp.WPF.ViewModel.Helpers.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceiroApp.WPF.ViewModel.Wallets
{
    public class WalletRegisterViewModel : FinAppViewModel
    {
        public Wallet Wallet { get; set; }
        public BasicFinAppCommand Command { get; set; }
        public EventHandler Saved;

        public WalletRegisterViewModel()
        {
            this.Wallet = new Wallet();
            this.Command = new BasicFinAppCommand(this);
        }

        public WalletRegisterViewModel(BasicFinAppCommand command)
        {
            Wallet = new Wallet();
            Command = command;
        }

        public void SetWallet(Wallet wallet)
        {
            this.Wallet = wallet.Clone();
            OnPropertyChanged(nameof(Wallet));
        }

        public Wallet GetEntity()
        {
            return new Wallet()
            {
                Id = Wallet.Id,
                Description = Wallet.Description,
                UserId = App.User.Id
            };
        }

        public override async void Action()
        {
            try
            {
                if (Wallet.Id == 0)
                    await WalletDatabaseHelper.CreateAsync(GetEntity());
                else
                    await WalletDatabaseHelper.UpdateAsync(GetEntity());

                MessageBox.Show("Carteira salva com sucesso!", "Cadastro de Carteira", MessageBoxButton.OK, MessageBoxImage.Information);
                Saved.Invoke(this, new EventArgs());
            }
            catch (FinAppValidationException rvex)
            {
                MessageBox.Show(rvex.Message, "Cadastro de Carteira", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Erro ao salvar carteira!", "Cadastro de Carteira", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
