using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int? SenderId { get; set; }

    public int? TargetUserId { get; set; }

    public string Reason { get; set; } = null!;

    public string? ReportStatus { get; set; }

    public string? AdminNote { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public virtual User? Sender { get; set; }

    public virtual User? TargetUser { get; set; }
}
