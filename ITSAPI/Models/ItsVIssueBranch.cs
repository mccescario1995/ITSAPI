using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsVIssueBranch
{
    public int Id { get; set; }

    public int IssueId { get; set; }

    public string BranchCode { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public byte IsDelete { get; set; }

    public int CreatedByUserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedByUserId { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
