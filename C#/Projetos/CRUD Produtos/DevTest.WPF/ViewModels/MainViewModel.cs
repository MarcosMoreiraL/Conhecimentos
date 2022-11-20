using DevTest.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevTest.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public MainViewModel()
        {
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Consult);
        }
    }
}
