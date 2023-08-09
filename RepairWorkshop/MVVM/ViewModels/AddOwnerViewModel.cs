using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopEmployee.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class AddOwnerViewModel : BaseViewModel
    {
        public event EventHandler success;
        public event EventHandler fail;

        [ObservableProperty]
        string phone;
        [ObservableProperty]
        string ownerName;

        [RelayCommand]
        async Task AddOwner()
        {
            IsBusy = true;
            if (ConfirmDialog() 
                    && DataStorage.TryAddOwner(OwnerName, Phone))
                success?.Invoke(this, EventArgs.Empty);
            else
            {
                MessageBox.Show("Owner addition failed");
                fail?.Invoke(this, EventArgs.Empty);
            }
            IsBusy = false;
        }
        [RelayCommand]
        void Cancel()
        {
            fail?.Invoke(this, EventArgs.Empty);
        }
    }
}
