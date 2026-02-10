using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte Status { get; set; }

    public byte Isdelete { get; set; }

    public int Createdbyuserid { get; set; }

    public DateTime Createddate { get; set; }

    public int? Modifiedbyuserid { get; set; }

    public DateTime? Modifieddate { get; set; }
}
