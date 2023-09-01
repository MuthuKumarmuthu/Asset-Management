using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string? CreatedBy { get; set; } 

    public DateTime CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<Assest> Assests { get; set; } = new List<Assest>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
}
