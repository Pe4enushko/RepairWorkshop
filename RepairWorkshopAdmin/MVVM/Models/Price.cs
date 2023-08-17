using System;
using System.Collections.Generic;

namespace RepairWorkshopAdmin.MVVM.Models;

public partial class Price
{
    public int IdPrice { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price1 { get; set; }
}
