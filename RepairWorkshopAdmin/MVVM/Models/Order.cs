using System;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdType { get; set; }

    public int IdOwner { get; set; }

    public string IdEmployee { get; set; } = null!;

    public DateTime Deadline { get; set; }

    public string MalfunctionDescription { get; set; } = null!;

    public string DescriptionByOwner { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual TechOwner IdOwnerNavigation { get; set; } = null!;

    public virtual TechType IdTypeNavigation { get; set; } = null!;
}
