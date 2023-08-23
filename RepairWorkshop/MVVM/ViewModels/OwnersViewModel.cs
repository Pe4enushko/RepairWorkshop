using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Data.SqlClient;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class OwnersViewModel : BaseViewModel
    {
        [ObservableProperty]
        TechOwner selectedOwner;
        [ObservableProperty]
        List<TechOwner> techOwners;
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
                if (ConfirmDialog())
                {
                    IsBusy = true;

                    try
                    {
                        await DataStorage.TryRemoveEntity(SelectedOwner);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Клиент не может быть удалён, т.к., скорее всего, на нём уже завязаны какие-то заказы или чеки.\nСообщение: " + e.InnerException.Message ?? e.Message);
                    }
                    IsBusy = false;
                }
            }
        }
    }
}
