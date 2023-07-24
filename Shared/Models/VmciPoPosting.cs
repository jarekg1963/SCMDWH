using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class VmciPoPosting
{
    public int PopostingId { get; set; }

    public int PoitemId { get; set; }

    public string PalletNo { get; set; } = null!;

    public int PalletQty { get; set; }

    public string ProductTpvNo { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? PostedTime { get; set; }

    public DateTime? ConfirmedTime { get; set; }

    public DateTime? AsnTime { get; set; }

    public long? PostingKey { get; set; }

    public string? FileSeqNo { get; set; }

    public string Xi429fileName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool ReadyForSapPost { get; set; }

    public bool RetrySapPost { get; set; }

    public bool ReadyForCevaSend { get; set; }

    public bool Lock { get; set; }

    public string SapMessage { get; set; } = null!;

    public long CevaPostingKey { get; set; }

    public bool CevaConfirmedRework { get; set; }

    public bool PtsReported { get; set; }

    public DateTime? PtsReportedTime { get; set; }

    public string PtsTransId { get; set; } = null!;

    public string PtsMessageId { get; set; } = null!;

    public bool PtsError { get; set; }

    public string PtsErrorMessage { get; set; } = null!;

    public virtual VmciPoItem Poitem { get; set; } = null!;
}
