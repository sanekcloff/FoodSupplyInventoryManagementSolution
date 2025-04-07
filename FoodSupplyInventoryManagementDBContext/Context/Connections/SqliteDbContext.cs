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
            var tempSolutionPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.ToString(), "FoodSupplyInventoryManagementDBContext", _folderName);
            if (!Directory.Exists(tempSolutionPath))
            {
                Directory.CreateDirectory(tempSolutionPath);
                Debug.WriteLine($"{_folderName} was created in {tempSolutionPath}!");
            }
            var fullPath = Path.Combine(tempSolutionPath, _fileName);
            _connectionString = $"Data Source = {fullPath}";
            if (!File.Exists(fullPath))
            {
                Database.EnsureCreated();
                Debug.WriteLine($"{this.GetType().Name} was created in {tempSolutionPath}!");
            }
            else
            {
                Debug.WriteLine($"{this.GetType().Name} was connected to {tempSolutionPath}!");
            }

        }
        private const string _folderName = "LocalData";
        private const string _fileName = "localDb.db";
        private string _connectionString = "Data source = local.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlite(_connectionString));
        }
    }
}
