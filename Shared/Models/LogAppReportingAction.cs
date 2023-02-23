using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public partial class LogAppReportingAction
    {
        public long Id { get; set; }
        public string ActionType { get; set; }
        public string ActionDetails { get; set; }
        public string ActionResult { get; set; }
        public DateTime ActionTime { get; set; }
        public string ActrionTriggeredByUser { get; set; }
    }
}
