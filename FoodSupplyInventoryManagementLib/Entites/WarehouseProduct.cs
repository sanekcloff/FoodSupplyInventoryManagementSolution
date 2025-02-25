using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class WarehouseProduct
    {
        public Guid Id { get; set; }
        
        public short Amount { get; set; }

        public Guid WarehouseId { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;
        public Warehouse Warehouse { get; set; } = null!;

    }
}
