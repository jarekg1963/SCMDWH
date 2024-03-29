﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceGrTruckItems
{
    public long Id { get; set; }

    public long TruckId { get; set; }

    public string? ContainerNo { get; set; }

    public string? PalletNo { get; set; }

    public string? Material { get; set; }

    public string? InvoiceNo { get; set; }

    public int? TotalPalletQty { get; set; }

    public int? TotalQty { get; set; }

    public string? Remark { get; set; }

    public bool SapGrDone { get; set; }

    public DateTime? SapGrTime { get; set; }

    public string? SapGrMarDoc { get; set; }

    public string? WorkOrders { get; set; }
    public string? Transfer { get; set; }



    [JsonIgnore]
    public virtual CarAdviceGrTruckMainTable Truck { get; set; }
}