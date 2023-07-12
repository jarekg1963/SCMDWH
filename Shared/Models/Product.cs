using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Product
{
    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string SkdpartNo { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public bool Active { get; set; }

    public string Remarks { get; set; } = null!;

    public string Mrpcontroller { get; set; } = null!;

    public int PalletQty { get; set; }

    public decimal MatWeight { get; set; }

    public string WeightUnit { get; set; } = null!;

    public decimal Height { get; set; }

    public decimal Width { get; set; }

    public decimal Depth { get; set; }

    public string UnitOfDimension { get; set; } = null!;

    public bool NoUpdateDim { get; set; }

    public decimal TpvisionWeight { get; set; }

    public string TpvisionWeightUnit { get; set; } = null!;
}
