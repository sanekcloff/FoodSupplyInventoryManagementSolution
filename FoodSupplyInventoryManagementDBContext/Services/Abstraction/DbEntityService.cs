using FoodSupplyInventoryManagementDBContext.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services.Abstraction
{
    public abstract class DbEntityServiceBase<T> : IBaseManagement<T>
    {
        protected readonly AppDbContext ctx;
        public DbEntityServiceBase()
        {
            ctx = DbController.GetInstance().GetContext();
        }

        public abstract Task<IEnumerable<T?>> GetEntities();
        public abstract Task<T?> GetEntity(Guid id);
        public abstract Task<bool> Add(T entity);
        public abstract Task<bool> Update(T entity, T newEntity);
        public async virtual Task<bool> Remove(T entity)
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
    }
}
