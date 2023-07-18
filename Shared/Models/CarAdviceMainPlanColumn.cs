using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public class CarAdviceMainPlanColumn
    {
        public long Id { get; set; } 
        public string UserName { get; set; }

        public string MainScreenColumn { get; set; }

        public bool Hidden { get; set; }

        public int?  OrderColumn { get; set; }

        public int? ColumnWidth { get; set; }

        public string? plHeader { get; set; }

        public string? TableName { get; set; }

    }
}
