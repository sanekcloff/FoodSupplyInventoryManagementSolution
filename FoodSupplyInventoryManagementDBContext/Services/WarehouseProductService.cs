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
    public class WarehouseProductService : DbEntityServiceBase<WarehouseProduct>
    {
        public async override Task<bool> Add(WarehouseProduct entity)
        {
            if (entity == null) return await Task.FromResult(false);

            if (entity.Amount==0) return await Task.FromResult(false);
            if (entity.Warehouse == null) return await Task.FromResult(false);
            if (entity.Product == null) return await Task.FromResult(false);

            try
            {
                await ctx.AddAsync(entity);
                Debug.WriteLine($"{GetType().Name}: entity was added!");
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

        public override async Task<IEnumerable<WarehouseProduct?>> GetEntities() => await Task.FromResult(ctx.WarehouseProducts.Include(wp => wp.Product).ThenInclude(p => p.Supplier).Include(wp => wp.Warehouse));

        public async override Task<WarehouseProduct?> GetEntity(Guid id) => await Task.FromResult(ctx.WarehouseProducts.Include(wp => wp.Product).ThenInclude(p => p.Supplier).Include(wp => wp.Warehouse).Single(wp=>wp.Id == id));

        public async override Task<bool> Update(WarehouseProduct entity, WarehouseProduct newEntity)
        {
            if (entity == null) return await Task.FromResult(false);

            if (entity.Amount == 0) return await Task.FromResult(false);
            if (entity.Warehouse == null) return await Task.FromResult(false);
            if (entity.Product == null) return await Task.FromResult(false);

            try
            {
                entity.Amount =newEntity.Amount;
                entity.Warehouse = newEntity.Warehouse;
                entity.Product = newEntity.Product;

                await ctx.AddAsync(entity);
                Debug.WriteLine($"{GetType().Name}: entity was added!");
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
