﻿using FinanceiroApp.WPF.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroApp.WPF.ViewModel.Categories
{
    public class TransactionCategoriesViewModel : FinAppViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public TransactionCategoriesViewModel()
        {

        }


    }
}