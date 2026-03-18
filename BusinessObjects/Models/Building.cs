using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Building
{
    public int BuildingId { get; set; }

    public int? OwnerId { get; set; }

    public string BuildingName { get; set; } = null!;

    public string AddressDetail { get; set; } = null!;

    public string? District { get; set; }

    public string? City { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? Utilities { get; set; }

    public string? Description { get; set; }

    public virtual User? Owner { get; set; }

    public virtual ICollection<RoomType> RoomTypes { get; set; } = new List<RoomType>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
