using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
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

        public MakeOrderViewModel() 
        {
            techTypes.FillObservableCollection(
                DataStorage.GetTechTypes());
        }

        [RelayCommand]
        void SendData()
        {
            Order order = new()
            {
                DescriptionByOwner = ownerDescription,
                MalfunctionDescription = malfunctionDescription,
                Deadline = Deadline,
                IdOwner = DataStorage.GetTechOwnerId(OwnerName),
                IdEmployee = DataStorage.EmployeeId
            };
        }
    }
}
