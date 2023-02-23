using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionarySecurityPerson
{
    public long Id { get; set; }

    public string Security { get; set; } = null!;

    public string? ContactMobile { get; set; }

    public string? ContactEmail { get; set; }

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; } = null!;

    public DateTime AddTime { get; set; }

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
