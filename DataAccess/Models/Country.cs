using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string? Country1 { get; set; }

    public string? Elscode { get; set; }

    public string? Fips104 { get; set; }

    public string? Iso2 { get; set; }

    public string? Iso3 { get; set; }

    public string? Ison { get; set; }

    public string? Internet { get; set; }

    public string? Capital { get; set; }

    public string? MapReference { get; set; }

    public string? NationalitySingular { get; set; }

    public string? NationalityPlural { get; set; }

    public string? Currency { get; set; }

    public string? CurrencyCode { get; set; }

    public long? Population { get; set; }

    public string? Title { get; set; }

    public string? Comment { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
