using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using RepairWorkshopAdmin.MVVM.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class OwnersViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<TechOwner> techOwners;
        [ObservableProperty]
        TechOwner selectedOwner;
        protected async override void FillData()
        {
            TechOwners = await DataStorage.GetAllOwners();
        }
        [RelayCommand]
        public void AddItem()
        {
            var window = new AddOwnerWindow();
            window.ShowDialog();
        }
        [RelayCommand]
        async Task RemoveItem()
        {
            if (SelectedOwner != null)
            {
                IsBusy = true;

                try
                {
                    await DataStorage.TryRemoveEntity(SelectedOwner);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Клиент не может быть удалён, т.к., скорее всего, на нём уже завязаны какие-то заказы или чеки.\nСообщение: " + e.InnerException?.Message ?? e.Message);
                }
                IsBusy = false;
            }
        }
    }
}
