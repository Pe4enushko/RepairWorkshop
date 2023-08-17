using RepairWorkshopAdmin.MVVM.Views;
using RepairWorkshopAdmin.ProgramControl;
using System.Windows;
using System.Windows.Controls;

namespace RepairWorkshopAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PageNavigation.mainWindow = this;
            Fr_Content.Content = new AuthView();
        }
    }
}
