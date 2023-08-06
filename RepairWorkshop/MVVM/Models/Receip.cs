using System;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Receip
{
    public int? IdOrder { get; set; }

    public int? IdPrice { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Price? IdPriceNavigation { get; set; }
}
