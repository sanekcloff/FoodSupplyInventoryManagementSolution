using FoodSupplyInventoryManagementLib.Entites;
using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Windows
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(Customer customer)
        {
            _currentPage = new ProductsPage(this);
        }

        private UserControl _currentPage;
        public UserControl CurrentPage { get => _currentPage; set => Set(ref _currentPage, value, nameof(CurrentPage)); }
    }
}
