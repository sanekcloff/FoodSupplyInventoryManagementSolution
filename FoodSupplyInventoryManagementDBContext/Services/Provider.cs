﻿using FoodSupplyInventoryManagementDBContext.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services
{
    public class Provider : DbEntityServiceBase<Provider>
    {
        public override Task<bool> Add(Provider entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Remove(Provider entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(Provider entity)
        {
            throw new NotImplementedException();
        }
    }
}
