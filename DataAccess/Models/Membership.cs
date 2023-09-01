using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public string? MembershipTypeCode { get; set; }

    public DateTime RegisteredDate { get; set; }

    public string UserName { get; set; } = null!;

    public string? AliasName { get; set; }

    public string Password { get; set; } = null!;

    public string? PasswordQuestion { get; set; }

    public string? PasswordAnswer { get; set; }

    public string? Email { get; set; }

    public string? LoweredEmail { get; set; }

    public bool? IsLockedOut { get; set; }

    public DateTime? LastPasswordChangedDate { get; set; }

    public DateTime? LastLockoutDate { get; set; }

    public int? FailedPasswordAttemptCount { get; set; }

    public int? FailedPasswordAnswerAttemptCount { get; set; }

    public bool? IsApproved { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public DateTime? LastActivityDate { get; set; }

    public bool? IsOnline { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? Comments { get; set; }

    public bool? TandCaccepted { get; set; }

    public byte[]? ProfileImage { get; set; }

    public string? ProfileImageContentType { get; set; }

    public bool Active { get; set; }

    public bool Status { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } 

    public bool EnforcePasswordChange { get; set; }

    public virtual ICollection<Assest> Assests { get; set; } = new List<Assest>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<MembersinRole> MembersinRoles { get; set; } = new List<MembersinRole>();

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();
}
