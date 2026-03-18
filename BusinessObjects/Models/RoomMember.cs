using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class RoomMember
{
    public int MemberId { get; set; }

    public int? ContractId { get; set; }

    public string FullName { get; set; } = null!;

    public string? IdentityCard { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? JoinDate { get; set; }

    public virtual Contract? Contract { get; set; }
}
