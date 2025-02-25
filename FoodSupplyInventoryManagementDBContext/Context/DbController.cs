using FoodSupplyInventoryManagementDBContext.Context.Connections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Context
{
    internal class DbController
    {
        internal DbController(bool useSqlite = false)
        {
            try
            {
                if (useSqlite)
                {
                    _appDbContext = new SqliteDbContext();
                }
                else
                {
                    _appDbContext = new SqlServerDbContext();
                }
                Debug.WriteLine($"{this.GetType().Name} created! Context type is {_appDbContext.GetType().Name}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private AppDbContext _appDbContext = null!;

        internal AppDbContext GetContext()
        {
            return _appDbContext;
        }
        internal void SetSqliteConnection()
        {
            _appDbContext = new SqliteDbContext();
        }
        internal void SetSqlServerConnection()
        {
            _appDbContext = new SqlServerDbContext();
        }
    }
}
