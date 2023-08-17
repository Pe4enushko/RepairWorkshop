using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin.MVVM.ViewModels
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
            if (Phone.Length != 11)
            {
                MessageBox.Show("Номер телефона не валиден");
                return;
            }

            IsBusy = true;
            if (ConfirmDialog()
                    && await DataStorage.TryAddOwnerAsync(OwnerName, Phone))
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
        void Cancel()
        {
            fail?.Invoke(this, EventArgs.Empty);
        }
    }
}
