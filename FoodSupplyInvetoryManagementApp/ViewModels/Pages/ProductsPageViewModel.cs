using FoodSupplyInventoryManagementDBContext.Services;
using FoodSupplyInventoryManagementLib.Entites;
using FoodSupplyInvetoryManagementApp.Control;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Pages
{
    public class ProductsPageViewModel : ViewModelBase
    {
        public ProductsPageViewModel(ViewModelBase viewModel)
        {
            _suppliers = new ObservableCollection<Supplier>(new SupplierService().GetEntities().Result!);
            _products = new ObservableCollection<Product>(new ProductService().GetEntities().Result!);

            UploadImage = new RelayCommand(o => 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите изображение";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == true)
                {
                    Image = File.ReadAllBytes(openFileDialog.FileName);
                }
            });
            AddProduct = new RelayCommand(o =>
            {
                if (new ProductService().Add(new Product()
                {
                    Id = Guid.NewGuid(),
                    Title = _title,
                    Description = _description,
                    Discount = _discount,
                    Cost = _cost,
                    Supplier = _selectedSupplier
                }).Result) Debug.WriteLine("Success");
            });
        }

        private string _title = string.Empty;
        private string _description = string.Empty;
        private decimal _cost = 0;
        private byte _discount = 0;
        private Supplier _selectedSupplier = null!;

        private string _etitle = string.Empty;
        private string _edescription = string.Empty;
        private decimal _ecost = 0;
        private byte _ediscount = 0;
        private Supplier _eselectedSupplier = null!;

        private byte[] _image = null!;
        private ObservableCollection<Supplier> _suppliers;

        private Product _selectedProduct = null!;
        private ObservableCollection<Product> _products = null!;


        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        public string Description { get => _description; set => Set(ref _description, value, nameof(Description)); }
        public decimal Cost { get => _cost; set => Set(ref _cost, value, nameof(Cost)); }
        public byte Discount { get => _discount; set => Set(ref _discount, value, nameof(Discount)); }
        public Supplier SelectedSupplier { get => _selectedSupplier; set => Set(ref _selectedSupplier, value, nameof(SelectedSupplier)); }
        public string ETitle { get => _etitle; set => Set(ref _etitle, value, nameof(ETitle)); }
        public string EDescription { get => _edescription; set => Set(ref _edescription, value, nameof(EDescription)); }
        public decimal ECost { get => _ecost; set => Set(ref _ecost, value, nameof(ECost)); }
        public byte EDiscount { get => _ediscount; set => Set(ref _ediscount, value, nameof(EDiscount)); }
        public Supplier ESelectedSupplier { get => _eselectedSupplier; set => Set(ref _eselectedSupplier, value, nameof(ESelectedSupplier)); }
        public ObservableCollection<Supplier> Suppliers { get => _suppliers; set => Set(ref _suppliers, value, nameof(Suppliers)); }
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value, nameof(SelectedProduct)); }
        public ObservableCollection<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public byte[] Image { get => _image; set => Set(ref _image, value, nameof(Image)); }


        public RelayCommand AddProduct { get; }
        public RelayCommand UpdateProduct { get; }
        public RelayCommand RemoveProduct { get; }
        public RelayCommand UploadImage { get; }
    }
}
