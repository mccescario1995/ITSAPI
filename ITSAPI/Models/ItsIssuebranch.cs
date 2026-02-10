using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsIssuebranch
{
    public int Id { get; set; }

    public int Issueid { get; set; }

    public string Branchcode { get; set; } = null!;

    public byte Isdelete { get; set; }

    public int Createdbyuserid { get; set; }

    public DateTime Createddate { get; set; }

    public int? Modifiedbyuserid { get; set; }

    public DateTime? Modifieddate { get; set; }
}
