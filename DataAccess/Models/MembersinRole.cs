using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class MembersinRole
{
    public int MemberinRoleId { get; set; }

    public int MembershipId { get; set; }

    public int RoleId { get; set; }

    public bool Active { get; set; }

    public bool Status { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; }

    public virtual Membership Membership { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
