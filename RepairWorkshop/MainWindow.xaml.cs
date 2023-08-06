using RepairWorkshopEmployee.MVVM.Views;
using System.Windows;
using System.Windows.Controls;

namespace RepairWorkshopEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Fr_MakeOrder.Content = new MakeOrderView();
            Fr_PriceList.Content = new PriceListView();
            Fr_Receips.Content = new ReceipsView();
        }
    }
}
