using FoodSupplyInventoryManagementDBContext.Services;
using FoodSupplyInventoryManagementLib.Entites;
using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.ViewModels.Windows;
using FoodSupplyInvetoryManagementApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            RegisterCommand = new RelayCommand(o =>
            {
                if (new CustomerService().Add(new Customer()
                {
                    Id = Guid.NewGuid(),
                    Firstname = _firstname,
                    Lastname = _lastname,
                    Middlename = _middlename,
                    Organization = _organization,
                    Login = _login,
                    Password = _password
                }).Result)
                {
                    Debug.WriteLine($"[{GetType()}] - customer has created!");
                    MessageBox.Show($"[{GetType()}] - customer has created!");
                }
                else
                {
                    Debug.WriteLine($"[{GetType()}] - customer doesn't created!");
                    MessageBox.Show($"[{GetType()}] - customer doesn't created!");
                }
            });
        }

        #region Variables

        #region Fields
        private string _firstname = string.Empty;
        private string _lastname = string.Empty;
        private string _middlename = string.Empty;
        private string _organization = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        #endregion

        #region Property
        public string Firstname
        {
            get => _firstname;
            set => Set(ref _firstname, value, nameof(Firstname));
        }
        public string Lastname
        {
            get => _lastname;
            set => Set(ref _lastname, value, nameof(Lastname));
        }
        public string Middlename
        {
            get => _middlename;
            set => Set(ref _middlename, value, nameof(Middlename));
        }
        public string Organization
        {
            get => _organization;
            set => Set(ref _organization, value, nameof(Organization));
        }
        public string Login
        {
            get => _login;
            set => Set(ref _login, value, nameof(Login));
        }
        public string Password
        {
            get => _password;
            set => Set(ref _password, value, nameof(Password));
        }

        #endregion

        #region Commands
        public RelayCommand SwitchToLoginCommand { get; }
        public RelayCommand RegisterCommand { get; }
        #endregion

        #endregion
    }
}
