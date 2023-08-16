using System;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Employee
{
    public string IdEmployee { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
