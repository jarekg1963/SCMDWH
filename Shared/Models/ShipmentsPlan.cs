using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class ShipmentsPlan
{
    public long ShipmentPlanId { get; set; }

    public long ShipmentId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string SkdpartNo { get; set; } = null!;

    public int? ProductQuantity { get; set; }

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public int PostingQty { get; set; }

    public string DeliveryNote { get; set; } = null!;

    public string DeliveryItem { get; set; } = null!;

    public string Sloc { get; set; } = null!;

    public string ProgramDate { get; set; } = null!;

    public string ProgramTime { get; set; } = null!;

    public string BaseUnit { get; set; } = null!;

    public long PostingKey { get; set; }

    public string FileSeqNo { get; set; } = null!;

    public string Confirmed { get; set; } = null!;

    public string ResultMessage { get; set; } = null!;

    public DateTime? PostingTime { get; set; }

    public DateTime? ConfirmTime { get; set; }
}
