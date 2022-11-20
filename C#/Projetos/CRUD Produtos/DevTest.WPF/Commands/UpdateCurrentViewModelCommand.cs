using DevTest.WPF.State.Navigators;
using DevTest.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DevTest.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
             
                switch (viewType)
                {
                    case ViewType.Register:
                        _navigator.CurrentViewModel = new RegisterViewModel();
                        break;
                    case ViewType.Consult:
                        _navigator.CurrentViewModel = new ConsultViewModel();
                        break;
                    default:
                        _navigator.CurrentViewModel = new ConsultViewModel();
                        break;
                }
            }
        }
    }
}