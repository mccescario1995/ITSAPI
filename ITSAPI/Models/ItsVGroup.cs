using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsVGroup
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public int GroupTypeId { get; set; }

    public string? GroupType { get; set; }

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
