using DevTest.WPF.Commands;
using DevTest.WPF.Models;
using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace DevTest.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel 
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
