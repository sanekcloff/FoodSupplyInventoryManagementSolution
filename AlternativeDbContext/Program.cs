using FoodSupplyInventoryManagementLib.Entites;
using Microsoft.EntityFrameworkCore;

namespace AlternativeDbContext
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite("Data Source = local.db"));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            var customer1 = new Customer() 
            {
                Firstname = "Test",
                Lastname = "Test",
                Middlename = "Test",
                Id = Guid.NewGuid(),
                Login = "testlogin",
                Password = "testpassword",
                Organization = "Trash Box"
            };
            context.Customers.Add(customer1);
            var res1 = context.SaveChanges();

            var prov1 = new Supplier()
            {
                Id = Guid.NewGuid(),
                Title = "Test Prov",
                Description = "Prov desc",
                Email = "Prov email",
                Phone = "Prov phone"
            };
            context.Suppliers.Add(prov1);
            context.SaveChanges();
            context.Add(new Product()
            {
                Id = Guid.NewGuid(),
                Title = "Test title",
                Description = "Test desc",
                Discount = 1,
                Cost = 140,
                Supplier = prov1
            });
            var result = context.SaveChanges();

            if (result > 0)
            {
                Console.WriteLine($"{context.Products.First().ToString()}");
            }
            else { Console.WriteLine("ERROR!"); }
        }
    }
}
