using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class FinishOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Order> orders;
        [ObservableProperty]
        ObservableCollection<Price> prices;

        [ObservableProperty]
        Order selectedOrder;
        [ObservableProperty]
        Price selectedPrice;
        public FinishOrderViewModel()
        {
            FillData();
        }
        [RelayCommand]
        async Task SendData()
        {
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
        }

        /// <summary>
        /// Вызывается после того, как данные отправлены
        /// </summary>
        void Sent()
        { 
            UpdateData();
            MessageBox.Show("Чек пробит");
        }
        async void UpdateData()
        {

        }
        async void FillData()
        {
            Orders = new ObservableCollection<Order>(await DataStorage.GetUnpaidOrdersAsync());
            Prices = new ObservableCollection<Price>(await DataStorage.GetPriceListAsync());
        }
    }
}
