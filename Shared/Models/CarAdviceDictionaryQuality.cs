using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryQuality
{
    public int Id { get; set; }

    public string Quality { get; set; } = null!;

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
