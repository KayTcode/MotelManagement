using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class ChatMessage
{
    public int MessageId { get; set; }

    public int? ChatRoomId { get; set; }

    public int? SenderId { get; set; }

    public string MessageContent { get; set; } = null!;

    public DateTime? SendTime { get; set; }

    public bool? IsRead { get; set; }

    public virtual ChatRoom? ChatRoom { get; set; }

    public virtual User? Sender { get; set; }
}
