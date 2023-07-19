using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class ProductPallet
{
    public long ProductPalletId { get; set; }

    public string SkdpartNo { get; set; } = null!;

    public string PalletPn { get; set; } = null!;

    public bool DefaultPallet { get; set; }

    public int SetsPerPallet { get; set; }

    public int SetsPerLayer { get; set; }

    public int MaxLayersInWhinBox { get; set; }

    public int MaxLayersInTruckInPal { get; set; }

    public int LayerPerPallet { get; set; }

    public int PalletStackWhinPallet { get; set; }
    public int TotalPalletQtyOnDefaultTruck { get; set; }

    public byte[] Tstamp { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;
}
