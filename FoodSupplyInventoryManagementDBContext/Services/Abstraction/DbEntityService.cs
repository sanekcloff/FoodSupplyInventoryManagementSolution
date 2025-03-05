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

        public abstract Task<IEnumerable<T>> GetEntities();
        public abstract Task<T> GetEntity(Guid id);
        public abstract Task<bool> Add(T entity);
        public abstract Task<bool> Update(T entity, T newEntity);
        public abstract Task<bool> Remove(T entity);
    }
}
