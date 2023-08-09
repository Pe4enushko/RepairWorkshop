using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using RepairWorkshopEmployee.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
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

        public MakeOrderViewModel() 
        {
            techTypes.FillObservableCollection(
                (List<TechType>)DataStorage.GetTechTypes());
        }

        [RelayCommand]
        async void SendData()
        {
            IsBusy = true;
            if (!DataStorage.AnyTechOwner(OwnerName))
            {
                var aow = new AddOwnerWindow();
                aow.ShowDialog();

                if (!aow.DialogResult ?? false)
                {
                    IsBusy = false;
                    return;
                }
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
            
            IsBusy = false;

        }
    }
}
