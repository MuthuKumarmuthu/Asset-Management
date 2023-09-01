using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserActivityLogDetail
{
    public long LogDetailId { get; set; }

    public int LogId { get; set; }

    public string? RequestMethod { get; set; }

    public string? RequestUrl { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual UserActivityLog Log { get; set; } = null!;
}
