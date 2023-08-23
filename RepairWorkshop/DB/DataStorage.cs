using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RepairWorkshopEmployee.DB
{
    public static class DataStorage
    {
        public delegate void DataAddHandler();
        public static event DataAddHandler DataAdded;
        static object locker = new();
        static bool locked = false;
        public static string EmployeeId = "";

        #region Get things
        public static bool AnyEmployeeWithID(string id)
        {
            using (var context = new RepairWorkshopContext()) 
                return context.Employees.Any(e => e.IdEmployee == id);
        }
        public static int GetTechOwnerId(string ownerName)
        {
            using (var context = new RepairWorkshopContext())
                return context.TechOwners.First(o => o.Fullname == ownerName).IdOwner;
        }
        public static bool AnyTechOwner(string ownerName)
        {
            using (var context = new RepairWorkshopContext())
                return context.TechOwners.Any(o => o.Fullname == ownerName);
        }
        public async static Task<List<TechOwner>> GetAllOwners()
        {
            using (var context = new RepairWorkshopContext())
                return await context.TechOwners.ToListAsync();
        }
        public async static Task<List<Price>> GetPriceListAsync()
        {
            using (var context = new RepairWorkshopContext())
            {
                try
                {
                    return await context.Prices.ToListAsync();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }
        public static async Task<Receip[]> GetReceipsAsync()
        {
            using (var context = new RepairWorkshopContext())
                return await context.Receips
                    .Include(r => r.IdOrderNavigation)
                    .Include(r => r.IdPriceNavigation)
                    .Include(r => r.IdOrderNavigation.IdOwnerNavigation)
                    .Include(r => r.IdOrderNavigation.IdTypeNavigation)
                    .ToArrayAsync();
        }
        public static async Task<List<TechType>> GetTechTypesAsync()
        {
            using (var context = new RepairWorkshopContext())
                return await context.TechTypes.ToListAsync();
        }
        public static async Task<List<Order>> GetUnpaidOrdersAsync()
        {
            using (var context = new RepairWorkshopContext())
            {
                // I really hope this works
                return await context.Orders
                    .FromSqlRaw("SELECT Orders.* " +
                                "FROM Orders " +
                                "WHERE Orders.id_order NOT IN (SELECT id_order FROM Receips)")
                    .Include(o => o.IdOwnerNavigation)
                    .Include(o => o.IdTypeNavigation)
                    .ToListAsync();
            }
        }
        #endregion
        #region Send things
        /// <summary>
        /// Sends your <see cref="Order"/> into DB
        /// </summary>
        /// <param name="ord"></param>
        /// <exception cref="DbUpdateException"></exception>
        public async static Task<bool> TryMakeOrderAsync(Order ord)
        {
            using (var context = new RepairWorkshopContext())
            {
                context.Orders.Add(ord);
                return await SureSaveAsync(context);
            }
        }
        public async static Task<bool> TryAddOwnerAsync(string ownerName, string phone)
        {
            if (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(phone))
                return false;

            using (var context = new RepairWorkshopContext())
            {
                context.TechOwners.Add(new TechOwner() { Fullname = ownerName, Phone = phone });
                return await SureSaveAsync(context);
            }
        }
        public async static Task<bool> TryMakeReceipAsync(Order order, Price price)
        {
            using (var context = new RepairWorkshopContext())
            {
                if (OrderHasReceip(order))
                return false;

                Receip data = new Receip()
                {
                    IdOrder = order.IdOrder,
                    IdPrice = price.IdPrice
                };

                context.Receips.Add(data);

                return await SureSaveAsync(context);
            }
        }
        async static Task<bool> SureSaveAsync(RepairWorkshopContext context)
        {
            bool success;
            try
            {
                success = await context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                success = context.SaveChanges() > 0;
            }

            if (success)
                DataAdded?.Invoke();
            
            return success;
        }
         
        static bool OrderHasReceip(Order order)
        {
            using (var context = new RepairWorkshopContext())
                return context.Receips.Any(r => r.IdOrder == order.IdOrder);
        }
        #endregion
        public async static Task<bool> TryRemoveEntity(object entity)
        {
            using (var context = new RepairWorkshopContext())
            {
                if (entity == null)
                    return false;

                // I've tried switch/case but there were problems
                if (entity is Employee)
                    context.Employees.Remove(entity as Employee);
                else if (entity is Order)
                    context.Orders.Remove(entity as Order);
                else if (entity is Price)
                    context.Prices.Remove(entity as Price);
                else if (entity is Receip)
                    context.Receips.Remove(entity as Receip);
                else if (entity is TechOwner)
                    context.TechOwners.Remove(entity as TechOwner);
                else if (entity is TechType)
                    context.TechTypes.Remove(entity as TechType);

                return await SureSaveAsync(context);
            }
        }
    }
}
