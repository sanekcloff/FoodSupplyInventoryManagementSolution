using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.ViewModels.Windows;
using FoodSupplyInvetoryManagementApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Pages
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        public RegistrationPageViewModel(ViewModelBase viewModel) 
        {
            SwitchToLoginCommand = new RelayCommand(o =>
            {
                (viewModel as AuthenticationViewModel)!.CurrentPage = new LoginPage(viewModel);
            });
        }

        #region Variables
        #region Fields

        #endregion

        #region property
        #endregion

        #region Commands
        public RelayCommand SwitchToLoginCommand { get; }
        #endregion

        #endregion
    }
}
