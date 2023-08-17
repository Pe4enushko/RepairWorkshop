using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkshopAdmin.DB
{
    public static class Extensions
    {
        public static void FillObservableCollection<T>(this ObservableCollection<T> destination, List<T> source)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                foreach (var item in source)
                {
                    destination.Add(item);
                }
            });
        }
    }
}
