using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsVIssueThread
{
    public int Id { get; set; }

    public int IssueId { get; set; }

    public string MessageDetail { get; set; } = null!;

    public int CreatedByUserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
