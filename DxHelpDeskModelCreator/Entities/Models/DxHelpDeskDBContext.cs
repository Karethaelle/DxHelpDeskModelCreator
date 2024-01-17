using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class DxHelpDeskDBContext : DbContext
{
    public DxHelpDeskDBContext()
    {
    }

    public DxHelpDeskDBContext(DbContextOptions<DxHelpDeskDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audittrail> Audittrails { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Commonproblem> Commonproblems { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Ticketattachment> Ticketattachments { get; set; }

    public virtual DbSet<Ticketcomment> Ticketcomments { get; set; }

    public virtual DbSet<Ticketduration> Ticketdurations { get; set; }

    public virtual DbSet<Ticketpriority> Ticketpriorities { get; set; }

    public virtual DbSet<Ticketstatus> Ticketstatuses { get; set; }

    public virtual DbSet<Tickettype> Tickettypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=dxhelpdesk;uid=root;pwd=W2ozrsdon.0;port=3306;default command timeout=1200;sslmode=Preferred;convert zero datetime=True", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
    //server=localhost;database=dxhelpdesk;uid=root;pwd=B1u3g@t35Cub3Inc2016;port=3308;default command timeout=1200;sslmode=Preferred;convert zero datetime=True
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Audittrail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audittrail");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TableAffected).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Audittrails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("audittrail_ibfk_1");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("branches");

            entity.HasIndex(e => e.CompanyId, "CompanyId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Company).WithMany(p => p.Branches)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("branches_ibfk_1");
        });

        modelBuilder.Entity<Commonproblem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("commonproblems");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.IssueDescription).HasColumnType("text");
            entity.Property(e => e.IssueTitle).HasMaxLength(100);
            entity.Property(e => e.Solution).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("companies");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tickets");

            entity.HasIndex(e => e.AssigneeId, "AssigneeId");

            entity.HasIndex(e => e.PriorityId, "PriorityId");

            entity.HasIndex(e => e.StatusId, "StatusId");

            entity.HasIndex(e => e.TypeId, "TypeId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Assignee).WithMany(p => p.TicketAssignees)
                .HasForeignKey(d => d.AssigneeId)
                .HasConstraintName("tickets_ibfk_2");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("tickets_ibfk_5");

            entity.HasOne(d => d.Status).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("tickets_ibfk_4");

            entity.HasOne(d => d.Type).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("tickets_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.TicketUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("tickets_ibfk_1");
        });

        modelBuilder.Entity<Ticketattachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticketattachments");

            entity.HasIndex(e => e.TicketId, "TicketId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FileData).HasColumnType("blob");
            entity.Property(e => e.FileName).HasMaxLength(100);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Ticketattachments)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("ticketattachments_ibfk_1");
        });

        modelBuilder.Entity<Ticketcomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticketcomments");

            entity.HasIndex(e => e.TicketId, "TicketId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Ticketcomments)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("ticketcomments_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Ticketcomments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ticketcomments_ibfk_2");
        });

        modelBuilder.Entity<Ticketduration>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PRIMARY");

            entity.ToTable("ticketduration");

            entity.Property(e => e.TicketId).ValueGeneratedNever();

            entity.HasOne(d => d.Ticket).WithOne(p => p.Ticketduration)
                .HasForeignKey<Ticketduration>(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticketduration_ibfk_1");
        });

        modelBuilder.Entity<Ticketpriority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticketpriority");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Level).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticketstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ticketstatus");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Tickettype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tickettypes");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Branches).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Branchowner",
                    r => r.HasOne<Branch>().WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("branchowners_ibfk_2"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("branchowners_ibfk_1"),
                    j =>
                    {
                        j.HasKey("UserId", "BranchId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("branchowners");
                        j.HasIndex(new[] { "BranchId" }, "BranchId");
                    });

            entity.HasMany(d => d.Companies).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "Companyowner",
                    r => r.HasOne<Company>().WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("companyowners_ibfk_2"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("companyowners_ibfk_1"),
                    j =>
                    {
                        j.HasKey("UserId", "CompanyId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("companyowners");
                        j.HasIndex(new[] { "CompanyId" }, "CompanyId");
                    });
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("userroles");

            entity.HasIndex(e => e.RoleId, "RoleId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("userroles_ibfk_2");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userroles_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
