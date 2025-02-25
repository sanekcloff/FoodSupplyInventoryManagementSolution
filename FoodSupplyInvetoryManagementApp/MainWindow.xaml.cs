using FoodSupplyInventoryManagementDBContext.Services;
using FoodSupplyInventoryManagementLib.Entites;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodSupplyInvetoryManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            new CustomerService().Add(new Customer() 
            { 
                Firstname = "Имя",
                Lastname = "Фамилия",
                Middlename = "Отчество",
                Id = Guid.NewGuid(),
                Login = "Login",
                Password = "Password",
                Organization = "Организация"
            });
        }
    }
}