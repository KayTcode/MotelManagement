using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class CheckOutSettlement
{
    public int SettlementId { get; set; }

    public int? ContractId { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public decimal? DamageFee { get; set; }

    public string? DamageNotes { get; set; }

    public decimal? FinalRefundAmount { get; set; }

    public bool? IsCompleted { get; set; }

    public virtual Contract? Contract { get; set; }
}
