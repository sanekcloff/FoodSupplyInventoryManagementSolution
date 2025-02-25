using FoodSupplyInventoryManagementDBContext.Services.Abstraction;
using FoodSupplyInventoryManagementLib.Entites;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementDBContext.Services
{
    public class CustomerService : DbEntityServiceBase<Customer>
    {
        public override Task<bool> Add(Customer entity)
        {
            // Проверка null
            if (entity == null) return Task.FromResult(false);

            // Проверка на пустой Guid
            if (entity.Id == Guid.Empty) return Task.FromResult(false);

            // проверка на ввод ФИО
            if (string.IsNullOrEmpty(entity.Firstname)) return Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Lastname)) return Task.FromResult(false);

            // проверка организации
            if (string.IsNullOrEmpty(entity.Organization)) return Task.FromResult(false);

            // проверка логина и пароля
            if (string.IsNullOrEmpty(entity.Login)) return Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Password)) return Task.FromResult(false);

            // добавление в бд
            try
            {
                ctx.AddAsync(entity);
                Debug.WriteLine($"{GetType().Name}: entity was added!");
                ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: entity was saved!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: {ex.Message}");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public override Task<bool> Remove(Customer entity)
        {
            if (entity == null) return Task.FromResult(false);

            // удаление из бд

            return Task.FromResult(true);
        }

        public override Task<bool> Update(Customer entity)
        {
            if (entity == null) return Task.FromResult(false);

            // обновление данных

            return Task.FromResult(true);
        }
    }
}
