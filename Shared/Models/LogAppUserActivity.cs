using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public partial class LogAppUserActivity
    {
        public long Id { get; set; }
        public string AppActivityType { get; set; }
        public string AppActivityDetails { get; set; }
        public DateTime ActivityTime { get; set; }
        public string ActivityTriggeredByUser { get; set; }
    }
}
