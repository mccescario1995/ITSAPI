using System;
using System.Collections.Generic;

namespace ITSAPI.Models;

public partial class ItsIssuethread
{
    public int Id { get; set; }

    public int Issueid { get; set; }

    public string Messagedetail { get; set; } = null!;

    /// <summary>
    /// 0 = System
    /// </summary>
    public int Createdbyuserid { get; set; }

    //public string Createdbyuser { get; set; } = null!;
    public DateTime Createddate { get; set; }
}
                                                                                                                    