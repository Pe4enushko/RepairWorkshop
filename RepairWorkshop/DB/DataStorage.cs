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
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RepairWorkshopEmployee.DB
{
    public static class DataStorage
    {
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
        public async static Task<List<Price>> GetPriceListAsync()
        {
            using (var context = new RepairWorkshopContext())
                return await context.Prices.ToListAsync();
        }
        public static Receip[] GetReceips()
        {
            using (var context = new RepairWorkshopContext())
                return context.Receips.ToArray();
        }
        public static List<TechType> GetTechTypes()
        {
            using (var context = new RepairWorkshopContext())
                return context.TechTypes.ToList();
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

                context.Receips.Add(new Receip() 
                    { 
                        IdOrder = order.IdOrder, 
                        IdPrice = price.IdPrice
                    });
                return await SureSaveAsync(context);
            }
        }
        async static Task<bool> SureSaveAsync(RepairWorkshopContext context)
        {
            try
            {
                return await context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.SaveChanges();
            }
            return false;
        }
        static bool SureSave(RepairWorkshopContext context)
            => context.SaveChanges() > 0;
         
        static bool OrderHasReceip(Order order)
        {
            using (var context = new RepairWorkshopContext())
                return context.Receips.Any(r => r.IdOrder == order.IdOrder);
        }
        #endregion
    }
}
