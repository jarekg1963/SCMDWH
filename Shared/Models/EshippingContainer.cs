using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class EshippingContainer
{
    public long Id { get; set; }

    public string? ShipmentId { get; set; }

    public string? ContainerNo { get; set; }

    public string? DeliveryNote1 { get; set; }

    public string? DeliveryNote2 { get; set; }

    public string? Status { get; set; }

    public string? CallTruckStatus { get; set; }

    public string? MasterBl { get; set; }

    public string? CntrType { get; set; }

    public string? HouseDl { get; set; }

    public string? TransMode { get; set; }

    public string? ProductType { get; set; }

    public string? TruckerNm1 { get; set; }

    public string? Carrier { get; set; }

    public string? DestName { get; set; }

    public DateTime? Etd { get; set; }

    public DateTime? Atd { get; set; }

    public DateTime? Eta { get; set; }

    public DateTime? Ata { get; set; }

    public DateTime? PickUpDateTime { get; set; }

    public int? PalletQty { get; set; }

    public bool Wmsimported { get; set; }

    public DateTime? WmsimportTime { get; set; }
}
