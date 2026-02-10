using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsVIssueType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte Status { get; set; }

    public string StatusName { get; set; } = null!;

    public byte IsDelete { get; set; }

    public int CreatedByUserId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? ModifiedByUserid { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
