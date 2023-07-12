using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Cmrdoc
{
    public long CmrdocId { get; set; }

    public int Cmrnumber { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? Cmrdate { get; set; }

    public long SenderId { get; set; }

    public long ConsigneeId { get; set; }

    public long DeliveryPlaceId { get; set; }

    public long LoadingPlaceId { get; set; }

    public long CmrcarrierId1 { get; set; }

    public long CmrcarrierId2 { get; set; }

    public string RegistrationsNo { get; set; } = null!;

    public string AttachedDocs { get; set; } = null!;

    public string SenderInstruction { get; set; } = null!;

    public string CarriageInstruction { get; set; } = null!;

    public DateTime? EstablishedDate { get; set; }

    public string EstablishedPlace { get; set; } = null!;

    public DateTime? LoadingDate { get; set; }

    public string Remarks { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public byte[] Tstamp { get; set; } = null!;

    public string Driver { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public string ContainerNo { get; set; } = null!;

    public string Seal1 { get; set; } = null!;

    public string Seal2 { get; set; } = null!;

    public bool ReadyToReport { get; set; }

    public string TruckType { get; set; } = null!;

    public string TruckServiceBscode { get; set; } = null!;

    public string TruckServiceName { get; set; } = null!;

    public string Consigment { get; set; } = null!;

    public bool EShpReadyToReport { get; set; }

    public DateTime? LastReportTime { get; set; }

    public bool? LastReportResults { get; set; }

    public string LastReportResultMessage { get; set; } = null!;

    public bool Printed { get; set; }

    public DateTime? PrintTime { get; set; }

    public string PrintUser { get; set; } = null!;
}
