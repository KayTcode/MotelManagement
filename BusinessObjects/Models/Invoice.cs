using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly InvoiceDate { get; set; }

    public int? ElectricityUsage { get; set; }

    public int? WaterUsage { get; set; }

    public decimal? ServiceFee { get; set; }

    public decimal TotalAmount { get; set; }

    public bool? IsPaid { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Contract? Contract { get; set; }
}
