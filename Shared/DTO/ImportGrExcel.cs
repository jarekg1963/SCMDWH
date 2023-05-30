using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.DTO
{
    public class ImportGrExcel
    {
        public int Id { get; set; }
        public DateTime? DataEtd { get; set; }

        public DateTime? HourEtd { get; set; }

        public string? Sender { get; set; }

        public string? ContainerNo { get; set; }
        public string? PickingStatus { get; set; }

        public string? Material { get; set; }
        public string? InvoiceNo { get; set; }

        public string? PartNo { get; set; }

        public string? CarNumber { get; set; }

        public int? TotalPalletQty { get; set; }

        public int? TotalQty { get; set; }

        public string? Remark { get; set; }


    }
}
