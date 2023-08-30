using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class TechType
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdType { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public override string ToString()
    {
        return Name;
    }
}
