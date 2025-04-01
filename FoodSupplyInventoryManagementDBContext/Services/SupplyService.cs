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
    public class SupplyService : DbEntityServiceBase<Supply>, ISupplyManagment<Supply>
    {
        public override async Task<bool> Add(Supply entity)
        {
            if (entity == null) return await Task.FromResult(false);

            if(entity.TotalCost == 0) return await Task.FromResult(false);
            if (entity.StartDate == DateTime.MinValue) return await Task.FromResult(false);
            if (entity.Statuses == Status.Waiting) return await Task.FromResult(false);
            if (entity.Customer == null!) return await Task.FromResult(false);
            if (entity.SupplyItems == null!) return await Task.FromResult(false);

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

        public override async Task<IEnumerable<Supply?>> GetEntities() => await Task.FromResult(ctx.Supplies.Include(s=>s.Customer).ThenInclude(c=>c.Organization));

        public override async Task<Supply?> GetEntity(Guid id) => await Task.FromResult(ctx.Supplies.Include(s => s.Customer).ThenInclude(c => c.Organization).Single(s=>s.Id == id));

        public async Task<bool> SetStatusCanceled(Supply entity)
        {
            if (entity == null!) return await Task.FromResult(false);

            try
            {
                entity.EndDate = null!;
                entity.IsCompleted = false;
                entity.Statuses = Status.Canceled;
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

        public async Task<bool> SetStatusCompleted(Supply entity)
        {
            if (entity == null!) return await Task.FromResult(false);

            try
            {
                entity.EndDate = DateTime.Now;
                entity.IsCompleted = true;
                entity.Statuses = Status.Completed;
                await Update(entity);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> SetStatusInProgress(Supply entity)
        {
            if (entity == null!) return await Task.FromResult(false);

            try
            {
                entity.EndDate = DateTime.Now;
                entity.IsCompleted = true;
                entity.Statuses = Status.InProgres;
                await Update(entity);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> SetStatusWaiting(Supply entity)
        {
            if (entity == null!) return await Task.FromResult(false);

            try
            {
                entity.EndDate = DateTime.Now;
                entity.IsCompleted = true;
                entity.Statuses = Status.Waiting;
                await Update(entity);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public override async Task<bool> Update(Supply entity, Supply newEntity=null!)
        {
            if (entity == null) return await Task.FromResult(false);

            try
            {
                entity.Statuses = newEntity.Statuses;
                entity.StartDate = newEntity.StartDate;
                entity.EndDate = newEntity.EndDate;
                entity.IsCompleted = newEntity.IsCompleted;
                entity.TotalCost = newEntity.TotalCost;
                entity.Customer = newEntity.Customer;

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
