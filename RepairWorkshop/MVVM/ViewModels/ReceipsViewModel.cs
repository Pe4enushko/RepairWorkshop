using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class ReceipsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Receip selectedReceip;
        [ObservableProperty]
        Receip[] receips;
        protected async override void FillData()
        {
            Receips = await DataStorage.GetReceipsAsync();
        }
        [RelayCommand]
        void RemoveItem()
        {
            if (SelectedReceip != null)
            {
                if (ConfirmDialog())
                    Task.Run(() => { DataStorage.TryRemoveEntity(SelectedReceip).Wait(); });
            }
        }
    }
}
