using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services.Abstraction
{
    public interface IBaseManagement<T>
    {
        public Task<IEnumerable<T?>> GetEntities();
        public Task<T?> GetEntity(Guid id);
        public Task<bool> Add(T entity);
        public Task<bool> Update(T entity, T newEntity);
        public Task<bool> Remove(T entity);
    }
}
