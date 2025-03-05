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
        public override async Task<bool> Add(Customer entity)
        {
            // Проверка null
            if (entity == null) return await Task.FromResult(false);

            // Проверка на пустой Guid
            if (entity.Id == Guid.Empty) return await Task.FromResult(false);

            // проверка на ввод ФИО
            if (string.IsNullOrEmpty(entity.Firstname)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Lastname)) return await Task.FromResult(false);

            // проверка организации
            if (string.IsNullOrEmpty(entity.Organization)) return await Task.FromResult(false);

            // проверка логина и пароля
            if (string.IsNullOrEmpty(entity.Login)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(entity.Password)) return await Task.FromResult(false);

            // добавление в бд
            try
            {
                await ctx.AddAsync(entity);
                Debug.WriteLine($"{GetType().Name}: entity was added!");
                await ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: entity was saved!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: {ex.Message}");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        public override async Task<IEnumerable<Customer>> GetEntities() => await Task.FromResult(ctx.Customers.ToList() as IEnumerable<Customer>);

        public override async Task<Customer> GetEntity(Guid id) => await Task.FromResult(ctx.Customers.Single(c => c.Id == id));

        public override async Task<bool> Update(Customer entity, Customer newEntity)
        {
            if (entity == null) return await Task.FromResult(false);
            if (newEntity == null) return await Task.FromResult(false);

            // проверка новых значений
            // Проверка на пустой Guid
            if (newEntity.Id == Guid.Empty) return await Task.FromResult(false);

            // проверка на ввод ФИО
            if (string.IsNullOrEmpty(newEntity.Firstname)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(newEntity.Lastname)) return await Task.FromResult(false);

            // проверка организации
            if (string.IsNullOrEmpty(newEntity.Organization)) return await Task.FromResult(false);

            // проверка логина и пароля
            if (string.IsNullOrEmpty(newEntity.Login)) return await Task.FromResult(false);
            if (string.IsNullOrEmpty(newEntity.Password)) return await Task.FromResult(false);

            // обновление данных
            try
            {
                // Изменение данных
                entity.Firstname = newEntity.Firstname;
                entity.Lastname = newEntity.Lastname;
                entity.Middlename = newEntity.Middlename;
                entity.Organization = newEntity.Organization;
                entity.Login = newEntity.Login;
                entity.Password = newEntity.Password;

                // Сохранение в бд
                ctx.Update(entity);
                Debug.WriteLine($"{GetType().Name}: entity updated!");
                await ctx.SaveChangesAsync();
                Debug.WriteLine($"{GetType().Name}: changes saved!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name}: {ex.Message}");
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
