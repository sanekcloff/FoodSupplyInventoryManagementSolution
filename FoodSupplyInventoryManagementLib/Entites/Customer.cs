using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Middlename { get; set; } = null!;
        public string Organization { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public IEnumerable<Supply> Supplies { get; set; } = null!;

        [NotMapped]
        public string Fullname
        {
            get
            {
                if (Middlename != null)
                {
                    return $"{Lastname} {Firstname} {Middlename}";
                }
                else
                {
                    return $"{Lastname} {Firstname}";
                }
            }
        }
        public string Shortname
        {
            get
            {
                if (Middlename != null)
                {
                    return $"{Lastname} {Firstname[0]}. {Middlename[0]}.";
                }
                else
                {
                    return $"{Lastname} {Firstname[0]}.";
                }
            }
        }

        public override string ToString()
        {
            return $"{Organization} - {Shortname} ";
        }
    }
}
