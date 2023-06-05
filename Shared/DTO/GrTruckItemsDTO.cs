using SCMDWH.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.DTO
{
    public class GrTruckItemsDTO: CarAdviceGrTruckItems
    {
       
       public DateTime? EtdForDisplay { get; set; }
    }
}
