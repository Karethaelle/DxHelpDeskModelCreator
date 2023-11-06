using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public int? AssigneeId { get; set; }

    public int? TypeId { get; set; }

    public int? StatusId { get; set; }

    public int? PriorityId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CompanyId { get; set; }

    public int? BranchId { get; set; }

    public virtual User? Assignee { get; set; }

    public virtual Ticketpriority? Priority { get; set; }

    public virtual Ticketstatus? Status { get; set; }

    public virtual ICollection<Ticketattachment> Ticketattachments { get; set; } = new List<Ticketattachment>();

    public virtual ICollection<Ticketcomment> Ticketcomments { get; set; } = new List<Ticketcomment>();

    public virtual Ticketduration? Ticketduration { get; set; }

    public virtual Tickettype? Type { get; set; }

    public virtual User? User { get; set; }
}
