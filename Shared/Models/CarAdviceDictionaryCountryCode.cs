using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryCountryCode
{
    public long Id { get; set; }
  
    public string Country { get; set; } = null!;

    public string? Polish { get; set; }

    public string? English { get; set; }

    public virtual ICollection<CarAdviceMainTable> CarAdviceMainTables { get; } = new List<CarAdviceMainTable>();
}
