using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [NotifyPropertyChangedFor(nameof(BusyVisibility))]
        [ObservableProperty]
        bool isBusy;
        public Visibility BusyVisibility { get => isBusy ? Visibility.Visible : Visibility.Hidden; }
    }
}
