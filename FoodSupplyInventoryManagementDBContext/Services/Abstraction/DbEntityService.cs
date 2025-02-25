using FoodSupplyInventoryManagementDBContext.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services.Abstraction
{
    public abstract class DbEntityServiceBase<T>
    {
        protected readonly AppDbContext ctx;
        public DbEntityServiceBase()
        {
            ctx = new DbController().GetContext();
        }
        public abstract Task<bool> Add(T entity);
        public abstract Task<bool> Update(T entity);
        public abstract Task<bool> Remove(T entity);
    }
}
