using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public int? BuildingId { get; set; }

    public string? TypeName { get; set; }

    public decimal BasePrice { get; set; }

    public double? Area { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
