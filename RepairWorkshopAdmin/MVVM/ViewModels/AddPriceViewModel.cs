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

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class AddPriceViewModel : BaseViewModel
    {
        public event EventHandler success;
        public event EventHandler fail;

        [ObservableProperty]
        string name = "";
        [ObservableProperty]
        string description = "";
        [ObservableProperty]
        string cost = "";

        [RelayCommand]
        async Task AddPrice()
        {
            IsBusy = true;
            if (ConfirmDialog()
                    && await DataStorage.TryAddEntity(new Price() 
                    { 
                        Description = this.Description,
                        Name = this.Name,
                        Price1 = Convert.ToDecimal(Cost)
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
        void Cancel()
        {
            fail?.Invoke(this, EventArgs.Empty);
        }
    }
}
