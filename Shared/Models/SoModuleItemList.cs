using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SCMDWH.Shared.Models
{
    public class SoModuleItemList
    {
        [JsonIgnore]
        public Int64    Id { get; set; }
    public Int64 PoListId { get; set; }
      public Int64 TruckId { get; set; }
      public string TPVModelName { get; set; }
      public int TotalQty { get; set; }
      public decimal TruckRatio { get; set; }
      public DateTime? CalculatedActualEarliestReadyToPickUpTime { get; set; }
      public DateTime? TimeOfLastCalculatedTime { get; set; }
      public string LastCalculatedTimeTrigerBy { get; set; }
        public string SR1 { get; set; }
      public string DN1 { get; set; }
      public string SR2 { get; set; }
        public string DN2 { get; set; }
      public string ItemStatus { get; set; }
        public string Remark { get; set; }
      public string InsertByUser { get; set; }
      public DateTime InsertTime { get; set; }
      public string LastUpdateByUser { get; set; }
      public DateTime LastUpdateTime { get; set; }
    }
}
