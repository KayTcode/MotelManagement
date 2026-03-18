using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int? BuildingId { get; set; }

    public int? RoomTypeId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public int? Floor { get; set; }

    public int? MaxOccupants { get; set; }

    public string? Status { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsActive { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual RoomType? RoomType { get; set; }
}
