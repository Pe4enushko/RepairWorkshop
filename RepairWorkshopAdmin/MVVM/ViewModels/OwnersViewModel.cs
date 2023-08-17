using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.DB;
using RepairWorkshopAdmin.MVVM.Models;
using RepairWorkshopAdmin.MVVM.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class OwnersViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<TechOwner> techOwners;
        [ObservableProperty]
        TechOwner selectedOwner;
        protected async override void FillData()
        {
            TechOwners = await DataStorage.GetAllOwners();
        }
        [RelayCommand]
        public void AddItem()
        {
            var window = new AddOwnerWindow();
            window.ShowDialog();
        }
        [RelayCommand]
        void RemoveItem()
        {
            if (SelectedOwner != null)
            {
                Task.Run(() => { DataStorage.TryRemoveEntity(SelectedOwner).Wait(); });
            }
        }
    }
}
