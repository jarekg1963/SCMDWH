﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceGrTruckMainTable
{
	public long Id { get; set; }
	[NotMapped]
	public string Invoices
	{
		get 
		{
			if (CarAdviceGrTruckItems == null || !CarAdviceGrTruckItems.Any()) return string.Empty;
			return string.Join(",", CarAdviceGrTruckItems.Select(o => o.InvoiceNo).Distinct().OrderBy(o=>o));
		}
	}
	public DateTime? AddDate { get; set; }

	public string AddByUser { get; set; }

	public string PickingStatus { get; set; }


	public DateTime? TpvEnterTime { get; set; }

	public string? DriverS { get; set; }

	public string? TruckPlatesS { get; set; }

	public string? RemarkS { get; set; }

	public string? CallBy { get; set; }

	public string? DriverWh { get; set; }

	public string? TruckPlatesWh { get; set; }

	public string? RemarksWh { get; set; }

	public short? LoadingDock { get; set; }



	public string? FgDelayReason { get; set; }

	public DateTime? Ata { get; set; }

	public string? Quality { get; set; } = null!;

	public string? TruckType { get; set; }

	public string? EntryByS { get; set; }

	public DateTime? TpvExitTime { get; set; }

    public DateTime? ETD { get; set; }

	public string? EntryByWh { get; set; }


    public string? Sender { get; set; }

    public string? ContainerStatus { get; set; }

    public string? MaterialStatus { get; set; }

    public string? ContainerNo { get;set; }

	public DateTime? StartUnloading { get; set; } 
    public DateTime? FinishUnloading { get; set; }

    public virtual ICollection<CarAdviceGrTruckItems> CarAdviceGrTruckItems { get; set; } = new List<CarAdviceGrTruckItems>();

	//public virtual CarAdviceGrDictionarySender SenderNameNavigation { get; set; }

	//public virtual CarAdviceGrDictionaryCarStatuses StatusNavigation { get; set; }

	//public virtual CarAdviceGrDictionaryUnloadingPlace UnloadingPlaceNavigation { get; set; }
}