using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
	public class View_SoModuleGroupData
	{
         public Int64? Id { get; set; }
		public Int64? PoListId { get; set; }
		public Int64?	 TruckId { get; set; }
		public int? WkNo { get; set; }
		public string? Customer { get; set; }
		public string? Product { get; set; }
		public string? TPVModelName { get; set; }
		public int? TotalQty { get; set; }
		public decimal? TruckRatio { get; set; }
		public string? OrderNo { get; set; }
		public string? DestinationSAPId { get; set; }
		public string? DestinationName { get; set; }
		public string? DestinationCountryCode { get; set; }
		public string? SR1 { get; set; }
		public string?	DN1 { get; set; }
		public string? SR2 { get; set; }
		public string? DN2 { get; set; }
		public string? ItemStatus { get; set; }
		public string? Remark { get; set; }
		public DateTime? CalculatedActualEarliestReadyToPickUpTime { get; set; }
		public DateTime? TimeOfLastCalculatedTime { get; set; }
		public DateTime? TruckCalculatedActualEarliestPickUpTime { get; set; }
		public DateTime	 AdvisedDateTime { get; set; }
		public string? Consignment { get; set; }
		public decimal? TotalTruckRatio { get; }
		public string? TruckStatus { get; set; }
		public string? TruckRemark { get; set; }
		public string? InsertByUser { get; set; }
		public DateTime? InsertTime { get; set; }
		public string? LastCalculatedTimeTrigerBy { get; set; }
		public string? LastUpdateByUser { get; set; }
		public DateTime? LastUpdateTime { get; set; }
		public string? LineBgColorDefinedByUser { get; set; }

	}
}
