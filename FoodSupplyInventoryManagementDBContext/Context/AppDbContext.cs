using FoodSupplyInventoryManagementLib.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Context
{
    public abstract class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyItem> SupplyItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers"); // указываем название таблицы
                entity.HasKey(customer => customer.Id); // указываем первичный ключ
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products"); // указываем название таблицы
                entity.HasKey(product => product.Id); // указываем первичный ключ
                entity.HasOne(product => product.Provider) // указываем навигационное свойство для связи
                .WithMany(provider => provider.Products) // указываем обратное навигационное свойство для связи
                .HasForeignKey(product => product.ProviderId); // указываем свойсво для установки Id связи
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
