using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Ticketattachment
{
    public int Id { get; set; }

    public int? TicketId { get; set; }

    public string? FileName { get; set; }

    public byte[]? FileData { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Ticket? Ticket { get; set; }
}
