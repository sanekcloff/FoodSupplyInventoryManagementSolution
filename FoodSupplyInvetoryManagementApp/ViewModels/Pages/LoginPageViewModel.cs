using FoodSupplyInventoryManagementDBContext.Context;
using FoodSupplyInventoryManagementDBContext.Services;
using FoodSupplyInventoryManagementLib.Entites;
using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.ViewModels.Windows;
using FoodSupplyInvetoryManagementApp.Views.Pages;
using FoodSupplyInvetoryManagementApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Pages
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(ViewModelBase viewModel)
        {
            SwitchToRegisterationCommand = new RelayCommand(o =>
            {
                (viewModel as AuthenticationViewModel)!.CurrentPage = new RegistrationPage(viewModel);
            });
            LoginCommand = new RelayCommand(o =>
            {
                var customer = new CustomerService().GetAccount(Login, Password).Result;
                if (customer != null) 
                {
                    Debug.WriteLine($"[{GetType()}] - customer was found!");
                    MessageBox.Show($"[{GetType()}] - customer was found!");
                    var newWin = new MainWindow(customer);
                    var pervWin = Application.Current.MainWindow;
                    Application.Current.MainWindow = newWin;
                    newWin.Show();
                    pervWin.Close();
                }
                else Debug.WriteLine($"[{GetType()}] - customer doesn't found!");
            });
        }
        #region Variables

        #region Fields
        private string _login;
        private string _password;
        #endregion

        #region Property
        public string Login
        {
            get => _login;
            set
            {
                if (Set(ref _login, value, nameof(Login)))
                    Debug.WriteLine($"[{GetType()}] - property {nameof(Login)} was changed!");
                else
                    Debug.WriteLine($"[{GetType()}] - property {nameof(Login)} doesn't changed!");

            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (Set(ref _password, value, nameof(Password)))
                    Debug.WriteLine($"[{GetType()}] - property {nameof(Password)} was changed!");
                else
                    Debug.WriteLine($"[{GetType()}] - property {nameof(Password)} doesn't changed!");

            }
        }
        #endregion

        #region Commands
        public RelayCommand LoginCommand { get; }
        public RelayCommand SwitchToRegisterationCommand { get; }
        #endregion

        #endregion
    }
}
