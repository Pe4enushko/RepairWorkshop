using Microsoft.EntityFrameworkCore;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepairWorkshopEmployee.DB
{
    public static class DataStorage
    {
        public static string EmployeeId;

        static RepairWorkshopContext context = new();

        public static bool AnyEmployeeWithID(string id)
            => context.Employees.Any(e => e.IdEmployee == id);
        public static int GetTechOwnerId(string ownerName)
            => context.TechOwners.First(o => o.Fullname == ownerName).IdOwner;
        public static bool AnyTechOwner(string ownerName)
            => context.TechOwners.Any(o => o.Fullname == ownerName);
        public static Price[] GetPriceList()
            => context.Prices.ToArray();

        public static Receip[] GetReceips()
            => context.Receips.ToArray();

        public static List<TechType> GetTechTypes()
            => context.TechTypes.ToList();

        /// <summary>
        /// Sends your <see cref="Order"/> into DB
        /// </summary>
        /// <param name="ord"></param>
        /// <exception cref="DbUpdateException"></exception>
        public async static Task<bool> TryMakeOrderAsync(Order ord)
        {
            try
            {
                await context.Orders.AddAsync(ord);
                return await context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.SaveChanges();
            }
            return false;
        }
        public static async Task<bool> TryAddOwnerAsync(string ownerName, string phone)
        {
            try
            {
                await context.TechOwners.AddAsync(new TechOwner() { Fullname = ownerName, Phone = phone});
                return await context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                context.SaveChanges();
            }
            return false;
        }
    }
}
