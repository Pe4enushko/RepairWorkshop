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
    /// Interaction logic for AddPriceWindow.xaml
    /// </summary>
    public partial class AddPriceWindow : Window
    {
        AddPriceViewModel vm;
        public AddPriceWindow()
        {
            InitializeComponent();

            vm = DataContext as AddPriceViewModel;
            vm.success += (s, e) =>
            {
                DialogResult = true;
                Close();
                MessageBox.Show("Цена добавлена");
            };
            vm.fail += (s, e) =>
            {
                DialogResult = false;
                Close();
                MessageBox.Show("Цена не была добавлена");
            };
        }
    }
}
