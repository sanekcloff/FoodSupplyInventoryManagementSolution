﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services.Abstraction
{
    public interface ISupplyManagment<T>
    {
        public Task<bool> Execute(T entity);
        public Task<bool> Cancel(T entity);
        public Task<bool> SetStatusWaiting(T entity);
        public Task<bool> SetStatusInProgress(T entity);
        public Task<bool> SetStatusCompleted(T entity);
    }
}
