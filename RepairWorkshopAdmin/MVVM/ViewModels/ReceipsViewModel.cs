using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class ReceipsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Receip[] receips;
        [ObservableProperty]
        Receip selectedReceip;
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
