using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public int? RoomId { get; set; }

    public int? OwnerId { get; set; }

    public int? TenantId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public decimal DepositAmount { get; set; }

    public string? ContractStatus { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CheckOutSettlement? CheckOutSettlement { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual User? Owner { get; set; }

    public virtual Room? Room { get; set; }

    public virtual ICollection<RoomMember> RoomMembers { get; set; } = new List<RoomMember>();

    public virtual User? Tenant { get; set; }
}
