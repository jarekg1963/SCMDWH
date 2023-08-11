using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public class SoModulePoList
    {
        public long Id { get; set; }

        //[Required(ErrorMessage = "Order Nr is required.")]
        public string? OrderNo { get; set; }

        public int Qty { get; set; }

        public string? DestinationSapid { get; set; }

        public string? DestinationCountryCode { get; set; }

        public string? DestinationName { get; set; }

        public bool IsCevaPo { get; set; }

        public string Product { get; set; }

        public string? Customer { get; set; }

        public int WkNo { get; set; }

        public DateTime? OriginalAgreedDeliveryDate { get; set; }

        public string? Status { get; set; }

        public int? MissingQty { get; set; }

        public string? Remark { get; set; }

        public string? Reference { get; set; }

        public string InsertByUser { get; set; }

        public DateTime InsertTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}
