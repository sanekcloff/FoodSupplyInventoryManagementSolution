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
    public class WarehouseService : DbEntityServiceBase<Warehouse>
    {
        public async override Task<bool> Add(Warehouse entity)
        {
            if (entity == null) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(entity.Title)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Address)) return await Task.FromResult(false);

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

        public override async Task<IEnumerable<Warehouse?>> GetEntities() => await Task.FromResult(ctx.Warehouses);

        public async override Task<Warehouse?> GetEntity(Guid id) => await Task.FromResult(ctx.Warehouses.Single(w=>w.Id == id));

        public async override Task<bool> Remove(Warehouse entity)
        {
            if (entity == null) return await Task.FromResult(false);

            // удаление из бд
            try
            {
                ctx.Remove(entity);
                Debug.WriteLine($"{GetType().Name}: entity removed!");
                await ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: changes saved!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: {ex.Message}");
                return false;
            }

            return await Task.FromResult(true);
        }

        public async override Task<bool> Update(Warehouse entity, Warehouse newEntity)
        {
            if (entity == null || newEntity == null) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(entity.Title)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Address)) return await Task.FromResult(false);

            try
            {
                entity.Title = newEntity.Title;
                entity.Address = newEntity.Address;

                ctx.Update(entity);
                Debug.WriteLine($"{GetType().Name}: entity was updated!");
                await ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: entity was saved!");
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }
    }
}
