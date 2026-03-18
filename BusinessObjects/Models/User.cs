using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? UserRole { get; set; }

    public string? AvatarUrl { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<ChatRoom> ChatRoomOwners { get; set; } = new List<ChatRoom>();

    public virtual ICollection<ChatRoom> ChatRoomTenants { get; set; } = new List<ChatRoom>();

    public virtual ICollection<Contract> ContractOwners { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractTenants { get; set; } = new List<Contract>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Report> ReportSenders { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportTargetUsers { get; set; } = new List<Report>();
}
