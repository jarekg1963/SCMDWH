﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.DTO
{
    public class SoPoImportExcel
    {
        public int Id { get; set; }

        public string OrderNo   { get; set; }
        public int Qty { get; set; }

        public string DestinationSAPId { get; set;}

        public bool IsCevaPo { get; set;}

        public string Product { get; set;}
        public string WkNo { get; set;}
    
    }
}