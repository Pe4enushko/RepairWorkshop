using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class OrderListViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<Order> orders;
        [ObservableProperty]
        Order selectedOrder;
        public OrderListViewModel() : base()
        {}
        protected async override void FillData()
        {
            Orders = await DataStorage.GetAllOrders();
        }
        [RelayCommand]
        void RemoveItem()
        {
            Task.Run(() =>
            {
                DataStorage.TryRemoveEntity(SelectedOrder).Wait();
            });
        }
    }
}
