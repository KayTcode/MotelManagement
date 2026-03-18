using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Medium
{
    public int MediaId { get; set; }

    public string CloudinaryUrl { get; set; } = null!;

    public string? CloudinaryPublicId { get; set; }

    public string? MediaType { get; set; }

    public int? RelatedId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
