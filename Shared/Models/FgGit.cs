using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class FgGit
{
    public long Id { get; set; }

    public string PalletNo { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string SkdpartNo { get; set; } = null!;

    public bool XlSize { get; set; }

    public string CustomerNo { get; set; } = null!;

    public string Dddestination { get; set; } = null!;

    public string CustomerOrderNo { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int? ProductQuantity { get; set; }

    public string CreateUserId { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string PickUpFromLocation { get; set; } = null!;

    public string TargetWhType { get; set; } = null!;

    public string Fgzone { get; set; } = null!;

    public DateTime? LeaveTimie { get; set; }

    public string LeaveLocation { get; set; } = null!;

    public bool InTransit { get; set; }

    public string Remarks { get; set; } = null!;
}
