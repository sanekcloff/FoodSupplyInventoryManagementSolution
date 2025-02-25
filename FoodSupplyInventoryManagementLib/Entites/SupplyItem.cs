using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class SupplyItem
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public Guid SupplyId { get; set; }

        public Supply Supply { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public short Amount { get; set; }
    }
}
