﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceGrTruckMainTable
{
	public long Id { get; set; }

	public DateTime? AddDate { get; set; }

	public string AddByUser { get; set; }

	public string CarRemark { get; set; }

	public string Reference { get; set; }

	public string SenderName { get; set; }

	public string UnloadingPlace { get; set; }

	public DateTime? PlanDeliveryTime { get; set; }

	public string Status { get; set; }

	//public DateTime? EnterTime { get; set; }

	public DateTime? TpvEnterTime { get; set; }

	public string DriverS { get; set; }

	public string TruckPlatesS { get; set; }

	public string RemarkS { get; set; }

	public string CallBy { get; set; }

	public string DriverWh { get; set; }

	public string TruckPlatesWh { get; set; }

	public string RemarkWh { get; set; }

	public string UnloadingDock { get; set; }

	public DateTime? UnloadingTime { get; set; }

	public DateTime? ExitTime { get; set; }


	public string? FgDelayReason { get; set; }

	public DateTime? Ata { get; set; }

	public string? Quality { get; set; } = null!;

	public string? TruckType { get; set; }

	public string? EntryByS { get; set; }

	public DateTime? TpvExitTime { get; set; }

    public DateTime? ETD { get; set; }

	public string Invoices { get; set; }

    public virtual ICollection<CarAdviceGrTruckItems> CarAdviceGrTruckItems { get; set; } = new List<CarAdviceGrTruckItems>();

	public virtual CarAdviceGrDictionarySender SenderNameNavigation { get; set; }

	public virtual CarAdviceGrDictionaryCarStatuses StatusNavigation { get; set; }

	public virtual CarAdviceGrDictionaryUnloadingPlace UnloadingPlaceNavigation { get; set; }
}