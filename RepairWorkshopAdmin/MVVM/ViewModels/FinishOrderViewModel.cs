﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class FinishOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<char> message = new List<char>("Отправить".ToCharArray());
        [ObservableProperty]
        List<Order> orders;
        [ObservableProperty]
        List<Price> prices;

        [ObservableProperty]
        Order selectedOrder;
        [ObservableProperty]
        Price selectedPrice;
        public FinishOrderViewModel() : base()
        {
            FillData();
        }
        [RelayCommand]
        async Task SendData()
        {
            IsBusy = true;
            if (SelectedOrder == null || SelectedPrice == null)
            {
                MessageBox.Show("Сначала, нужно выбрать заказ и цену");
            }
            else
            {
                if (ConfirmDialog()
                        && await DataStorage.TryMakeReceipAsync(SelectedOrder, SelectedPrice))
                    Sent();
            }
            IsBusy = false;
        }

        /// <summary>
        /// Вызывается после того, как данные отправлены
        /// </summary>
        void Sent()
        { 
            UpdateData();
            MessageBox.Show("Чек пробит");
        }
        protected async override void FillData()
        {
            Orders = await DataStorage.GetUnpaidOrdersAsync();
            Prices = await DataStorage.GetPriceListAsync();
        }
    }
}
