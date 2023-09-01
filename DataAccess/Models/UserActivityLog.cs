using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class UserActivityLog
{
    public int LogId { get; set; }

    public int MembershipId { get; set; }

    public string? UserName { get; set; }

    public string? Host { get; set; }

    public DateTime? LoggedinTime { get; set; }

    public DateTime? LoggedoutTime { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? IpAddress { get; set; }

    public virtual Membership Membership { get; set; } = null!;

    public virtual ICollection<UserActivityLogDetail> UserActivityLogDetails { get; set; } = new List<UserActivityLogDetail>();
}
