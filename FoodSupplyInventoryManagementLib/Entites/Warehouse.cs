using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class Warehouse
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;

        public IEnumerable<WarehouseProduct> WarehouseProducts { get; set; } = null!;
    }
}
