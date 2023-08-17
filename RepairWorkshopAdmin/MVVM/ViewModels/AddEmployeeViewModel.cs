using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using RepairWorkshopAdmin.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class AddEmployeeViewModel : BaseViewModel
    {
        public event EventHandler success;
        public event EventHandler fail;

        [ObservableProperty]
        string id;
        [ObservableProperty]
        string phone;
        [ObservableProperty]
        string fullName;
        [ObservableProperty]
        string address;

        [RelayCommand]
        public async Task AddItem()
        {
            if (Phone.Length != 11)
            {
                MessageBox.Show("Номер телефона не валиден");
                return;
            }

            IsBusy = true;
            if (ConfirmDialog()
                    && await DataStorage.TryAddEmployeeAsync(new Employee()
                    {
                        IdEmployee = Id,
                        Fullname = this.FullName,
                        Phone = this.Phone,
                        Address = this.Address
                    }))
            {
                success?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                fail?.Invoke(this, EventArgs.Empty);
            }
            IsBusy = false;
        }
        [RelayCommand]
        public void Cancel()
        {
            fail?.Invoke(this, EventArgs.Empty);
        }
    }
}
