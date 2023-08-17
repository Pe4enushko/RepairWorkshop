using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.MVVM.Views;
using System.Windows.Controls;

namespace RepairWorkshopAdmin
{
    /// <summary>
    /// Interaction logic for MainContentPage.xaml
    /// </summary>
    public partial class MainContentPage : Page
    {
        public MainContentPage()
        {
            InitializeComponent();

            Fr_MakeOrder.Content = new MakeOrderView();
            Fr_PriceList.Content = new PriceListView();
            Fr_Receips.Content = new ReceipsView();
            Fr_PayOrder.Content = new FinishOrderView();
            Fr_Employees.Content = new EmployeesPage();
            Fr_Orders.Content = new OrderListPage();
        }
    }
}
