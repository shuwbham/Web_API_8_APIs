using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RNAppFamily.DTO
{
    public class RNAppFamilyDTO
    {
        public string Empcd { get; set; }
        public string MemName { get; set; }
        public string RelationNameEng { get; set; }
        public DateTime? MemDob { get; set; }
        public string MemDepend { get; set; }
    }
}