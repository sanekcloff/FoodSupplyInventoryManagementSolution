using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Context.Connections
{
    public class SqlServerDbContext : AppDbContext
    {
        public SqlServerDbContext()
        {
            Debug.WriteLine($"{this.GetType().Name} was created!");
        }
        private const string _connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = SupplyManagementDB";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(_connectionString));
        }
    }
}
