using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Context.Connections
{
    public class SqliteDbContext : AppDbContext
    {
        public SqliteDbContext()
        {
            Debug.WriteLine($"{this.GetType().Name} was created!");
        }
        private const string _connectionString = "Data Source = localDb.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite(_connectionString));
        }
    }
}
