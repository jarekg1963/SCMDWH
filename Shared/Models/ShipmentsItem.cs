using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class ShipmentsItem
{
    public long ShipmentItemId { get; set; }

    public long ShipmentPalletId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string SkdpartNo { get; set; } = null!;

    public string SerialNo { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public string CustomerNo { get; set; } = null!;

    public string WorkOrder { get; set; } = null!;

    public bool BackFlushed { get; set; }

    public DateTime? RepackTime { get; set; }

    public int ReturnCount { get; set; }

    public string RepackProdLine { get; set; } = null!;

    public string RepackPalletNo { get; set; } = null!;

    public string BoxNo { get; set; } = null!;

    public string Dddestination { get; set; } = null!;

    public bool Swversion { get; set; }

    public string Swver { get; set; } = null!;

    public string CustomerOrderNo { get; set; } = null!;

    public bool ErrorFlag { get; set; }

    public string PanelSerialNo { get; set; } = null!;

    public bool PtsReported { get; set; }

    public DateTime? PtsReportedTime { get; set; }

    public string PtsTransId { get; set; } = null!;

    public string PtsMessageId { get; set; } = null!;

    public bool PtsError { get; set; }

    public string PtsErrorMessage { get; set; } = null!;
}
