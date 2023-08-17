using RepairWorkshopAdmin.MVVM.ViewModels;
using RepairWorkshopAdmin.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RepairWorkshopAdmin.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        AddEmployeeViewModel vm;
        public AddEmployeeWindow()
        {
            InitializeComponent();

            vm = DataContext as AddEmployeeViewModel;

            vm.success += (s, e) =>
            {
                DialogResult = true;
                Close();
                MessageBox.Show("Владелец добавлен");
            };
            vm.fail += (s, e) =>
            {
                DialogResult = false;
                Close();
                MessageBox.Show("Владелец не был добавлен");
            };
        }
    }
}
