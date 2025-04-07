using FoodSupplyInventoryManagementDBContext.Services.Abstraction;
using FoodSupplyInventoryManagementLib.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services
{
    public class ProductService : DbEntityServiceBase<Product>
    {
        public async override Task<bool> Add(Product entity)
        {
            // Проверка входных параметров
            if (entity == null ||
                string.IsNullOrEmpty(entity.Title) ||
                entity.Cost <= 0 ||
                entity.Supplier == null)
            {
                return false;
            }

            try
            {
                await ctx.AddAsync(entity);
                Debug.WriteLine($"{GetType().Name}: entity was added!");

                var list = ctx.Products.ToList();

                int changes = ctx.SaveChanges();
                Debug.WriteLine($"{GetType().Name}: {changes} changes were saved!");

                return changes > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: Error adding product. {ex.Message}");
                return false;
            }
        }

        public override async Task<IEnumerable<Product?>> GetEntities() => await Task.FromResult(ctx.Products.Include(p=>p.Supplier));

        public override async Task<Product?> GetEntity(Guid id) => await Task.FromResult(ctx.Products.Include(p => p.Supplier).Single(p=>p.Id == id));

        public async override Task<bool> Update(Product entity, Product newEntity)
        {
            if (entity == null) return await Task.FromResult(false);
            if (newEntity == null) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(newEntity.Title)) return await Task.FromResult(false);
            if (newEntity.Cost == 0) return await Task.FromResult(false);
            if (newEntity.Image == null!) return await Task.FromResult(false);
            if (newEntity.Supplier == null!) return await Task.FromResult(false);

            try
            {
                entity.Title = newEntity.Title;
                entity.Cost = newEntity.Cost;
                entity.Image = newEntity.Image;
                entity.Supplier = newEntity.Supplier;
                entity.Description = newEntity.Description;

                ctx.Update(entity);
                Debug.WriteLine($"{GetType().Name}: entity was updated!");
                await ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: entity was saved!");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: {ex.Message}");
                return await Task.FromResult(false);
            }
        }
    }
}
