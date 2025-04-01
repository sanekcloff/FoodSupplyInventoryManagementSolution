using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Windows
{
    public class AuthenticationViewModel : ViewModelBase
    {
        public AuthenticationViewModel()
        {
            _currentPage = new LoginPage(this);
        }

        #region Variables

        #region Fields
        private UserControl _currentPage = null!;
        #endregion

        #region Property
        public UserControl CurrentPage 
        {
            get => _currentPage;
            set 
            {
                if (Set(ref _currentPage, value, nameof(CurrentPage)))
                    Debug.WriteLine($"[{GetType()}] - {nameof(CurrentPage)} property was changed!");
                else Debug.WriteLine($"[{GetType()}] - {nameof(CurrentPage)} property doesn't changed!");
            }
        }
        #endregion

        #endregion
    }
}
