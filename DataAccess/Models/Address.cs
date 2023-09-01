using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? ContactId { get; set; }

    public int AddTypeId { get; set; }

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public int CityId { get; set; }

    public int RegionId { get; set; }

    public int CountryId { get; set; }

    public string PostCode { get; set; } = null!;

    public bool? Status { get; set; }

    public bool? Active { get; set; }

    public string? Identifier { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } 

    public virtual AddressType AddType { get; set; } = null!;

    public virtual City City { get; set; } = null!;

    public virtual Contact? Contact { get; set; }

    public virtual Region Region { get; set; } = null!;
}
