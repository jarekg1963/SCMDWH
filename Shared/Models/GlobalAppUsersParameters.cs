using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMDWH.Shared.Models
{
    public class GlobalAppUsersParameters
    {
      
        public string UserName { get; set; }
        public DateTime DateMainCAFrom { get; set; }

        public DateTime DateMainCATo { get; set; }

        public DateTime DateGRMainCAFrom { get; set; }

        public DateTime DateGRMainCATo { get;set; }
    }
    
}
