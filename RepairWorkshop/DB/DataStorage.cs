using Microsoft.EntityFrameworkCore;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepairWorkshopEmployee.DB
{
    public static class DataStorage
    {
        public static string EmployeeId;

        static RepairWorkshopContext context = new();

        public static int GetTechOwnerId(string ownerName)
            => context.TechOwners.First(o => o.Fullname == ownerName).IdOwner;
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
        public async static void MakeOrderAsync(Order ord)
        {
            try
            {
                context.Orders.Add(ord);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                context.SaveChanges();
            }
        }

    }
}
