using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class VmciPoList
{
    public string OrderNo { get; set; } = null!;

    public string OrderType { get; set; } = null!;

    public int ItemNo { get; set; }

    public string ProductNo { get; set; } = null!;

    public int DueQty { get; set; }

    public int ScanQty { get; set; }

    public int ReadyToPostQty { get; set; }

    public int ReadyToRePostQty { get; set; }

    public int PostedQty { get; set; }

    public int SapFailQty { get; set; }

    public int ConfirmedQty { get; set; }

    public int ReadyToCevaSendQty { get; set; }

    public int SendToCevaQty { get; set; }

    public int CevaConfirmedReworkQty { get; set; }

    public int LockQty { get; set; }

    public long ShipementId { get; set; }

    public DateTime? PlanDelivDate { get; set; }

    public string Status { get; set; } = null!;

    public string CreateUser { get; set; } = null!;

    public DateTime? ImportTime { get; set; }

    public virtual ICollection<VmciPoItem> VmciPoItems { get; } = new List<VmciPoItem>();
}
