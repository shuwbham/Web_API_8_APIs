using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransferPosting.DTO
{
    public class TransfersDTO
    {
        public string Empcd { get; set; }
        public DateTime? Joindt { get; set; }
        public DateTime? Relievedt { get; set; }
        public string Dis_Name { get; set; }
        public string Designame { get; set; }
        public string Officename { get; set; }
    }
}