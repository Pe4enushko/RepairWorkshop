using System;
using System.Collections.Generic;

namespace RepairWorkshopAdmin.MVVM.Models;

public partial class TechType
{
    public int IdType { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public override string ToString()
    {
        return Name;
    }
}
