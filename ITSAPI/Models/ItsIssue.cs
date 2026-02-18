using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsIssue
{
    public int Id { get; set; }

    public string Isusedetails { get; set; } = null!;

    public string? Actionplan { get; set; }

    public int Issuetypeid { get; set; }

    public int Responsiblegroupid { get; set; }

    public string? Responsibleempid { get; set; }

    public byte Status { get; set; }

    public byte Isdelete { get; set; }

    public int Createdbyuserid { get; set; }

    public DateTime Createddate { get; set; }

    public int? Modifiedbyuserid { get; set; }

    public DateTime? Modifieddate { get; set; }

    // Locking fields
    public int? LockedByUserId { get; set; }

    public DateTime? LockedAt { get; set; }

    public DateTime? LockExpiresAt { get; set; }
}
