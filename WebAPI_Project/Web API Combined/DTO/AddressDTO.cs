using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RNAppAddress.DTO
{
    public class RNAppAddressDTO
    {
        public string Empcd { get; set; }
        // Present address details
        public string PreHouseNumber { get; set; }
        public string PreBlockName { get; set; }
        public string PreDistrictName { get; set; }
        public string PreStateAbbr { get; set; }
        public string PreVillage { get; set; }
        public string PrePinCode { get; set; }
        public string PreMobile { get; set; }
        public string PrePhone { get; set; }
        // Permanent address details
        public string PerHouseNumber { get; set; }
        public string PermBlockName { get; set; }
        public string PermDistrictName { get; set; }
        public string PermStateAbbr { get; set; }
        public string PermVillage { get; set; }
        public string PermPinCode { get; set; }
        public string PermMobile { get; set; }
        public string PermPhone { get; set; }
        public string Email { get; set; }
    }
}
