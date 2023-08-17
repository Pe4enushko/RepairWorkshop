using CommunityToolkit.Mvvm.ComponentModel;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.MVVM.Models;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class OwnersViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<TechOwner> techOwners;
        protected async override void FillData()
        {
            TechOwners = await DataStorage.GetAllOwners();
        }
    }
}
