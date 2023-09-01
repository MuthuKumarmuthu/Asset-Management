using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ToolsinAssest
{
    public int ToolsinAssestId { get; set; }

    public int AssestId { get; set; }

    public int ToolId { get; set; }

    public bool? Status { get; set; }

    public bool? Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedOn { get; set; }

    public byte[]? Version { get; set; } = null!;

    public virtual Assest Assest { get; set; } = null!;

    public virtual DevelopmentTool Tool { get; set; } = null!;
}
