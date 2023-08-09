using RepairWorkshopEmployee.MVVM.ViewModels;
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

namespace RepairWorkshopEmployee.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddOwnerWIndow.xaml
    /// </summary>
    public partial class AddOwnerWindow : Window
    {
        public AddOwnerWindow()
        {
            InitializeComponent();

            var vm = DataContext as AddOwnerViewModel;
            vm.success += (s, e) =>
            {
                DialogResult = true;
                Close();
            };
            vm.fail += (s, e) =>
            {
                DialogResult = false;
                Close();
            };
        }
    }
}
