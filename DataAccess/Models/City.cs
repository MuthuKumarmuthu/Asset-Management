using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class City
{
    public int CityId { get; set; }

    public int CountryId { get; set; }

    public int RegionId { get; set; }

    public string? CityName { get; set; }

    public string? PostCode { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public string? TimeZone { get; set; }

    public string? Code { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Region Region { get; set; } = null!;
}
