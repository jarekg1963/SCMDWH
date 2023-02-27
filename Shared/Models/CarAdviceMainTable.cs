using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceMainTable
{
 //   [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }
    //[NotMapped]
    //public string TEST { get { } } = null!;

    public DateTime? AdviceDate { get; set; }

    public string? FgDelayReason { get; set; }

    public string? PickingStatus { get; set; } 

    public string? Client { get; set; } 

    public string? Shipment { get; set; }

    public string? Reference { get; set; }

    public string Destination { get; set; } = null!;

    public string? DriverWh { get; set; }

    public string? TruckPlatesWh { get; set; }

    public string? Forwarder { get; set; } = null!;

    public string? ForwarderInfo { get; set; }

    public DateTime? Etd { get; set; }

    public string? EntryByWh { get; set; }

    public string? RemarksWh { get; set; }

    public DateTime? Ata { get; set; }

    public string Quality { get; set; } = null!;

    public string? TruckType { get; set; } 

    public string? DriverS { get; set; }

    public string? TruckPlatesS { get; set; }

    public DateTime? TpvEnterTime { get; set; }

    public DateTime? TpvExitTime { get; set; }

    public short? LoadingDock { get; set; }

    public string? CallBy { get; set; }

    public string? RemarksS { get; set; }

    public string? EntryByS { get; set; }

    public DateTime? LeftTheDockTime { get; set; }

    public DateTime? PickingTime { get; set; }

    public DateTime? ScannedTime { get; set; }

    public virtual CarAdviceDictionaryCustomers? ClientNavigation { get; set; } = null!;

    public virtual CarAdviceDictionaryCountryCode? DestinationNavigation { get; set; } = null!;

    public virtual CarAdviceDictionaryReason? FgDelayReasonNavigation { get; set; } = null!;

    public virtual CarAdviceDictionaryStatus? PickingStatusNavigation { get; set; } = null!;

    public virtual CarAdviceDictionaryQuality? QualityNavigation { get; set; } = null!;

    public virtual CarAdviceDictionaryTruckType? TruckTypeNavigation { get; set; } = null!;
}
