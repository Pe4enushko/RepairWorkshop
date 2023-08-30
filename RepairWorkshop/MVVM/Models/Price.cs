using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Price
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPrice { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price1 { get; set; }
}
