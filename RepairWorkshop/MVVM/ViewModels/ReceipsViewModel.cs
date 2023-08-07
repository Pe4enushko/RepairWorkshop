using CommunityToolkit.Mvvm.ComponentModel;
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
        Receip[] receips;
        public ReceipsViewModel()
        {
            receips = DataStorage.GetReceips();
        }
    }
}
