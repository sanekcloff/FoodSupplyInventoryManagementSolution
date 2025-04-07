using FoodSupplyInventoryManagementDBContext.Services;
using FoodSupplyInventoryManagementLib.Entites;
using FoodSupplyInvetoryManagementApp.Control;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            _providers = new ProviderService().GetEntities().Result.ToList()!;
            _products = new ProductService().GetEntities().Result.ToList()!;

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
                    Supplier = _selectedProvider
                }).Result) Debug.WriteLine("Success");
            });
        }

        private string _title;
        private string _description;
        private decimal _cost;
        private byte _discount;
        private Supplier _selectedProvider;

        private string _etitle;
        private string _edescription;
        private decimal _ecost;
        private byte _ediscount;
        private Supplier _eselectedProvider;

        private byte[] _image;
        private ICollection<Supplier> _providers;

        private Product _selectedProduct;
        private ICollection<Product> _products;


        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        public string Description { get => _description; set => Set(ref _description, value, nameof(Description)); }
        public decimal Cost { get => _cost; set => Set(ref _cost, value, nameof(Cost)); }
        public byte Discount { get => _discount; set => Set(ref _discount, value, nameof(Discount)); }
        public Supplier SelectedProvider { get => _selectedProvider; set => Set(ref _selectedProvider, value, nameof(SelectedProvider)); }
        public string ETitle { get => _etitle; set => Set(ref _etitle, value, nameof(ETitle)); }
        public string EDescription { get => _edescription; set => Set(ref _edescription, value, nameof(EDescription)); }
        public decimal ECost { get => _ecost; set => Set(ref _ecost, value, nameof(ECost)); }
        public byte EDiscount { get => _ediscount; set => Set(ref _ediscount, value, nameof(EDiscount)); }
        public Supplier ESelectedProvider { get => _eselectedProvider; set => Set(ref _eselectedProvider, value, nameof(ESelectedProvider)); }
        public ICollection<Supplier> Providers { get => _providers; set => Set(ref _providers, value, nameof(Providers)); }
        public Product SelectedProduct { get => _selectedProduct; set => Set(ref _selectedProduct, value, nameof(SelectedProduct)); }
        public ICollection<Product> Products { get => _products; set => Set(ref _products, value, nameof(Products)); }
        public byte[] Image { get => _image; set => Set(ref _image, value, nameof(Image)); }


        public RelayCommand AddProduct { get; }
        public RelayCommand UpdateProduct { get; }
        public RelayCommand RemoveProduct { get; }
        public RelayCommand UploadImage { get; }
    }
}
