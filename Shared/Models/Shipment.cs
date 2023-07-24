using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Shipment
{
    public long ShipmentId { get; set; }

    public string ShipmentNo { get; set; } = null!;

    public DateTime? ShipmentDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? LeaveDate { get; set; }

    public long CarrierId { get; set; }

    public long CarrierDriverId { get; set; }

    public long CarrierVehicleId { get; set; }

    public long RecipientId { get; set; }

    public string Remarks { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public DateTime? CompleteDate { get; set; }

    public int Cmrnumber { get; set; }

    public long SenderId { get; set; }

    public long ConsigneeId { get; set; }

    public long DeliveryPlaceId { get; set; }

    public long LoadingPlaceId { get; set; }

    public DateTime? LoadingDate { get; set; }

    public string? AttachedDocs { get; set; }

    public long CmrcarrierId1 { get; set; }

    public long CmrcarrierId2 { get; set; }

    public string RegistrationsNo { get; set; } = null!;

    public string SenderInstruction { get; set; } = null!;

    public DateTime? EstablishedDate { get; set; }

    public string EstablishedPlace { get; set; } = null!;

    public string Sapid { get; set; } = null!;

    public string DeliveryNote { get; set; } = null!;

    public string Confirmed { get; set; } = null!;

    public string CarriageInstruction { get; set; } = null!;

    public long CmrdocId { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string Dddestination { get; set; } = null!;

    public DateTime? CmrattachDate { get; set; }

    public string CustomerOrderNo { get; set; } = null!;

    public string SubBg { get; set; } = null!;

    public string TruckCode { get; set; } = null!;

    public bool StatusChangedFlag { get; set; }

    public DateTime? StatusChangedTime { get; set; }

    public string EshipStatus { get; set; } = null!;

    public string StatusBefore { get; set; } = null!;

    public string SoldTo { get; set; } = null!;

    public DateTime? SntoSfistime { get; set; }

    public string SntoSfisresult { get; set; } = null!;

    public bool PtsReported { get; set; }

    public DateTime? PtsReportedTime { get; set; }

    public string PtsTransId { get; set; } = null!;

    public string PtsMessageId { get; set; } = null!;

    public bool PtsError { get; set; }

    public string PtsErrorMessage { get; set; } = null!;
}
