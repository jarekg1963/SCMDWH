using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class ShipmentsPallet
{
    public long ShipmentPalletId { get; set; }

    public long ShipmentId { get; set; }

    public string PalletNo { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string SkdpartNo { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? PalletDate { get; set; }

    public int? ProductQuantity { get; set; }

    public string Remarks { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public string ProductionLine { get; set; } = null!;

    public string QcontrolStatus { get; set; } = null!;

    public string Fglocation { get; set; } = null!;

    public DateTime? QcstatusDate { get; set; }

    public DateTime? Fgsltime { get; set; }

    public string CustomerNo { get; set; } = null!;

    public string CustomerOrderNo { get; set; } = null!;

    public string CustomerPalletNo { get; set; } = null!;

    public long FglocId { get; set; }

    public string Fgzone { get; set; } = null!;

    public bool BackFlushed { get; set; }

    public string ConfirmStatus { get; set; } = null!;

    public bool Incompleted { get; set; }

    public string ConfirmingUser { get; set; } = null!;

    public string FglocationWh { get; set; } = null!;

    public string FgzoneWh { get; set; } = null!;

    public bool Boxed { get; set; }

    public string Dddestination { get; set; } = null!;

    public bool Swversion { get; set; }

    public string Swver { get; set; } = null!;

    public int BrwkEntryId { get; set; }

    public bool ErrorFlag { get; set; }

    public string PalletPn { get; set; } = null!;

    public bool PtsReported { get; set; }

    public DateTime? PtsReportedTime { get; set; }

    public string PtsTransId { get; set; } = null!;

    public string PtsMessageId { get; set; } = null!;

    public bool PtsError { get; set; }

    public string PtsErrorMessage { get; set; } = null!;
}
