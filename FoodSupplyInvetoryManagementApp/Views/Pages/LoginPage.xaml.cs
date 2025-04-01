using FoodSupplyInvetoryManagementApp.Control;
using FoodSupplyInvetoryManagementApp.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodSupplyInvetoryManagementApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        private LoginPageViewModel _viewModel;
        public LoginPage(ViewModelBase currentPage)
        {
            InitializeComponent();
            DataContext = _viewModel = new LoginPageViewModel(currentPage);
        }
    }
}
