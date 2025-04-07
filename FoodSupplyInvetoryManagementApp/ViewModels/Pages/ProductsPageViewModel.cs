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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FoodSupplyInvetoryManagementApp.ViewModels.Pages
{
    public class ImagedProduct : Product
    {
        public ImageBrush ImageLogo { get => new ImageBrush(GetBitmapImage(Image)); }
        private BitmapImage GetBitmapImage(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                var bitMapImage = new BitmapImage();
                bitMapImage.BeginInit();
                bitMapImage.StreamSource = stream;
                bitMapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitMapImage.EndInit();
                bitMapImage.Freeze();
                return bitMapImage;
            }
        }
    }
    public class ProductsPageViewModel : ViewModelBase
    {
        public ProductsPageViewModel(ViewModelBase viewModel)
        {
            InitializeCollections().GetAwaiter();
            ViewUpdate += UpdateControls;

            UploadImage = new RelayCommand(o => 
            {
                var result = OpenExplorer();
                if (result.ShowDialog() == true)
                {
                    Image = File.ReadAllBytes(result.FileName);
                    ViewUpdate?.Invoke(nameof(UploadImage), EventArgs.Empty);
                }
            });
            UploadEImage = new RelayCommand(o =>
            {
                var result = OpenExplorer();
                if (result.ShowDialog() == true)
                {
                    EImage = File.ReadAllBytes(result.FileName);
                    ViewUpdate?.Invoke(nameof(UploadEImage), EventArgs.Empty);
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
                    Supplier = _selectedSupplier,
                    Image = _image
                }).Result)
                {
                    Debug.WriteLine("Success");
                    ViewUpdate?.Invoke(nameof(AddProduct), EventArgs.Empty);
                }
            });
            UpdateProduct = new RelayCommand(o => 
            {
                var newProduct = new Product() 
                {
                    Title = _etitle,
                    Description = _edescription,
                    Discount = _ediscount,
                    Supplier = _eselectedSupplier,
                    Image = _eimage,
                    Cost = _ecost
                };
                // подстановка продукта через выборку по id
                var product = new 
                if (new ProductService().Update(_selectedProduct as Product,newProduct).Result)
                {
                    Debug.WriteLine("Success");
                    ViewUpdate?.Invoke(nameof(UpdateProduct), EventArgs.Empty);
                }
            });
            RemoveProduct = new RelayCommand(o => 
            {
                if (new ProductService().Remove(_selectedProduct).Result)
                {
                    Debug.WriteLine("Success");
                    ViewUpdate?.Invoke(nameof(RemoveProduct), EventArgs.Empty);
                }
            });
        }

        #region Delegates & Events
        public delegate void CommandHandler(object obj, EventArgs args);
        public event CommandHandler ViewUpdate;
        #endregion

        #region Fields
        private string _title = string.Empty;
        private string _description = string.Empty;
        private decimal _cost = 0;
        private decimal _discount = 0;
        private Supplier _selectedSupplier = null!;

        private string _etitle = string.Empty;
        private string _edescription = string.Empty;
        private decimal _ecost = 0;
        private decimal _ediscount = 0;
        private Supplier _eselectedSupplier = null!;

        private byte[] _image = null!;
        private byte[] _eimage = null!;
        private ObservableCollection<Supplier> _suppliers;

        private ImagedProduct _selectedProduct = null!;
        private ObservableCollection<ImagedProduct> _products = null!;
        #endregion

        #region Props
        public string Title { get => _title; set => Set(ref _title, value, nameof(Title)); }
        public string Description { get => _description; set => Set(ref _description, value, nameof(Description)); }
        public decimal Cost { get => _cost; set => Set(ref _cost, value, nameof(Cost)); }
        public decimal Discount { get => _discount; set => Set(ref _discount, value, nameof(Discount)); }
        public Supplier SelectedSupplier { get => _selectedSupplier; set => Set(ref _selectedSupplier, value, nameof(SelectedSupplier)); }
        public string ETitle { get => _etitle; set => Set(ref _etitle, value, nameof(ETitle)); }
        public string EDescription { get => _edescription; set => Set(ref _edescription, value, nameof(EDescription)); }
        public decimal ECost { get => _ecost; set => Set(ref _ecost, value, nameof(ECost)); }
        public decimal EDiscount { get => _ediscount; set => Set(ref _ediscount, value, nameof(EDiscount)); }
        public Supplier ESelectedSupplier { get => _eselectedSupplier; set => Set(ref _eselectedSupplier, value, nameof(ESelectedSupplier)); }
        public ObservableCollection<Supplier> Suppliers 
        { 
            get => _suppliers; 
            set 
            {
                if  (Set(ref _suppliers, value, nameof(Suppliers)));
            }
        }
        public ImagedProduct SelectedProduct 
        { 
            get => _selectedProduct;
            set 
            {
                if (Set(ref _selectedProduct, value, nameof(SelectedProduct)) && _selectedProduct != null)
                {
                    ETitle = _selectedProduct.Title;
                    EDescription = _selectedProduct.Description;
                    ECost = _selectedProduct.Cost;
                    EDiscount = _selectedProduct.Discount;
                    EImage = _selectedProduct.Image;
                    ESelectedSupplier = _selectedProduct.Supplier;
                }
            } 
        }
        public ObservableCollection<ImagedProduct> Products 
        { 
            get => _products;
            set 
            {
                if (Set(ref _products, value, nameof(Products)));
            }
        }
        public byte[] Image { get => _image; set => Set(ref _image, value, nameof(Image)); }
        public byte[] EImage { get => _eimage; set => Set(ref _eimage, value, nameof(EImage)); }
        #endregion

        #region Commands
        public RelayCommand AddProduct { get; }
        public RelayCommand UpdateProduct { get; }
        public RelayCommand RemoveProduct { get; }
        public RelayCommand UploadImage { get; }
        public RelayCommand UploadEImage { get; }
        #endregion

        #region Methods
        private OpenFileDialog OpenExplorer()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Multiselect = false;
            return openFileDialog;
        }
        private void UpdateControls(object obj, EventArgs args)
        {
            InitializeCollections().GetAwaiter();
            Debug.WriteLine($"{obj.ToString()} - called view update with args ({args.ToString()})!");
        }
        private async Task InitializeCollections()
        {
            var products = await new ProductService().GetEntities();

            ObservableCollection<ImagedProduct> imageProducts = new ObservableCollection<ImagedProduct>();

            foreach (var product in products)
            {
                var newInst = new ImagedProduct() 
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Cost = product.Cost,
                    Supplier = product.Supplier,
                    Id = product.Id,
                    Image = product.Image,
                };
                imageProducts.Add(newInst);
            }

            var suppliers = await new SupplierService().GetEntities();

            Products = new ObservableCollection<ImagedProduct>(imageProducts!);
            Suppliers = new ObservableCollection<Supplier>(suppliers!);
        }
        #endregion
    }
}
