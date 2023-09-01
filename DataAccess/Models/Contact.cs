using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public int? MembershipId { get; set; }

    public int? VendorId { get; set; }

    public bool? IsPrimary { get; set; }

    public string Salutation { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Sex { get; set; }

    public string? EMail { get; set; }

    public string? PhoneAreaCode { get; set; }

    public string? Phone { get; set; }

    public string? HomePhone { get; set; }

    public string? MobilePhone { get; set; }

    public string? Fax { get; set; }

    public string? PreferredContact { get; set; }

    public string? WebSite { get; set; }

    public bool? Status { get; set; }

    public string? Identifier { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Membership? Membership { get; set; }

    public virtual Vendor? Vendor { get; set; }
}
