using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public int CountryId { get; set; }

    public string? RegionName { get; set; }

    public string? Code { get; set; }

    public string? Adm1code { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;
}
