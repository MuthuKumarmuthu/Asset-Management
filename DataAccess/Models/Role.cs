using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleCode { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? RoleLevel { get; set; }

    public string RoleName { get; set; } = null!;

    public string LoweredRoleName { get; set; } = null!;

    public string? Description { get; set; }

    public bool Status { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedOn { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<MembersinRole> MembersinRoles { get; set; } = new List<MembersinRole>();
}
