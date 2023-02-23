using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryCustomers
{
    public long Id { get; set; }

    public string Customer { get; set; } = null!;

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; } = null!;

    public DateTime AddTime { get; set; }

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
