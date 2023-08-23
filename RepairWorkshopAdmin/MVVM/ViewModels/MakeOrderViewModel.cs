using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using RepairWorkshopAdmin.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class MakeOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<TechType> techTypes = new();
        [ObservableProperty]
        string ownerName;
        [ObservableProperty]
        DateTime deadline;
        [ObservableProperty]
        string malfunctionDescription;
        [ObservableProperty]
        string ownerDescription;

        [ObservableProperty]
        TechType selectedTechType;

        protected async override void FillData()
        {
            TechTypes.FillObservableCollection(
                await DataStorage.GetTechTypesAsync());
        }

        [RelayCommand]
        async Task SendData()
        {
            if (ConfirmDialog())
            {
                IsBusy = true;
                if (!DataStorage.AnyTechOwner(OwnerName))
                {
                    var aow = new AddOwnerWindow();
                    aow.ShowDialog();

                    if (!aow.DialogResult ?? false)
                    {
                        IsBusy = false;
                    }

                    OwnerName = aow.vm.OwnerName;

                    return;
                }
            
                Order order = new()
                {
                    DescriptionByOwner = ownerDescription,
                    MalfunctionDescription = malfunctionDescription,
                    Deadline = Deadline,
                    IdOwner = DataStorage.GetTechOwnerId(OwnerName),
                    IdEmployee = DataStorage.EmployeeId,
                    IdType = SelectedTechType.IdType
                };

                if (await DataStorage.TryMakeOrderAsync(order))
                {
                    MessageBox.Show("Заказ создан");

                    OwnerDescription = string.Empty;
                    MalfunctionDescription = string.Empty;
                    OwnerName = string.Empty;
                }
                else
                    MessageBox.Show("Заказ не был создан");

                IsBusy = false;
            }
        }
    }
}
