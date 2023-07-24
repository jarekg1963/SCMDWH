using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;
public partial class VmciPoItem
{
    public int PoitemId { get; set; }

    public string OrderNo { get; set; } = null!;

    public string ProductNo { get; set; } = null!;

    public string ProductTpvNo { get; set; } = null!;

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

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public virtual VmciPoList OrderNoNavigation { get; set; } = null!;

    public virtual ICollection<VmciPoPosting> VmciPoPostings { get; } = new List<VmciPoPosting>();
}
