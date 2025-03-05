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
            var customer1 = new Customer()
            {
                Firstname = "Имя",
                Lastname = "Фамилия",
                Middlename = "Отчество",
                Id = Guid.NewGuid(),
                Login = "Login",
                Password = "Password",
                Organization = "Организация"
            };
            var customer2 = new Customer()
            {
                Firstname = "Имя1",
                Lastname = "Фамилия1",
                Middlename = "Отчество1",
                Id = Guid.NewGuid(),
                Login = "Login1",
                Password = "Password1",
                Organization = "Организация1"
            };
            if (new CustomerService().Add(customer1).Result) 
            {
                MessageBox.Show("Customer added");
            }
            if (new CustomerService().Update(customer1, customer2).Result)
            {
                MessageBox.Show("Customer updated");
            }
            if (new CustomerService().Remove(customer1).Result)
            {
                MessageBox.Show("Customer deleted");
            }
        }
    }
}