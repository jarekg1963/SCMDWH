using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class CarAdviceDictionaryLoadingPlace
{
    public long Id { get; set; }

    public string LoadingPlace { get; set; } = null!;

    public bool? ActiveFlag { get; set; }

    public string AddByUser { get; set; } = null!;

    public DateTime AddTime { get; set; }
}
