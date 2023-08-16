using System;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class TechOwner
{
    public int IdOwner { get; set; }

    public string Fullname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
