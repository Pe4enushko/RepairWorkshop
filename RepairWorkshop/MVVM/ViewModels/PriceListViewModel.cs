﻿using CommunityToolkit.Mvvm.ComponentModel;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class PriceListViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<Price> prices;
        protected async override void FillData()
        {
            Prices = await DataStorage.GetPriceListAsync();
        }
    }
}
