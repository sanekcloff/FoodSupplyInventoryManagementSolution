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
        private DbController()
        {
            try
            {
                SetSqliteConnection();
                Debug.WriteLine($"{GetType().Name} created! Context type is {_appDbContext.GetType().Name}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private AppDbContext _appDbContext = null!;
        private static DbController _instance = null!;

        internal AppDbContext GetContext()
        {
            return _appDbContext;
        }
        internal static DbController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DbController();
                return _instance;
            }
            else
                return _instance;
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