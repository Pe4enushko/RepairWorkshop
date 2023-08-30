using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdOrder { get; set; }

    public int IdType { get; set; }

    public int IdOwner { get; set; }

    public string IdEmployee { get; set; } = null!;

    public DateTime Deadline { get; set; }

    public string MalfunctionDescription { get; set; } = null!;

    public string DescriptionByOwner { get; set; } = null!;
    [ForeignKey("IdEmployee")]
    public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    [ForeignKey("IdOwner")]
    public virtual TechOwner IdOwnerNavigation { get; set; } = null!;
    [ForeignKey("IdTechType")]
    public virtual TechType IdTypeNavigation { get; set; } = null!;
}
