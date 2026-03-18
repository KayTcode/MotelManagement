using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class ChatRoom
{
    public int ChatRoomId { get; set; }

    public int? OwnerId { get; set; }

    public int? TenantId { get; set; }

    public int? RoomContextId { get; set; }

    public string? LastMessage { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual User? Owner { get; set; }

    public virtual Room? RoomContext { get; set; }

    public virtual User? Tenant { get; set; }
}
