using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public byte[] Image { get; set; } = null!;

        public Guid ProviderId { get; set; }

        public Provider Provider { get; set; } = null!;

        public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; } = null!;

    }
}
