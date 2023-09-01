using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class DevelopmentTool
{
    public int ToolId { get; set; }

    public string? Name { get; set; }

    public bool? IsInternal { get; set; }

    public string? SerialNumber { get; set; }

    public string? Keys { get; set; }

    public string? CreatedBy { get; set; } 

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } 

    public virtual ICollection<ToolsinAssest> ToolsinAssests { get; set; } = new List<ToolsinAssest>();
}
