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
        public DbSet<Supplier> Suppliers { get; set; }
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
                entity.HasData(new Customer() // стартовые значения в таблице
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Имя",
                    Lastname = "Фамилия",
                    Middlename = "Отчество",
                    Organization = "Организация",
                    Login = "Login",
                    Password = "Password"
                });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products"); // указываем название таблицы
                entity.HasKey(product => product.Id); // указываем первичный ключ
                entity.HasOne(product => product.Supplier) // указываем навигационное свойство для связи
                .WithMany(provider => provider.Products) // указываем обратное навигационное свойство для связи
                .HasForeignKey(product => product.SupplierId); // указываем свойсво для установки Id связи
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers"); // указываем название таблицы
                entity.HasKey(provider => provider.Id); // указываем первичный ключ
                entity.HasData(new Supplier() // стартовые значения в таблице
                { 
                    Id=Guid.NewGuid(),
                    Title = "Дядя толик",
                    Description = "Лысый",
                    Email = "Psina@mail.ru",
                    Phone = "Xiaomi"
                });
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supplies"); // указываем название таблицы
                entity.HasKey(supply => supply.Id); // указываем первичный ключ
                entity.HasOne(supply => supply.Customer) // указываем навигационное свойство для связи
                .WithMany(customer => customer.Supplies) // указываем обратное навигационное свойство для связи
                .HasForeignKey(supply => supply.CustomerId); // указываем свойсво для установки Id связи
            });

            modelBuilder.Entity<SupplyItem>(entity =>
            {
                entity.ToTable("SupplyItems"); // указываем название таблицы
                entity.HasKey(supplyItem => supplyItem.Id); // указываем первичный ключ
                entity.HasOne(supplyItem => supplyItem.Supply) // указываем навигационное свойство для связи
                .WithMany(supply => supply.SupplyItems) // указываем обратное навигационное свойство для связи
                .HasForeignKey(supplyItem => supplyItem.SupplyId); // указываем свойсво для установки Id связи
                entity.HasOne(supplyItem => supplyItem.Product) // указываем навигационное свойство для связи
                .WithMany(product => product.SupplyItems) // указываем обратное навигационное свойство для связи
                .HasForeignKey(supplyItem => supplyItem.ProductId); // указываем свойсво для установки Id связи
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouses"); // указываем название таблицы
                entity.HasKey(warehouse => warehouse.Id); // указываем первичный ключ
            });

            modelBuilder.Entity<WarehouseProduct>(entity =>
            {
                entity.ToTable("WarehouseProducts"); // указываем название таблицы
                entity.HasKey(warehouseProduct => warehouseProduct.Id); // указываем первичный ключ
                entity.HasOne(warehouseProduct => warehouseProduct.Product) // указываем навигационное свойство для связи
                .WithMany(product => product.WarehouseProducts) // указываем обратное навигационное свойство для связи
                .HasForeignKey(warehouseProduct => warehouseProduct.ProductId); // указываем свойсво для установки Id связи
                entity.HasOne(warehouseProduct => warehouseProduct.Warehouse) // указываем навигационное свойство для связи
                .WithMany(warehouse => warehouse.WarehouseProducts) // указываем обратное навигационное свойство для связи
                .HasForeignKey(warehouseProduct => warehouseProduct.WarehouseId); // указываем свойсво для установки Id связи
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
