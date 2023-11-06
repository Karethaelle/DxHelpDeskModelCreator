using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Ticketpriority
{
    public int Id { get; set; }

    public string? Level { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
