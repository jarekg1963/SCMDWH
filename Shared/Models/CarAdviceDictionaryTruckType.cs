using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryTruckType
{
    public long Id { get; set; }

    public string Truck { get; set; } = null!;

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; } = null!;

    public DateTime AddTime { get; set; }

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
