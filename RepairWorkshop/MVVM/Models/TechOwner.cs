using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class TechOwner
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdOwner { get; set; }

    public string Fullname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
