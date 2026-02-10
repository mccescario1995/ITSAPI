using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsVIssue
{
    public int Id { get; set; }

    public string IssueDetails { get; set; } = null!;

    public string? ActionPlan { get; set; }

    public int IssueTypeId { get; set; }

    public string IssueType { get; set; } = null!;

    public int ResponsibleGroupId { get; set; }

    public string ResponsibleGroupName { get; set; } = null!;

    public string? ResponsibleEmployeeId { get; set; }

    public string? ResponsibleEmployee { get; set; }

    public byte Status { get; set; }

    public string StatusName { get; set; } = null!;

    public byte IsDelete { get; set; }

    public int CreatedByUserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedByUserId { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
