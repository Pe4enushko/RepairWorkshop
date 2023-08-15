using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace RepairWorkshopEmployee.MVVM.Models;

public partial class Receip
{
    public int IdReceip { get; set; }
    public int? IdOrder { get; set; }

    public int? IdPrice { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Price? IdPriceNavigation { get; set; }

    string ownerName => IdOrderNavigation?.IdOwnerNavigation?.Fullname ?? "Noname";
    string device => IdOrderNavigation?.IdTypeNavigation?.Name ?? "Unknown device";
    public string OrderDesc => $"{ownerName}, {device} - {IdOrderNavigation?.MalfunctionDescription ?? "Неизвестная поломка"} | {IdPriceNavigation?.Price1.ToString() ?? "Неизвестная цена"}";

    public override string ToString()
    {
        return OrderDesc;
    }
}
