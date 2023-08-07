using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RepairWorkshopEmployee.ProgramControl
{
    public static class PageNavigation
    {
        public static MainWindow mainWindow { private get; set; }

        public static void ChangePage(Page newPage)
        {
            mainWindow.Fr_Content.Content = newPage;
        }

    }
}
