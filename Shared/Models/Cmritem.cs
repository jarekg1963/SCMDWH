using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Cmritem
{
    public long CmritemId { get; set; }

    public long ShipmentId { get; set; }

    public string ProductCode { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string Packing { get; set; } = null!;

    public string NatureOfGoods { get; set; } = null!;

    public string StatisticalNo { get; set; } = null!;

    public decimal Weight { get; set; }

    public decimal Volume { get; set; }

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public long CmrdocId { get; set; }

    public string WeightUnit { get; set; } = null!;
}
