using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepairWorkshopAdmin.MVVM.Models;

public partial class Receip
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdReceip { get; set; }
    public int? IdOrder { get; set; }
    public int? IdPrice { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }
    [ForeignKey("IdPrice")]
    public virtual Price? IdPriceNavigation { get; set; }

    string ownerName => IdOrderNavigation?.IdOwnerNavigation?.Fullname ?? "Noname";
    string device => IdOrderNavigation?.IdTypeNavigation?.Name ?? "Unknown device";
    public string OrderDesc => $"{ownerName}, {device} - {IdOrderNavigation?.MalfunctionDescription ?? "Неизвестная поломка"} | {IdPriceNavigation?.Price1.ToString() ?? "Неизвестная цена"}";

    public override string ToString()
    {
        return OrderDesc;
    }
}
