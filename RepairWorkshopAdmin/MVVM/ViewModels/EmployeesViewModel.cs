using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class EmployeesViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<Employee> employees;
        [ObservableProperty]
        Employee selectedEmployee;

        protected async override void FillData()
        {
            Employees = await DataStorage.GetAllEmployees();
        }

        [RelayCommand]
        void AddItem()
        {
            var window = new AddEmployeeWindow();
            window.ShowDialog();
        }
        [RelayCommand]
        void RemoveItem()
        {
            if (SelectedEmployee != null)
            {
                Task.Run(() =>
                {
                    DataStorage.TryRemoveEntity(SelectedEmployee).Wait();
                });
            }
        }
    }
}
