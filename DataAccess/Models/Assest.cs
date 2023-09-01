using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Assest
{
    public int AssestId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int AssestTypeId { get; set; }

    public int? DepartmentId { get; set; }

    public int AssestStatusId { get; set; }

    public int? VendorId { get; set; }

    public int? OwnerId { get; set; }

    public int? UserId { get; set; }

    public string? SerialNumber { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Processor { get; set; }

    public string? Memory { get; set; }

    public string? Storage { get; set; }

    public string? OperatingSystem { get; set; }

    public string? Ipaddress { get; set; }

    public string? InsuranceDetails { get; set; }

    public string? LicenceDetails { get; set; }

    public DateTime? LicenceExpiry { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public string? InvoiceNumber { get; set; }

    public string? Amc { get; set; }

    public string? Warranty { get; set; }

    public string? Remarks { get; set; }

    public string? Location { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } 

    public virtual AssestStatus AssestStatus { get; set; } = null!;

    public virtual AssestType AssestType { get; set; } = null!;

    public virtual Department? Department { get; set; }

    public virtual Membership? Owner { get; set; }

    public virtual ICollection<ToolsinAssest> ToolsinAssests { get; set; } = new List<ToolsinAssest>();

    public virtual Vendor? Vendor { get; set; }
}
