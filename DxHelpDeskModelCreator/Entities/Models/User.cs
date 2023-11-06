using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Audittrail> Audittrails { get; set; } = new List<Audittrail>();

    public virtual ICollection<Ticket> TicketAssignees { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketUsers { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticketcomment> Ticketcomments { get; set; } = new List<Ticketcomment>();

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
