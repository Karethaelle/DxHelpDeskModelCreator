using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CompanyId { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
