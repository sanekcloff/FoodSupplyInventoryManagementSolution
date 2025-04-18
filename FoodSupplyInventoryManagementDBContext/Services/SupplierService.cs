﻿using FoodSupplyInventoryManagementDBContext.Services.Abstraction;
using FoodSupplyInventoryManagementLib.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services
{
    public class SupplierService : DbEntityServiceBase<Supplier>
    {
        public override async Task<bool> Add(Supplier entity)
        {
            if (entity == null) return await Task.FromResult(false);

            if(entity.Id == Guid.Empty) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(entity.Title)) return await Task.FromResult(false);

            if(string.IsNullOrEmpty(entity.Email)) return await Task.FromResult(false);
            if(string.IsNullOrEmpty(entity.Phone)) return await Task.FromResult(false);

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
                Debug.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public override async Task<IEnumerable<Supplier?>> GetEntities() => await Task.FromResult(ctx.Suppliers);

        public override async Task<Supplier?> GetEntity(Guid id)
        {
            return await Task.FromResult(ctx.Suppliers.Single(p=>p.Id == id));
        }

        public override async Task<bool> Update(Supplier entity, Supplier newEntity)
        {
            if (entity == null || newEntity == null) return await Task.FromResult(false);

            if (entity.Id == Guid.Empty) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(entity.Title)) return await Task.FromResult(false);

            if (string.IsNullOrEmpty(entity.Email)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Phone)) return await Task.FromResult(false);

            try
            {
                entity.Title = newEntity.Title;
                entity.Description = newEntity.Description;
                entity.Email = newEntity.Email;
                entity.Phone = newEntity.Phone;

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
