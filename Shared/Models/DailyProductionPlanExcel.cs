using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class DailyProductionPlanExcel
{
    public string WorkOrderNo { get; set; } = null!;

    public bool Todo { get; set; }

    public string WoActivityStatus { get; set; } = null!;

    public string LineName { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public string TpvModel { get; set; } = null!;

    public string Ctn { get; set; } = null!;

    public string OryginalCtnFromFile { get; set; } = null!;

    public int Qty { get; set; }

    public int Input { get; set; }

    public int Output { get; set; }

    public DateTime? WoStartTime { get; set; }

    public string StartD { get; set; } = null!;

    public string StartH { get; set; } = null!;

    public DateTime? WoEndTime { get; set; }

    public string EndD { get; set; } = null!;

    public string EndH { get; set; } = null!;

    public bool? WoNumberValidated { get; set; }

    public string Team { get; set; } = null!;

    public string Pcsh { get; set; } = null!;

    public string CycleTime { get; set; } = null!;

    public decimal MinCt { get; set; }

    public string WorkOrderStatus { get; set; } = null!;

    public string Invoice { get; set; } = null!;

    public string TunerAssy { get; set; } = null!;

    public string TunerWo { get; set; } = null!;

    public string SsbPn { get; set; } = null!;

    public DateTime InsertTime { get; set; }

    public DateTime LastUpdateTime { get; set; }

    public bool SlImportedToWms { get; set; }

    public string LhgStatus { get; set; } = null!;

    public string SlStatus { get; set; } = null!;

    public bool MissingLhg { get; set; }

    public bool ConditionalStart { get; set; }

    public bool IsUpdated { get; set; }
}
