﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;


namespace SCMDWH.Shared.Models;

public partial class CarAdviceGrDictionarySender
{
    public long Id { get; set; }

    public string SenderName { get; set; }

    public string Remark { get; set; }

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; }

    public DateTime AddTime { get; set; }

    public virtual ICollection<CarAdviceGrTruckMainTable> CarAdviceGrTruckMainTable { get; set; } = new List<CarAdviceGrTruckMainTable>();
}