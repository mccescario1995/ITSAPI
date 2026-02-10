using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsGroup
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string Name { get; set; } = null!;

    public int Grouptypeid { get; set; }

    public byte Status { get; set; }

    public byte Isdelete { get; set; }

    public int Createdbyuserid { get; set; }

    public DateTime Createddate { get; set; }

    public int? Modifiedbyuserid { get; set; }

    public DateTime? Modifieddate { get; set; }
}
