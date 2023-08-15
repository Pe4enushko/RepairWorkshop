using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Data.SqlClient;
using RepairWorkshopEmployee.DB;
using RepairWorkshopEmployee.ProgramControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopEmployee.MVVM.ViewModels
{
    public partial class AuthViewModel : BaseViewModel
    {
        public Visibility FailVisibility => Failed ? Visibility.Visible : Visibility.Hidden;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FailVisibility))]
        bool failed = false;
        [ObservableProperty]
        string id;

        [RelayCommand]
        async void TryAuth()
        {
            IsBusy = true;
            await Task.Run(() =>
            {
                try
                {
                    if (DataStorage.AnyEmployeeWithID(id))
                    {
                        DataStorage.EmployeeId = Id;
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            IsBusy = false;
                            PageNavigation.ChangePage(new MainContentPage());
                        });
                    }
                    else
                    {
                        Failed = true;
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Проблемы с базой данных. Сообщение: {ex.Message}");
                }
            }).ContinueWith(a =>
            {
                IsBusy = false;
            });
        }
    }
}
