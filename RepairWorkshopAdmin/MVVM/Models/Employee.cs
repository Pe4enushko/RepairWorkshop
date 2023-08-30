using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairWorkshopAdmin.MVVM.Models;

public partial class Employee
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string IdEmployee { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
