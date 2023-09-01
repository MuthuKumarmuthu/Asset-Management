using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AddressType
{
    public int AddTypeId { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public bool? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; } = null!;

    public DateTime UpdatedOn { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
