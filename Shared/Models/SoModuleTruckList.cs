using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public  class SoModuleTruckList
    {
        public Int64 Id { get; set; }
        public string Consignment   { get; set; }
        public string LineBgColorDefinedByUser  { get; set; }

        public DateTime EstimatedPickUpTime { get; set; }

        public DateTime AdvisedDateTime { get; set; }

        public DateTime CalculatedActualEarliestPickUpTime { get; set; }

        public DateTime TimeOfLastCalculatedTime { get; set; }

        public string TruckStatus { get; set; }

        public string TruckRemark { get; set;}

        public string InsertByUser { get; set;}

        public DateTime InsertTime { get; set;}

        public string LastUpdateByUser { get; set;}

        public DateTime LastUpdateTime { get; set;}




    }
}
