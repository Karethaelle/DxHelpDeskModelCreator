using System;
using System.Collections.Generic;

namespace DxHelpDeskModelCreator.Entities.Models;

public partial class Commonproblem
{
    public int Id { get; set; }

    public string? IssueTitle { get; set; }

    public string? IssueDescription { get; set; }

    public string? Solution { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
