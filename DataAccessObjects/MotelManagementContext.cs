using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class MotelManagementContext : DbContext
{
    public MotelManagementContext()
    {
    }

    public MotelManagementContext(DbContextOptions<MotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<ChatRoom> ChatRooms { get; set; }

    public virtual DbSet<CheckOutSettlement> CheckOutSettlements { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomMember> RoomMembers { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableDetailedErrors()
                     .EnableSensitiveDataLogging(); // Chỉ dùng trong development
        var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyCnn");
        optionsBuilder.UseSqlServer(ConnectionString);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC41007321B");

            entity.Property(e => e.AddressDetail).HasMaxLength(255);
            entity.Property(e => e.BuildingName).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Latitude).HasColumnType("decimal(12, 9)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(12, 9)");

            entity.HasOne(d => d.Owner).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Buildings__Owner__3E52440B");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__ChatMess__C87C0C9C86DB09C3");

            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.SendTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.ChatRoom).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.ChatRoomId)
                .HasConstraintName("FK__ChatMessa__ChatR__6754599E");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__ChatMessa__Sende__68487DD7");
        });

        modelBuilder.Entity<ChatRoom>(entity =>
        {
            entity.HasKey(e => e.ChatRoomId).HasName("PK__ChatRoom__69733CF7736942B2");

            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Owner).WithMany(p => p.ChatRoomOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__ChatRooms__Owner__619B8048");

            entity.HasOne(d => d.RoomContext).WithMany(p => p.ChatRooms)
                .HasForeignKey(d => d.RoomContextId)
                .HasConstraintName("FK__ChatRooms__RoomC__6383C8BA");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ChatRoomTenants)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK__ChatRooms__Tenan__628FA481");
        });

        modelBuilder.Entity<CheckOutSettlement>(entity =>
        {
            entity.HasKey(e => e.SettlementId).HasName("PK__CheckOut__7712545A28859504");

            entity.HasIndex(e => e.ContractId, "UQ__CheckOut__C90D3468EF8313DC").IsUnique();

            entity.Property(e => e.CheckOutDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DamageFee)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalRefundAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsCompleted).HasDefaultValue(false);

            entity.HasOne(d => d.Contract).WithOne(p => p.CheckOutSettlement)
                .HasForeignKey<CheckOutSettlement>(d => d.ContractId)
                .HasConstraintName("FK__CheckOutS__Contr__5BE2A6F2");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3469BF3A9B02");

            entity.Property(e => e.ContractStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Owner).WithMany(p => p.ContractOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Contracts__Owner__4CA06362");

            entity.HasOne(d => d.Room).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Contracts__RoomI__4BAC3F29");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ContractTenants)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK__Contracts__Tenan__4D94879B");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD64F1E62C7");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Feedbacks__RoomI__72C60C4A");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK__Feedbacks__Tenan__73BA3083");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAB5401D73C1");

            entity.Property(e => e.IsPaid).HasDefaultValue(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceFee)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Contract).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__Invoices__Contra__5629CD9C");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5CF8374CBB7");

            entity.Property(e => e.CloudinaryPublicId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CloudinaryUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MediaType).HasMaxLength(50);
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__D5BD48059E8018BC");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReportStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.ResolvedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Sender).WithMany(p => p.ReportSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Reports__SenderI__6D0D32F4");

            entity.HasOne(d => d.TargetUser).WithMany(p => p.ReportTargetUsers)
                .HasForeignKey(d => d.TargetUserId)
                .HasConstraintName("FK__Reports__TargetU__6E01572D");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863939ED394B06");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsApproved).HasDefaultValue(false);
            entity.Property(e => e.MaxOccupants).HasDefaultValue(2);
            entity.Property(e => e.RoomNumber).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Available");

            entity.HasOne(d => d.Building).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Rooms__BuildingI__440B1D61");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK__Rooms__RoomTypeI__44FF419A");
        });

        modelBuilder.Entity<RoomMember>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__RoomMemb__0CF04B18DD6A236C");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IdentityCard)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Contract).WithMany(p => p.RoomMembers)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__RoomMembe__Contr__52593CB8");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__RoomType__BCC8963178862DA7");

            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TypeName).HasMaxLength(100);

            entity.HasOne(d => d.Building).WithMany(p => p.RoomTypes)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__RoomTypes__Build__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C134FC140");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E38EC652D9C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105342E2D8571").IsUnique();

            entity.Property(e => e.AvatarUrl).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserRole).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
