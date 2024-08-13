using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leaves.DTO
{
    public class RNAppLeavesDTO
    {
        public string Empcd { get; set; }
        public string LeaveTypeName { get; set; }
        public DateTime Fromdt { get; set; }
        public DateTime Todt { get; set; }
        public decimal TotalNoOfDays { get; set; }
        public long Leavbal { get; set; }
    }
}
