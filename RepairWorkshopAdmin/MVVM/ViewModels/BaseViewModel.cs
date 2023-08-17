using CommunityToolkit.Mvvm.ComponentModel;
using RepairWorkshopAdmin.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin.MVVM.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [NotifyPropertyChangedFor(nameof(BusyVisibility))]
        [ObservableProperty]
        bool isBusy;
        public Visibility BusyVisibility { get => IsBusy ? Visibility.Visible : Visibility.Hidden; }

        public BaseViewModel()
        {
            FillData();
            DataStorage.DataAdded += UpdateData;   
        }

        /// <summary>
        /// Подтверждение
        /// </summary>
        /// <returns></returns>
        protected bool ConfirmDialog()
            => MessageBox.Show("Подтвердите действие",
                "Уверены?",
                MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        /// <summary>
        /// Вызывается при добавлении чего-либо в БД со стороны клиента
        /// </summary>
        protected virtual void UpdateData()
        {
            FillData();
        }

        protected virtual void FillData()
        {

        }
    }
}
