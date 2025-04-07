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
        public byte[]? Image { get; set; } = null!;

        public Guid SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; } = null!;

        public virtual IEnumerable<WarehouseProduct> WarehouseProducts { get; set; } = null!;
        public virtual IEnumerable<SupplyItem> SupplyItems { get; set; } = null!;

        public override string ToString()
        {
            var imageInf = Image != null ? Image.Length : 0;
            return $"{Title}: {Description} - {Cost} ({Discount}) [{Supplier.ToString()}] - [{imageInf}]";
        }

    }
}
