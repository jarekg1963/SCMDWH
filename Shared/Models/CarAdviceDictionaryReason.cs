using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryReason
{
    public long Id { get; set; }

    public string Code { get; set; } = null!;

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; } = null!;

    public DateTime AddTime { get; set; }

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
