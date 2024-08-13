using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personal.DTO
{
    public class EmpPersonalDTO
    {
        public string Empcd { get; set; }
        public string EmpFname { get; set; }
        public string EmpMname { get; set; }
        public string EmpLname { get; set; }
        public string EmpFmhName { get; set; }
        public string EmpFhmMname { get; set; }
        public string EmpFhmLname { get; set; }
        public string StateAbbr { get; set; }
        public string DisName { get; set; }
        public string ReligionName { get; set; }
        public string EmpGender { get; set; }
        public string MaritalName { get; set; }
        public string BloodGroupName { get; set; }
        public string ServiceName { get; set; }
        public DateTime? DofJoin { get; set; }
        public DateTime? DofRetireCurr { get; set; }
        public string EmpIdMasrk { get; set; }
        public string EmpHeight { get; set; }
    }
}