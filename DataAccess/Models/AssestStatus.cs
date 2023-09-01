using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class AssestStatus
{
    public int AssestStatusId { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } 

    public virtual ICollection<Assest> Assests { get; set; } = new List<Assest>();
}
