using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class Provider
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public IEnumerable<Product> Products { get; set; } = null!;

        public override string ToString()
        {
            return $"{Title} - {Description}\n{Email}\n{Phone}";
        }
    }
}
