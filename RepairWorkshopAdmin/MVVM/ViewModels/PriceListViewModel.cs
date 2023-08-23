using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class PriceListViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<Price> prices;
        [ObservableProperty]
        Price selectedPrice;
        protected async override void FillData()
        {
            Prices = await DataStorage.GetPriceListAsync();
        }
        [RelayCommand]
        public void AddItem()
        {
            var window = new AddPriceWindow();
            window.ShowDialog();
        }
        [RelayCommand]
        void RemoveItem()
        {
            if (ConfirmDialog())
                Task.Run(() => { DataStorage.TryRemoveEntity(SelectedPrice).Wait(); });
        }
    }
}
