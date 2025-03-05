using FoodSupplyInventoryManagementDBContext.Services.Abstraction;
using FoodSupplyInventoryManagementLib.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services
{
    public class SupplyService : DbEntityServiceBase<Supply>, ISupplyManagment<Supply>
    {
        public override Task<bool> Add(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Cancel(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Execute(Supply entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Supply>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public override Task<Supply> GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Remove(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetStatusCompleted(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetStatusInProgress(Supply entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetStatusWaiting(Supply entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(Supply entity, Supply newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
