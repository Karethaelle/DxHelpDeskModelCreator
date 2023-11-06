using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Ticketduration
{
    public int TicketId { get; set; }

    public int? TotalHours { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
