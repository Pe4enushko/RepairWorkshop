using RepairWorkshopEmployee.MVVM.Views;
using System.Windows.Controls;

namespace RepairWorkshopEmployee
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
            Fr_Owners.Content = new OwnersView();
        }
    }
}
